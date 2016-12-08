using MDTManagment.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDTManagment.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {

        }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Dentist> Dentists { get; set; }

        public DbSet<Patient> Patients { get; set; }

        public DbSet<Ingredient> Ingredient { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>().HasMany(x => x.DeclaredIngredients);

            base.OnModelCreating(modelBuilder);
        }
    }
}
