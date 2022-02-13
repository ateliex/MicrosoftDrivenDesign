using Ateliex.Data;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Ateliex.Areas.Cadastro.Models
{
    [Info(AreaName = "Cadastro", MetaName = "ModeloRecursoTipo", SingleName = "Tipo de Recurso de Modelo", PluralName = "Tipos de Recurso de Modelo")]
    public class ModeloRecursoTipo : Entity
    {
        [DisplayName("Nome")]
        [Required(ErrorMessage = "Teste: Nome Obrigatório")]
        [MaxLength(255)]
        public string Nome { get; set; }

        [DisplayName("Custo de Produção")]
        [ReadOnly(true)]
        public decimal CustoDeProducao
        {
            get
            {
                var total = Recursos.Sum(p => p.CustoPorUnidade);

                return total;
            }
        }

        [DisplayName("Descrição")]
        public ModeloRecursoTipoDescricao? Descricao { get; set; }

        public virtual ICollection<ModeloRecurso> Recursos { get; set; }
        
        public ModeloRecursoTipo()
        {
            Recursos = new HashSet<ModeloRecurso>();
        }
    }
}
