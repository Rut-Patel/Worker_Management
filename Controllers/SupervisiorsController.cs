using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//Make sure you have the following imports
using Microsoft.AspNetCore.Identity;
using Worker_Management.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authentication;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace Worker_Management.Controllers
{
    public class SupervisiorsController : Controller
    {
        private readonly WorkerContext _context;

        public SupervisiorsController(WorkerContext context)
        {
            _context = context;
        }

        // GET: Supervisiors
        [Authorize]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Supervisiors.ToListAsync());
        }

        // GET: Supervisiors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supervisior = await _context.Supervisiors
                .FirstOrDefaultAsync(m => m.supervisiorID == id);
            if (supervisior == null)
            {
                return NotFound();
            }

            return View(supervisior);
        }

        // GET: Supervisiors/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Supervisiors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create([Bind("supervisiorID,first_name,last_name,department")] Supervisior supervisior)
        {
            if (ModelState.IsValid)
            {
                _context.Add(supervisior);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(supervisior);
        }

        // GET: Supervisiors/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supervisior = await _context.Supervisiors.FindAsync(id);
            if (supervisior == null)
            {
                return NotFound();
            }
            return View(supervisior);
        }

        // POST: Supervisiors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(int id, [Bind("supervisiorID,first_name,last_name,department")] Supervisior supervisior)
        {
            if (id != supervisior.supervisiorID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(supervisior);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SupervisiorExists(supervisior.supervisiorID))
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
            return View(supervisior);
        }

        // GET: Supervisiors/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supervisior = await _context.Supervisiors
                .FirstOrDefaultAsync(m => m.supervisiorID == id);
            if (supervisior == null)
            {
                return NotFound();
            }

            return View(supervisior);
        }

        // POST: Supervisiors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var supervisior = await _context.Supervisiors.FindAsync(id);
            _context.Supervisiors.Remove(supervisior);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SupervisiorExists(int id)
        {
            return _context.Supervisiors.Any(e => e.supervisiorID == id);
        }
    }
}
