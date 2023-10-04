using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaborDoctor.API.Models
{
    public class ScheduleModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_schedule { get; set; }

        [Required(ErrorMessage = "Médico é obrigatório!")]
        [ForeignKey("medico")]
        public int? id_medico { get; set; }
        public MedicoModel? medico { get; set; }

        [Required(ErrorMessage = "Data é obrigatório!")]
        public DateTime? data { get; set; }

        // [Required(ErrorMessage = "Hora é obrigatório!")]
        // public TimeOnly? hora { get; set; }

        [Required(ErrorMessage = "Status é obrigatório!")]
        public bool status { get; set; }
}
}