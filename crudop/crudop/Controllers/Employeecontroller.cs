using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using crudop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace crudop.Controllers
{
    public class Employeecontroller : Controller
    {
        private readonly Empdbcontext  _db;
        public Employeecontroller(Empdbcontext db)
        {
            _db = db;
        }
        
        public IActionResult Index()
        {
            var displaydata = _db.emptable1.ToList();
            return View(displaydata);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        
        public async Task <IActionResult>Create(EmployeeInfo nec)
        {
            if (ModelState.IsValid)
            {
                _db.Add(nec);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(nec);

        }
        public async Task<IActionResult>Edit(int?id)
        {
            if(id==null)
            {
                return RedirectToAction("Index");

            }
            var getdetails = await _db.emptable1.FindAsync(id);
            return View(getdetails);

        }
        [HttpPost]
        public async Task <IActionResult>Edit(EmployeeInfo nc)
        {
            if (ModelState.IsValid)
            {
                _db.Update(nc);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(nc);
        }
        public async Task<IActionResult>Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");

            }
            var getdetails = await _db.emptable1.FindAsync(id);
            return View(getdetails);

        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");

            }
            var getdetails = await _db.emptable1.FindAsync(id);
            return View(getdetails);

        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var getdetails = await _db.emptable1.FindAsync(id);
            _db.emptable1.Remove(getdetails);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");

        }
    }
}
