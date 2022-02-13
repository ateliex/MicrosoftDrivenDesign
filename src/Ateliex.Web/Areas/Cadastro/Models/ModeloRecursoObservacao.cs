using Ateliex.Data;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace Ateliex.Areas.Cadastro.Models
{
    [Info(AreaName = "Cadastro", MetaName = "ModeloRecursoObservacao", SingleName = "Observação de Recurso de Modelo", PluralName = "Observações de Recurso de Modelo")]
    public class ModeloRecursoObservacao : Entity
    {
        [DisplayName("Recurso")]
        public int RecursoId { get; set; }

        [DisplayName("Recurso")]
        public ModeloRecurso? Recurso { get; set; }

        public string Texto { get; set; }
    }
}
