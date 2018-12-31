using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_EF_employee.Models
{
    public class Mydbcontext:DbContext
    {
        public Mydbcontext() : base("constr")
        {
        }
        public DbSet<EmployeeModel> Employees { get; set; }

        public DbSet<EmployeeLeaves> EmployeeLeaves { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeModel>().MapToStoredProcedures();
            modelBuilder.Entity<EmployeeLeaves>().MapToStoredProcedures();
        }

    }
}