using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cotaparlamentar.api.v2.Model
{
    [Table("tbdeputados")]
    public class Deputado
    {
        [Key]
        public int Id { get; set; }
        public int NuDeputadoId { get; set; }
        public string? Nome { get; set; }
        public string? Partido { get; set; }
        public string? Estado { get; set; }
        public string? NomeCivil { get; set; }
        public int IdPerfil { get; set; }
        public bool EmExercicio { get; set; }
        public DateTime DtAtualizacao { get; set; }
        public DateTime DtCadastro { get; set; }
        public DateTime? DtAtAssessor { get; set; }
    }
}
