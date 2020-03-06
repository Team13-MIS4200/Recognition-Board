using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Recognition_Board.Models; // This is needed to access the models
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;


namespace Recognition_Board.DAL
{
    public class RecognitionBoardContext : DbContext
    {
        public RecognitionBoardContext() : base  ("name=DefaultConnection")
        {
            // this method is a 'constructor' and is called when a new context is created
            // the base attribute says which connection string to use
            AutomaticMigrationDataLossAllowed = true;
        }
        // Include each object here. The value inside <> is the name of the class,
        // the value outside should generally be the plural of the class name
        // and is the name used to reference the entity in code
        public DbSet <EmployeeDetails> Employees { get; set; }
        public DbSet <Recognitions> Recognitions { get; set; }
        public bool AutomaticMigrationDataLossAllowed { get; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}