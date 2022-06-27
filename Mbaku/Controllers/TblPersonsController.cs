using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Mbaku.Entities;

namespace Mbaku.Controllers
{
    public class TblPersonsController : Controller
    {
        private readonly PersonContext _context;

        public TblPersonsController(PersonContext context)
        {
            _context = context;
        }

        // GET: TblPersons
        public async Task<IActionResult> Index()
        {
            var personContext = _context.TblPeople.Include(t => t.Gender);
            return View(await personContext.ToListAsync());
        }

        // GET: TblPersons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblPerson = await _context.TblPeople
                .Include(t => t.Gender)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblPerson == null)
            {
                return NotFound();
            }

            return View(tblPerson);
        }

        // GET: TblPersons/Create
        public IActionResult Create()
        {
            ViewData["GenderId"] = new SelectList(_context.TblGenders, "Id", "Gender");
            return View();
        }

        // POST: TblPersons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Email,GenderId")] TblPerson tblPerson)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblPerson);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GenderId"] = new SelectList(_context.TblGenders, "Id", "Gender", tblPerson.GenderId);
            return View(tblPerson);
        }

        // GET: TblPersons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblPerson = await _context.TblPeople.FindAsync(id);
            if (tblPerson == null)
            {
                return NotFound();
            }
            ViewData["GenderId"] = new SelectList(_context.TblGenders, "Id", "Gender", tblPerson.GenderId);
            return View(tblPerson);
        }

        // POST: TblPersons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Email,GenderId")] TblPerson tblPerson)
        {
            if (id != tblPerson.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblPerson);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblPersonExists(tblPerson.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["GenderId"] = new SelectList(_context.TblGenders, "Id", "Gender", tblPerson.GenderId);
            return View(tblPerson);
        }

        // GET: TblPersons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblPerson = await _context.TblPeople
                .Include(t => t.Gender)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblPerson == null)
            {
                return NotFound();
            }

            return View(tblPerson);
        }

        // POST: TblPersons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblPerson = await _context.TblPeople.FindAsync(id);
            _context.TblPeople.Remove(tblPerson);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblPersonExists(int id)
        {
            return _context.TblPeople.Any(e => e.Id == id);
        }
    }
}
