using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ateliex.Data
{
    public abstract class Entity
    {
        [Required(ErrorMessage = "Teste: Id Obrigatório")]
        public int Id { get; set; }

        public bool IsEdit()
        {
            return Id != 0;
        }

        public bool IsNew()
        {
            return Id == 0;
        }
    }
}
