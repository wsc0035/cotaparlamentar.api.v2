namespace cotaparlamentar.api.v2.Model
{
    public class Assessor
    {
        public int NuDeputadoId { get; set; }
        public string? Nome { get; set; }
        public string? Cargo { get; set; }
        public DateTime PeriodoExercicio { get; set; }
        public decimal Remuneracao { get; set; }
        public decimal Auxilio { get; set; }
        public string? LinkRemuneracao { get; set; }
    }
}
