using MDTManagment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDTManagment.Services
{
    public class ActivityService : BaseService
    {
         public Activity GetActivityById(int activityId)                                  //not used for the moment
         {                                                                                //
             var activity = this.database.Activities.First(x => x.Id == activityId);      //this is to be used for ActivitYviewModel and ActivitYpage
             return activity;                                                             //
         }                                                                                //
    
        public List<Activity> GetAllActivities()
        {
            var activities = this.database.Activities;
            return activities.ToList();
        }

        public void DeleteActivity(int activityId)
        {
            var activity = this.database.Activities.First(x => x.Id == activityId);
            if (activity == null)
            {
                return;
            }

            this.database.Activities.Remove(activity);
            this.database.SaveChanges();
        }


        //TODO: Validation. = in the moment it thows exception .. it should just type in red above the textbox of EstimatedDate - "Invalid insert."
        public void AddActivity(Activity activity)
        {
            this.database.Activities.Add(activity);
            this.database.SaveChanges();
        }
    }
}
