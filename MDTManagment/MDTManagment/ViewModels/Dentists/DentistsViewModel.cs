﻿using MDTManagment.Commands;
using MDTManagment.Models;
using MDTManagment.Services;
using MDTManagment.Views;
using MDTManagment.Views.Dentists;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Navigation;

namespace MDTManagment.ViewModels.Dentists
{
    public class DentistsViewModel : BaseViewModel
    {
        public ObservableCollection<Dentist> Dentists { get; set; }

        public Dentist NewDentist { get; set; }

        public Dentist SelectedDentist { get; set; }

        private DentistService dentistService;

        public DentistsViewModel()
        {
            this.dentistService = new DentistService();

            var databaseDentists = this.dentistService.GetAllDentists();

            this.Dentists = new ObservableCollection<Dentist>(databaseDentists);

            this.NewDentist = new Dentist();

            this.SelectedDentist = new Dentist();

            this.AddDentist = new RelayCommand(this.HandleAddDentist);

            this.DeleteDentist = new RelayCommand(this.HandleDeleteDentist);

            this.NavigateToAddDentist = new RelayCommand(this.HandleNavigateToAddDentist);
        }

        private ICommand viewDentistCommand;


        public ICommand ViewDentistCommand
        {
            get
            {
                if (this.viewDentistCommand == null)
                {
                    this.viewDentistCommand = new RelayCommand(this.ViewDentist);
                };

                return this.viewDentistCommand;
            }
        }


        public ICommand AddDentist { get; set; }


        public ICommand DeleteDentist { get; set; }


        public ICommand NavigateToAddDentist { get; set; }

        public void ViewDentist(object obj)
        {
            App.Navigation.Navigate(new DentistPage((int)obj));
        }


        private void HandleAddDentist(object obj)
        {
            //TODO: test this
            this.dentistService.AddDentist(this.NewDentist);
            this.Dentists.Add(this.NewDentist);
            this.OnPropertyChanged("Dentists");
            MessageBox.Show("New Dentist Added.", "Dentists Status", MessageBoxButton.OK);
        }


        private void HandleDeleteDentist(object obj)
        {
            //TODO: test this
            this.dentistService.DeleteDentist(SelectedDentist.Id);
            this.Dentists.Remove(this.SelectedDentist);
            this.OnPropertyChanged("Dentists");
            MessageBox.Show("Dentist Deleted.", "Dentists Status", MessageBoxButton.OK);
        }


        private void HandleNavigateToAddDentist(object obj)
        {
            App.Navigation.Navigate(new AddDentistPage());
        }
    }
}
