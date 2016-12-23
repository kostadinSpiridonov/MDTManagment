using MDTManagment.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MDTManagment.Models;
using MDTManagment.Views.Activities;
using System.Windows;
using MDTManagment.Services;

namespace MDTManagment.ViewModels.Activities
{
    public class ActivitiesViewModel : BaseViewModel
    {
        private ActivityService activityService { get; set; }

        public ObservableCollection<Activity> Activities { get; set; }

        public Activity SelectedActivity { get; set; }



        public ActivitiesViewModel()
        {
            this.activityService = new ActivityService();

            var databaseActivities = this.activityService.GetAllActivities();

            this.Activities = new ObservableCollection<Activity>(databaseActivities);

            this.DeleteActivity = new RelayCommand(this.HandleDeleteActivity);

            this.NavigateToAddActivity = new RelayCommand(this.HandleNavigateToAddActivity);
        }



        public ICommand DeleteActivity { get; set; }

        public ICommand NavigateToAddActivity { get; set; }


        private void HandleDeleteActivity(object obj)
        {
            if (this.SelectedActivity == null)
            {
                MessageBox.Show("No activity selected.", "Activities status", MessageBoxButton.OK);
                return;
            }
            this.activityService.DeleteActivity(this.SelectedActivity.Id);
            this.Activities.Remove(this.SelectedActivity);
            this.OnPropertyChanged("Activities");
            MessageBox.Show("Activity deleted.", "Activities status", MessageBoxButton.OK);
        }


        private void HandleNavigateToAddActivity(object obj)
        {
            App.Navigation.Navigate(new AddActivityPage());
        }



    }
}
