using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PersonalTrainerWeb.Data;
using PersonalTrainerWeb.Models;

namespace PersonalTrainerWeb.Controllers
{
    public class SuplimentsController : Controller
    {
        private readonly PersonalTrainerContext _context;

        public SuplimentsController(PersonalTrainerContext context)
        {
            _context = context;
        }

        // GET: Supliments
        public async Task<IActionResult> Index()
        {
            return View(await _context.Supliment.ToListAsync());
        }

        // GET: Supliments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supliment = await _context.Supliment
                .FirstOrDefaultAsync(m => m.ID == id);
            if (supliment == null)
            {
                return NotFound();
            }

            return View(supliment);
        }

        // GET: Supliments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Supliments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Denumire,Cantitate,Price")] Supliment supliment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(supliment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(supliment);
        }

        // GET: Supliments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supliment = await _context.Supliment.FindAsync(id);
            if (supliment == null)
            {
                return NotFound();
            }
            return View(supliment);
        }

        // POST: Supliments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Denumire,Cantitate,Price")] Supliment supliment)
        {
            if (id != supliment.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(supliment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SuplimentExists(supliment.ID))
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
            return View(supliment);
        }

        // GET: Supliments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supliment = await _context.Supliment
                .FirstOrDefaultAsync(m => m.ID == id);
            if (supliment == null)
            {
                return NotFound();
            }

            return View(supliment);
        }

        // POST: Supliments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var supliment = await _context.Supliment.FindAsync(id);
            _context.Supliment.Remove(supliment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SuplimentExists(int id)
        {
            return _context.Supliment.Any(e => e.ID == id);
        }
    }
}
