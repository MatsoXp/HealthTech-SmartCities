using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthTech_SmartCities.Models
{
    [Table("RECEITA")]
    public class ReceitaModel
    {
        [Key]
        [Column("ID_RECEITA")]
        public int ReceitaId { get; set; }

        [Column("DATA_EMISSAO")]
        public DateTime DataEmissao { get; set; }

        [Column("PRESCRICAO")]
        public string Prescricao { get; set; }

        [ForeignKey("CONSULTA")]
        [Column("ID_CONSULTA")]
        public int ConsultaId { get; set; }

        public ReceitaModel()
        {

        }

        public ReceitaModel(DateTime dataEmissao, string prescricao, int consultaId) 
        { 
            DataEmissao = dataEmissao;
            Prescricao = prescricao;
            ConsultaId = consultaId;

        }




    }
}
