using Case_study.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Case_study.DAL
{
    public class Case_studyContext:DbContext
    {
        public Case_studyContext() : base("DefaultConnection")
        {

        }
        public DbSet<Flight> Flights { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}