using MDTManagment.Data;
using MDTManagment.Data.Migrations;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;

namespace MDTManagment
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static NavigationService Navigation { get; set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            Database.SetInitializer(
                     new MigrateDatabaseToLatestVersion<ApplicationDbContext, Configuration>()
                     );
        }
    }
}
