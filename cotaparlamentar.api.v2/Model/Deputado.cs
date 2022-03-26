namespace cotaparlamentar.api.v2.Model
{
    public class Deputado
    {
        public int NuDeputadoId { get; set; }
        public string? Nome { get; set; }
        public string? Partido { get; set; }
        public string? Estado { get; set; }
        public string? NomeCivil { get; set; }
        public int IdPerfil { get; set; }
        public bool EmExercicio { get; set; }
    }
}
