using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthTech_SmartCities.Models
{
    [Table("USUARIO")]
    public class UsuarioModel
    {
        private int id;

        [Key]
        [Column("ID")]
        public int UsuarioId { get; set; }

        [Column("NOME")]
        [Required(ErrorMessage = "Insira um Nome válido")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "O Nome deve ter no mínimo 2 e no máximo 100 caracteres")]
        //[Display(Name = "Nome do usuário")]
        public string UsuarioNome { get; set; }

        [Column("CPF")]
        [Required(ErrorMessage = "Insira um CPF válido")]
        //alterar o string length do cpf
        [StringLength(12, MinimumLength = 1, ErrorMessage = "CPF deve ter 11 dígitos")]
        
        
        public string UsuarioCpf { get; set; }


        //public IList<UsuarioModel> Usuarios { get; set; }


        public UsuarioModel() 
        {
        
        }

        //sem id pro banco
        public UsuarioModel(String nome, String cpf) 
        {
            UsuarioNome = nome;
            UsuarioCpf = cpf;        
        
        }

        public UsuarioModel(int usuarioId, string usuarioNome, string usuarioCpf)
        {
            UsuarioId = usuarioId;
            UsuarioNome = usuarioNome;
            UsuarioCpf = usuarioCpf;
        }

        public UsuarioModel(int id)
        {
            this.id = id;
        }
    }
}

