using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace firstcode.Models
{
    public class mobilestore
    {
        [Key]
        public int Id { get; set; }
        public string Modname { get; set; }
        public int Price { get; set; }
    }
}