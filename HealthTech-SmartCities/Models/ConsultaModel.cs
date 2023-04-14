using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthTech_SmartCities.Models
{
    [Table("CONSULTA")]
    public class ConsultaModel
    {
        [Key]
        [Column("ID_CONSULTA")]
        public int ConsultaId { get; set; }

        [Column("DATA_HORA")]
        public DateTime DataHora { get; set; }

        [Column("DESCRICAO")]
        public string Descricao { get; set; }

        [ForeignKey("MEDICO")]
        [Column("ID_MEDICO")]
        public int MedicoId { get; set; }

        [ForeignKey("USUARIO")]
        [Column("ID_USUARIO")]
        public int UsuarioId { get; set; }

        public MedicoModel Medico { get; set; }
        public UsuarioModel Usuario { get; set; }


        public ConsultaModel(DateTime dataHora, string descricao, int idMedico, int idPaciente)
        {
            DataHora = dataHora;
            Descricao = descricao;
            MedicoId = idMedico;
            UsuarioId = idPaciente;
        }

        public ConsultaModel()
        {

        }
    }
}
