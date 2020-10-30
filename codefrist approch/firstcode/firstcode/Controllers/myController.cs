using firstcode.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using firstcode.Models;

namespace firstcode.Controllers
{
    public class myController : Controller
    {
        mobilecontext db = new mobilecontext();
        // GET: my
        public ActionResult Index()
        {
            var data = db.mobilestores.ToList();
            return View(data);
        }
    }
}