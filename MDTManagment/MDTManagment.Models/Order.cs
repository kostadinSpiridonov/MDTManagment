using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDTManagment.Models
{
    public class Order
    { 
        public Order()
        {
            this.DeclaredIngredients = new HashSet<Ingredient>();
        }

        [Key]
        public int Id {  get; set; }

        public string Type { get; set; }

        public DateTime DateОfReceipt{ get; set; }

        public DateTime DeadLine { get; set; }

        public double Price{ get; set; }

        //public List<SpecialRequirementsClass> SpecialRequirements { get; set; }       //Class SpecialRequirementsClass e deleted shot syzdavashe problemi :D
        public ICollection<Ingredient> DeclaredIngredients { get; set; }    

        public bool FacialArc { get; set; }

        public bool Articulator { get; set; }

        public bool MetalTest { get; set; }

        public bool CeramicTest { get; set; }

        public string TypeOfImpressionMaterial { get; set; }
    }
}
