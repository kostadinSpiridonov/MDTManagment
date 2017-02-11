﻿using MDTManagment.Commands;
using MDTManagment.Models;
using MDTManagment.Services;
using MDTManagment.ViewModels;
using MDTManagment.Views;
using MDTManagment.Views.Activities;
using MDTManagment.Views.Dentists;
using MDTManagment.Views.Orders;
using MDTManagment.Views.Patients;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Navigation;

namespace MDTManagment.ViewModels.Patients
{
    public class PatientsViewModel : BaseViewModel
    {

        private DentistService dentistService { get; set; }




        public ObservableCollection<Patient> Patients { get; set; }

        public Patient SelectedPatient { get; set; }

        private PatientService patientService;
        
        public PatientsViewModel()
        {
            this.patientService = new PatientService(); 

            var databasePatients = this.patientService.GetAllPatients();

            this.Patients = new ObservableCollection<Patient>(databasePatients);

            this.DeletePatient = new RelayCommand(this.HandleDeletePatient);
            
            this.NavigateToAddPatient = new RelayCommand(this.HandleNavigateToAddPatient);

            this.NavToHome = new RelayCommand(this.HandleNavToHome);
            this.NavToPatients = new RelayCommand(this.HandleNavToPatients);
            this.NavToDentists = new RelayCommand(this.HandleNavToDentists);
            this.NavToOrders = new RelayCommand(this.HandleNavToOrders);
            this.NavToActivities = new RelayCommand(this.HandleNavToActivities);

            this.DisplayPatient = new RelayCommand(this.HandleDisplayPatient);
        }

   
        //TODO: Delete this command and delete the method ViewPatient and delete the page PatientPage and delete the method in PatientService
        private ICommand viewPatientCommand;
        public ICommand ViewPatientCommand
        {
            get
            {
                if (this.viewPatientCommand == null)
                {
                    this.viewPatientCommand = new RelayCommand(this.ViewPatient);
                };

                return this.viewPatientCommand;
            }
        }
        
        public ICommand DeletePatient { get; set; }
        
        public ICommand NavigateToAddPatient { get; set; }

        public ICommand NavToPatients { get; set; }
        public ICommand NavToHome { get; set; }
        public ICommand NavToDentists { get; set; }
        public ICommand NavToOrders { get; set; }
        public ICommand NavToActivities { get; set; }

        public ICommand DisplayPatient { get; set; }

        public void ViewPatient(object obj)
        {
            App.Navigation.Navigate(new PatientPage((int)obj));
        }

        private void HandleDeletePatient(object obj)
        {
            if (this.SelectedPatient == null)
            // не сте избрали поръцхка ..изберете поръ4ка пържо // не е няма избрана поръцхка // поръчката е изтрита//невалидни данни//въведените данни са невалидни //добавяне на пациент// пациент//
            {
                MessageBox.Show("Не е избран пациент.", "Пациенти", MessageBoxButton.OK);
                return;
            } 
            this.patientService.DeletePatient(this.SelectedPatient.Id);
            this.Patients.Remove(this.SelectedPatient);
            this.OnPropertyChanged("Patients");
            MessageBox.Show("Пациентът е изтрит.", "Пациенти", MessageBoxButton.OK);
        }

        private void HandleNavigateToAddPatient(object obj)
        {
            App.Navigation.Navigate(new AddPatientPage());
        }



        private void HandleNavToActivities(object obj)
        {
            App.Navigation.Navigate(new ActivitiesPage());
        }
        private void HandleNavToOrders(object obj)
        {
            App.Navigation.Navigate(new OrdersPage());
        }
        private void HandleNavToDentists(object obj)
        {
            App.Navigation.Navigate(new DentistsPage());
        }
        private void HandleNavToPatients(object obj)
        {
            App.Navigation.Navigate(new PatientsPage());
        }
        private void HandleNavToHome(object obj)
        {
            App.Navigation.Navigate(new HomePage());
        }


        private void HandleDisplayPatient(object obj)
        {
            if (this.SelectedPatient == null)
            {
                MessageBox.Show("Не е избран пациент.", "Пациенти", MessageBoxButton.OK);
                return;
            }
            
            this.dentistService = new DentistService();
            var databaseDentist = dentistService.GetDentistById(this.SelectedPatient.DentistId);
            this.SelectedPatient.DentistForDisplaying = databaseDentist.Name + " " + databaseDentist.MiddleName + " " + databaseDentist.LastName;

            this.SelectedPatient.AgeForDisplaying = this.SelectedPatient.Age + " г.";

            OnPropertyChanged("SelectedPatient");
        }

    }
}
