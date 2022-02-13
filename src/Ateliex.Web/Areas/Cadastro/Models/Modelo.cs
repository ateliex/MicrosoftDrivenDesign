using Ateliex.Data;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Ateliex.Areas.Cadastro.Models
{
    [Info(AreaName = "Cadastro", MetaName = "Modelo", SingleName = "Modelo", PluralName = "Modelos")]
    public class Modelo : Entity
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

        public virtual ICollection<ModeloRecurso> Recursos { get; set; }

        public Modelo()
        {
            //Id = -1;

            Nome = "Modelo #";

            Recursos = new HashSet<ModeloRecurso>();
        }
    }
}
