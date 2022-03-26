namespace cotaparlamentar.api.v2.Model
{
    public class CotaParlamentar
    {
        public int NuDeputadoId { get; set; }
        public string? TipoDespesa { get; set; }
        public string? LinkDespesa { get; set; }
        public string? LinkDespesaSumarizado { get; set; }
        public string? Despesa { get; set; }
        public DateTime Data { get; set; }
    }
}
