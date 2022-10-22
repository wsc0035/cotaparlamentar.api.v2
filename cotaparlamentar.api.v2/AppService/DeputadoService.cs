using cotaparlamentar.api.v2.Infraestructure;
using cotaparlamentar.api.v2.Infraestructure.DataContext;
using cotaparlamentar.api.v2.Model;
using HtmlAgilityPack;
using System.Web;

namespace cotaparlamentar.api.v2.AppService;

public class DeputadoService
{
    private static readonly string _legislatura = ConfigAppSettings.Legislatura;
    private readonly MysqlDataContext _mysqlContext;
    public DeputadoService(MysqlDataContext mysqlContext)
    {  
        _mysqlContext = mysqlContext;   
    }

    public void BuscaTodosDeputadosSiteCompletoPorIdPerfil()
    {
        var listaSite = new List<Deputado>();

        var listaBanco = _mysqlContext.Deputado.ToList();

        var options = new ParallelOptions { MaxDegreeOfParallelism = 8 };

        Parallel.ForEach(listaBanco, options, deputado =>
        {
            listaSite.Add(BuscaDeputadoSiteAtualPorIdPerfil(deputado.IdPerfil));
        });

        foreach (var itemBanco in listaBanco)
        {
            foreach (var itemSite in (listaSite.Where(t => t.IdPerfil == itemBanco.IdPerfil)))
            {
                itemBanco.Nome = itemSite.Nome;
                itemBanco.NomeCivil = itemSite.NomeCivil;
                itemBanco.Partido = itemSite.Partido;
                itemBanco.Estado = itemSite.Estado;
                itemBanco.EmExercicio = itemSite.EmExercicio;
                itemBanco.DtAtualizacao = DateTime.Now;
            }
        }

        _mysqlContext.UpdateRange(listaBanco);
        _mysqlContext.SaveChanges();
    }
    public void BuscaTodosDeputadoNovosSite()
    {
        var listaDeputadoSite = new List<Deputado>();

        var deputadosApi = _mysqlContext.Deputado.ToList();

        var deputadosSite = BuscarTodosDeputadoSiteAtual();

        var diff = deputadosSite.Where(p => !deputadosApi.Any(l => p.NuDeputadoId == l.NuDeputadoId)).ToList();
        var options = new ParallelOptions { MaxDegreeOfParallelism = 8 };

        Parallel.ForEach(diff, options, deputado => AtualizaIDPerfilDeputado(deputado));
        Parallel.ForEach(diff, options, deputado => {
            var deputadoBusca = BuscaDeputadoSiteAtualPorIdPerfil(deputado.IdPerfil);
            deputado.NomeCivil = deputadoBusca.NomeCivil;
            deputado.EmExercicio = deputadoBusca.EmExercicio;
            deputado.Estado = deputadoBusca.Estado;
            deputado.Partido = deputadoBusca.Partido;
            deputado.IdPerfil = deputadoBusca.IdPerfil;
            deputado.DtCadastro = DateTime.Now;
            deputado.DtAtualizacao = DateTime.Now;
            listaDeputadoSite.Add(deputado);
        });

        if (listaDeputadoSite.Count > 0)
        {
            _mysqlContext.AddRange(listaDeputadoSite);
            _mysqlContext.SaveChanges();
        }
    }
    
    private Deputado BuscaDeputadoSiteAtualPorIdPerfil(int idperfil)
    {
        var url = $"https://www.camara.leg.br/deputados/{idperfil}";
        var web = new HtmlWeb();
        var doc = web.Load(url);

        HtmlNodeCollection depInterno = doc.DocumentNode.SelectNodes("//div[@class='l-identificacao-row']");

        if (depInterno == null)
            return new Deputado();

        var nome = depInterno.FirstOrDefault().SelectSingleNode("//*[@id='identificacao']/div/div/div[3]/div/div/div[2]/div[1]/ul/li[1]/text()") != null ? depInterno.FirstOrDefault().SelectSingleNode("//*[@id='identificacao']/div/div/div[3]/div/div/div[2]/div[1]/ul/li[1]/text()").InnerText : depInterno.FirstOrDefault().SelectSingleNode("//*[@id='identificacao']/div/div[4]/ul/li[1]/text()").InnerText;

        nome = HttpUtility.HtmlDecode(nome);

        var emExercicio = depInterno.FirstOrDefault().SelectSingleNode("//*[@id='identificacao']/div/div/div[2]/span/span[1]");

        var deputado = new Deputado();

        deputado.NomeCivil = nome.Trim();
        deputado.Nome = HttpUtility.HtmlDecode(depInterno.FirstOrDefault().SelectSingleNode("//*[@id='nomedeputado']").InnerText).Trim();
        deputado.Estado = depInterno.FirstOrDefault().SelectSingleNode("//span[@class='foto-deputado__partido-estado']").InnerText.Split()[2];
        deputado.Partido = depInterno.FirstOrDefault().SelectSingleNode("//span[@class='foto-deputado__partido-estado']").InnerText.Split()[0];
        deputado.EmExercicio = !(emExercicio == null);
        deputado.IdPerfil = idperfil;

        return deputado;
    }
    public List<Deputado> BuscarTodosDeputadoSiteAtual()
    {
        var url = "https://www.camara.leg.br/cota-parlamentar/index.jsp";
        var web = new HtmlWeb();
        var doc = web.Load(url);

        HtmlNodeCollection matchesList = doc.DocumentNode.SelectNodes("//ul[@id='listaDeputados']//li");

        var deputadosList = new List<Deputado>();

        foreach (var deputado in matchesList)
        {
            deputadosList.Add(new Deputado
            {
                NuDeputadoId = Convert.ToInt32(deputado.SelectSingleNode(".//label//span").Attributes["id"].Value),
                Nome = HttpUtility.HtmlDecode(deputado.SelectSingleNode(".//label//span").InnerText).Trim()
            });
        }

        return deputadosList;
    }
    private Deputado AtualizaIDPerfilDeputado(Deputado deputado)
    {
        var web = new HtmlWeb();
        var url = string.Format("https://www.camara.leg.br/deputados/quem-sao/resultado?search={0}&partido=&uf=&legislatura={1}&sexo=", deputado.Nome, _legislatura);
        var doc = web.Load(url);

        HtmlNodeCollection linkDetalhe = doc.DocumentNode.SelectNodes("//h3//a");
        if (linkDetalhe != null)
        {
            int idPerfil = Convert.ToInt32(linkDetalhe.FirstOrDefault().Attributes["href"].Value.Split('/')[4]);
            deputado.IdPerfil = idPerfil;
        }

        return deputado;
    }
}
