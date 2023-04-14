using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthTech_SmartCities.Models
{
    [Table("MEDICO")]
    public class MedicoModel
    {
        [Key]
        [Column("ID_MEDICO")]
        public int MedicoId { get; set; }

        [Column("NOME")]
        [Required(ErrorMessage = "Insira um Nome válido")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "O Nome deve ter no mínimo 2 e no máximo 100 caracteres")]
        public string MedicoNome { get; set; }

        [Column("CPF")]
        [Required(ErrorMessage = "Insira um CPF válido")]
        //alterar o string length do cpf
        [StringLength(12, MinimumLength = 1, ErrorMessage = "CPF deve ter 11 dígitos")]
        public string MedicoCpf { get; set; }

        [Column("CRM")]
        [Required(ErrorMessage = "Insira um CRM válido")]
        //alterar o string length do crm
        [StringLength(12, MinimumLength = 1, ErrorMessage = "CRM deve ter X dígitos")]
        public string MedicoCrm { get; set; }

        [Column("ESPECIALIDADE")]
        [Required(ErrorMessage = "Insira a especialidade do medico")]
        //alterar o string length do crm
        [StringLength(12, MinimumLength = 1, ErrorMessage = "insira a especialidade")]
        public string Especialidade { get; set; }


        //public IList<MedicoModel> Medicos { get; set; }

        public MedicoModel()
        {

        }

        public MedicoModel(string nome, string cpf, string crm, string especialidade)
        {
            MedicoNome = nome;
            MedicoCpf = cpf;
            MedicoCrm = crm;
            Especialidade = especialidade;

        }


    }
}
