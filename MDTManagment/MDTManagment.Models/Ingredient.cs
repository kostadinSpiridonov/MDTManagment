using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDTManagment.Models
{
    public class Ingredient
    {
        [Key]
        public int Id { get; set; }

        public string Description { get; set; }
    }
}
