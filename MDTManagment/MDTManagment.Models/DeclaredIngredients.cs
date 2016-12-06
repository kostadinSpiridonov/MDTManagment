using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDTManagment.Models
{
    public class DeclaredIngredientsClass
    {
        [Key]
        public int IdDeclaredIngredients { get; set; }

        public string DeclaredIngredients { get; set; }
    }
}
