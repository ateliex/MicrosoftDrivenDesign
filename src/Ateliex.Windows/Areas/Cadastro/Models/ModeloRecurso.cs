using System.ComponentModel;

namespace Ateliex.Areas.Cadastro.Models
{
    public class ModeloRecurso : Entity
    {
        public int ModeloId { get; set; }

        public virtual Modelo Modelo { get; set; }

        public int TipoId { get; set; }
        
        public virtual ModeloRecursoTipo Tipo { get; set; }

        public string Descricao { get; set; }

        public decimal Custo { get; set; }

        public int Unidades { get; set; }

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

        public ModeloRecurso()
        {
            PropertyChanged += Recurso_PropertyChanged;
        }

        private static void Recurso_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var recurso = sender as ModeloRecurso;

            if (recurso.Modelo == null) return;

            if (e.PropertyName == nameof(CustoPorUnidade))
            {
                recurso.Modelo.OnPropertyChanged("CustoDeProducao");
            }
        }        
    }
}
