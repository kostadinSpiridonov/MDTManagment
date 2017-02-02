using MDTManagment.Commands;
using MDTManagment.Models;
using MDTManagment.Services;
using MDTManagment.Views.Activities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MDTManagment.ViewModels.Activities
{
    public class AddActivityViewModel
    {
        private ActivityService activityService { get; set; }

        public Activity NewActivity { get; set; } 


        public AddActivityViewModel()
        {
            this.activityService = new ActivityService();

            this.AddActivity = new RelayCommand(this.HandleAddActivity);
            this.NavigateToActivitiesPage = new RelayCommand(this.HandleNavigateToActivitiesPage);

            this.NewActivity = new Activity();
        }

        

        public ICommand AddActivity { get; set; }

        public ICommand NavigateToActivitiesPage { get; set; }



        private void HandleAddActivity(object obj)
        {
            if (this.NewActivity.Description == null    ||
                this.NewActivity.Price < 0     ||
                this.NewActivity.EstimatedDate.Year < DateTime.Today.Year || 
                this.NewActivity.EstimatedDate.Month < DateTime.Today.Month ||
                this.NewActivity.EstimatedDate.Date < DateTime.Today.Date)
            {
                MessageBox.Show("Invalid input.", "Activities status", MessageBoxButton.OK);
                return;
            }
            this.activityService.AddActivity(this.NewActivity);
            MessageBox.Show("New activity added.", "Activities status", MessageBoxButton.OK);
            App.Navigation.Navigate(new ActivitiesPage());
        }


        private void HandleNavigateToActivitiesPage(object obj)
        {
            App.Navigation.Navigate(new ActivitiesPage());
        }

    }
}
