using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaborDoctor.API.Models
{
    public class PacienteModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_paciente { get; set; }
        
        [Required(ErrorMessage = "Nome é obrigatório!")]
        public string? nome { get; set; }

        [Required(ErrorMessage = "CPF é obrigatório!")]
        public string? cpf { get; set; }

        [Required(ErrorMessage = "Telefone é obrigatório!")]
        public string? telefone { get; set; }

        [Required(ErrorMessage = "Email é obrigatório!")]
        public string? email { get; set; }

        [Required(ErrorMessage = "Senha é obrigatório!")]
        [DataType(DataType.Password)]
        public string? senha { get; set; }

        [DataType(DataType.Password)]
        public string? senha_antiga { get; set; }
    }
}