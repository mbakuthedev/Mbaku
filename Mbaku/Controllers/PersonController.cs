using Mbaku.Entities;
using Mbaku.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Mbaku.Controllers
{
   
    public class PersonController : Controller
    {
        IPersonRepository repo;
        public PersonController(IPersonRepository repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public IActionResult GetPerson(int Id)
        {
           var person = repo.GetPerson(Id);
            return View(person);
        }
        public IActionResult Index(TblPerson person)
        {
           
            return View(repo.Index(person));
        }
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        
        
        public IActionResult Create([Bind("Id,Name,Email")] TblPerson newPerson)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    repo.Create(newPerson);
                    return View("GetPerson");
                }
            }
            catch (Exception)
            {

                ModelState.AddModelError("", "Unable to add record");
            }
              return View (newPerson);
        }
        //GET Id
        public IActionResult Update(int Id)
        {
            
            return View (repo.Update(Id));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(TblPerson UpdatedPerson)
        {
            if (ModelState.IsValid)
            {
                repo.Update(UpdatedPerson);

            }
            return View("GetPerson", UpdatedPerson);
        }
        public IActionResult Delete(int? Id)
        {
            
            return View(repo.Delete(Id));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public IActionResult Delete(int Id)
        {
            try
            {
                repo.Delete(Id);
            }
            catch (Exception)
            {

               
            }
           return RedirectToAction("Index");
        }
    }
}
