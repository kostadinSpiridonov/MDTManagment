using MDTManagment.Commands;
using MDTManagment.Models;
using MDTManagment.Services;
using MDTManagment.Views.Dentists;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MDTManagment.ViewModels.Dentists
{
    public class AddDentistViewModel
    {
        private DentistService dentistService { get; set; }

        public Dentist NewDentist { get; set; }


        public AddDentistViewModel()
        {
            this.dentistService = new DentistService();

            this.AddDentist = new RelayCommand(this.HandleAddDentist);

            this.NavigateToDentists = new RelayCommand(this.HandleNavigateToDentists);

            this.NewDentist = new Dentist();
        }


        public ICommand AddDentist { get; set; }

        public ICommand NavigateToDentists { get; set; }


        private void HandleAddDentist(object obj)
        {
            if (this.NewDentist.Name == null ||
                this.NewDentist.MiddleName == null ||
                this.NewDentist.LastName == null ||
                this.NewDentist.Contact == null ||
                this.NewDentist.ProfessionalExperience < 0 || this.NewDentist.ProfessionalExperience > 100)
            {
                MessageBox.Show("Невалидни данни.", "Зъболекар", MessageBoxButton.OK);
                return;
            }
            this.NewDentist.NameForDisplaying = this.NewDentist.Name + " " + this.NewDentist.MiddleName + " " + this.NewDentist.LastName;
            this.NewDentist.ProfessionalExperienceForDisplaying = this.NewDentist.ProfessionalExperience + " г.";
            this.dentistService.AddDentist(this.NewDentist);
            MessageBox.Show("Зъболекарят е добавен.", "Зъболекар", MessageBoxButton.OK);
            App.Navigation.Navigate(new DentistsPage());
        }

        private void HandleNavigateToDentists(object obj)
        {
            App.Navigation.Navigate(new DentistsPage());
        }
    }
}
