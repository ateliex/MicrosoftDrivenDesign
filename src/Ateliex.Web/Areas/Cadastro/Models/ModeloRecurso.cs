using Ateliex.Data;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Ateliex.Areas.Cadastro.Models
{
    [Info(AreaName = "Cadastro", MetaName = "ModeloRecurso", SingleName = "Recurso de Modelo", PluralName = "Recursos de Modelo")]
    public class ModeloRecurso : Entity
    {
        [DisplayName("Modelo")]
        public int ModeloId { get; set; }

        [DisplayName("Modelo")] 
        public virtual Modelo? Modelo { get; set; }

        [DisplayName("Tipo")]
        public int TipoId { get; set; }

        [DisplayName("Tipo")]
        public ModeloRecursoTipo? Tipo { get; set; }

        [DisplayName("Descrição")]
        [MaxLength(255)]
        public string Descricao { get; set; }

        [DisplayName("Custo")]
        public decimal Custo { get; set; }

        [DisplayName("Unidades")]
        public int Unidades { get; set; }

        [DisplayName("Custo por Unidade")]
        public decimal CustoPorUnidade
        {
            get
            {
                if (Unidades == 0)
                {
                    return 0;
                }
                else
                {
                    var custoPorUnidade = Custo / Unidades;

                    return custoPorUnidade;
                }
            }
        }

        [DisplayName("Observação")]
        public virtual ModeloRecursoObservacao? Observacao { get; set; }

        public virtual ICollection<ModeloRecursoAnexo> Anexos { get; set; }

        public ModeloRecurso()
        {
            Anexos = new HashSet<ModeloRecursoAnexo>();
        }
    }
}
