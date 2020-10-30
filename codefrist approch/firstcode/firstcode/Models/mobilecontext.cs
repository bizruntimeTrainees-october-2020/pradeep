using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace firstcode.Models
{
    public class mobilecontext :DbContext
    {
        public DbSet<mobilestore>mobilestores{ get; set; }

    }
}