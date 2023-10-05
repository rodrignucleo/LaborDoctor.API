using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaborDoctor.API.Models
{
public class ResponseModel{
    public List<MedicoModel> ?tb_medico { get; set; }
}

    public class MedicoModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_medico { get; set; }
        
        [Required(ErrorMessage = "Nome é obrigatório!")]
        public string? nome { get; set; }

        [Required(ErrorMessage = "CRM é obrigatório!")]
        public string? crm { get; set; }

        [Required(ErrorMessage = "CPF é obrigatório!")]
        public string? cpf { get; set; }

        [Required(ErrorMessage = "Especialidade é obrigatório!")]
        public string? especilidade { get; set; }

        [Required(ErrorMessage = "Telefone é obrigatório!")]
        public string? telefone { get; set; }

        [Required(ErrorMessage = "Email é obrigatório!")]
        public string? email { get; set; }
    }
}