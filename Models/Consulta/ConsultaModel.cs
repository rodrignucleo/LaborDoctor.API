using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaborDoctor.API.Models
{
    public class ConsultaModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_consulta { get; set; }
        
        [Required(ErrorMessage = "Paciente é obrigatório!")]
        [ForeignKey("paciente")]
        public int? id_paciente { get; set; }
        public PacienteModel? paciente { get; set; }

        [Required(ErrorMessage = "Médico é obrigatório!")]
        [ForeignKey("medico")]
        public int? id_medico { get; set; }
        public MedicoModel? medico { get; set; }

        public bool? status { get; set; }

        [Required(ErrorMessage = "Horário é obrigatório!")]
        [ForeignKey("schedule")]
        public int? id_schedule { get; set; }
        public ScheduleModel? schedule { get; set; }
    }
}