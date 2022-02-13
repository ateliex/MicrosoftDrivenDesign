using Ateliex.Data;
using System.ComponentModel;

namespace Ateliex.Areas.Cadastro.Models
{
    [Info(AreaName = "Cadastro", MetaName = "ModeloRecursoTipoDescricao", SingleName = "Descrição de Tipo de Recurso de Modelo", PluralName = "Descrições de Tipo de Recurso de Modelo")]
    public class ModeloRecursoTipoDescricao : Entity
    {
        [DisplayName("Tipo")]
        public int TipoId { get; set; }

        [DisplayName("Tipo")]
        public ModeloRecursoTipo? Tipo { get; set; }

        public string Texto { get; set; }
    }
}
