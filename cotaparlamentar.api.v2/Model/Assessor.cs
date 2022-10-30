using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cotaparlamentar.api.v2.Model
{
    [Table("tbassessor")]
    public class Assessor
    {
        [Key]
        public int Id { get; set; }
        public int NuDeputadoId { get; set; }
        public string? Nome { get; set; }
        public string? Cargo { get; set; }
        public DateTime PeriodoExercicio { get; set; }
        public decimal Remuneracao { get; set; }
        public decimal Auxilio { get; set; }
        public string? LinkRemuneracao { get; set; }
        public DateTime DtCadastro { get; set; } = DateTime.Now;
    }
}
