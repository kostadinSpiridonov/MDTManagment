using System.ComponentModel.DataAnnotations;

namespace MDTManagment.Models
{
    public class Dentist
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string Contact { get; set; }

        public int ProfessionalExperience { get; set; }

        public string ProfessionalExperienceForDisplaying { get; set; }

        public string NameForDisplaying { get; set; }
    }
}
