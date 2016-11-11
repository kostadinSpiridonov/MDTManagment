using System.ComponentModel.DataAnnotations;

namespace MDTManagment.Models
{
    public class Dentist
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string PhoneNumber { get; set; }
    }
}
