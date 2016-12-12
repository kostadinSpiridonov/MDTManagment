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

            this.NewActivity = new Activity();
        }



        public ICommand AddActivity { get; set; }


        private void HandleAddActivity(object obj)
        {
            this.activityService.AddActivity(this.NewActivity);
            MessageBox.Show("New Activity Added.", "Activities Status", MessageBoxButton.OK);
            App.Navigation.Navigate(new ActivitiesPage());
        }

    }
}
