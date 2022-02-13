using Ateliex.Data;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Ateliex.Areas.Cadastro.Models
{
    [Info(AreaName = "Cadastro", MetaName = "ModeloRecursoAnexo", SingleName = "Anexo de Recurso de Modelo", PluralName = "Anexos de Recurso de Modelo")]
    public class ModeloRecursoAnexo : Entity
    {
        public int RecursoId { get; set; }

        [DisplayName("Recurso")]
        public ModeloRecurso? Recurso { get; set; }

        [MaxLength(255)]
        public string Nome { get; set; }

        public byte[] Arquivo { get; set; }
    }
}
