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
        [Key]
        public int Id {  get; set; }

        public string TypeOfTheOrder { get; set; }

        public DateTime DateОfReceipt{ get; set; }

        public DateTime DeadLine { get; set; }

        public double Price{ get; set; }

        //public List<SpecialRequirementsClass> SpecialRequirements { get; set; }       //Class SpecialRequirementsClass e deleted shot syzdavashe problemi :D
        public List<DeclaredIngredientsClass> DeclaredIngredients { get; set; }       // CAN'T ENTER LISTS IN THE DATEBASE??????????????????????????????????????????????@!@?!@?!@

        public bool FacialArc { get; set; }

        public bool Articulator{ get; set; }

        public bool MetalTest { get; set; }

        public bool CeramicTest { get; set; }

        public string TypeOfImpressionMaterial { get; set; }

    }
}
