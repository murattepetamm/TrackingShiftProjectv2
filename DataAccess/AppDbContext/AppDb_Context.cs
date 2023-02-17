using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.AppDbContext
{
    public class AppDb_Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server = DESKTOP-6PV2PRJ; Database = TrackingShiftDb; Trusted_Connection = true");
        }



        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Assignment>()
        //          .HasOne<Employee>(s => s.Employee)
        //          .WithOne(ad => ad.Assignment)
        //          .HasForeignKey<Employee>(ad => ad.AssignmentId);
        //}
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Shift> Shifts { get; set; }
        public DbSet<ShiftOfTeam> ShiftOfTeams { get; set; }
        public DbSet<TeamsOfEmployee> TeamsOfEmployees { get; set; }
        public DbSet<Title> Titles { get; set; }

    }
}
