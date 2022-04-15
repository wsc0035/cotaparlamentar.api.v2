namespace cotaparlamentar.api.v2.ViewModel
{
    public class DeputadoViewModel
    {
        public int id { get; set; }
        public string nuDeputadoId { get; set; }
        public string nome { get; set; }
        public string partido { get; set; }
        public string dtCadastro { get; set; }
        public string estado { get; set; }
        public string nomeCivil { get; set; }
        public string idperfil { get; set; }
        public string dtAtualizacao { get; set; }
        public string emExercicio { get; set; }
        public string dtAtAssessor { get; set; }
    }
}
