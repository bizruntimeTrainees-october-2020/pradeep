using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using crudop.Controllers;
using Microsoft.EntityFrameworkCore;

namespace crudop.Models
{
    public class Empdbcontext:DbContext
    {
        public Empdbcontext(DbContextOptions<Empdbcontext>options):base(options)
        {

        }
        public DbSet<Employeecontroller> emptable1 { get; set; }
    }
}
