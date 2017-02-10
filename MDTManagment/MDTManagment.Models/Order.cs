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
        public int Id { get; set; }

        public string Type { get; set; }

        public string ToothColour { get; set; }

        public DateTime DateОfReceipt { get; set; }

        public DateTime DeadLine { get; set; }
        
        public decimal Price { get; set; }

        public string SpecialRequirements { get; set; }

        public string DeclaredIngredients { get; set; }

        public bool FacialArc { get; set; }

        public bool Articulator { get; set; }

        public bool MetalTest { get; set; }

        public bool CeramicTest { get; set; }

        public string TypeOfImpressionMaterial { get; set; }

        public int DentistId { get; set; }

        //public string DisplayingDentist { get; set; }

    }
}
