using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Ateliex.Areas.Comercial.Models
{
    public class PlanoComercialCustoTipo
    {
        public Enums.PlanoComercialCustoTipo Id { get; set; }

        [MaxLength(255)]
        public string Nome { get; set; }

        //public ModeloRecursoTipoDescricao? Descricao { get; set; }

        public virtual ObservableCollection<PlanoComercialCusto> Custos { get; set; }

        public event NotifyCollectionChangedEventHandler CustosChanged;

        public PlanoComercialCustoTipo()
        {
            Custos = new ObservableCollection<PlanoComercialCusto>();

            Custos.CollectionChanged += Custos_CollectionChanged;
        }

        private void Custos_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            CustosChanged?.Invoke(this, e);
        }
    }
}
