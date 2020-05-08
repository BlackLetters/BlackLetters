using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Biblioteca.Context;
using Biblioteca.Models;
using Biblioteca.Services.Interfaces;

namespace Biblioteca.Controllers
{
    public class RegistredUserSubsController : Controller
    {
        private readonly BibliotecaContext _context;
        private IRepositoryWrapper repo;

        public RegistredUserSubsController(BibliotecaContext context)
        {
            _context = context;
        }

        // GET: RegistredUserSubs
        public async Task<IActionResult> Index()
        {
            return View(await _context.RegistredUserSubs.ToListAsync());
        }

        // GET: RegistredUserSubs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // var registredUserSub = await _context.RegistredUserSubs
            //   .FirstOrDefaultAsync(m => m.ID == id);
            var registredUserSub = repo.RegistredUserSub.FindByCondition(t => t.ID == id);
            if (registredUserSub == null)
            {
                return NotFound();
            }

            return View(registredUserSub);
        }

        // GET: RegistredUserSubs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RegistredUserSubs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,No")] RegistredUserSub registredUserSub)
        {
            if (ModelState.IsValid)
            {
                // _context.Add(registredUserSub);
                // await _context.SaveChangesAsync();
                repo.RegistredUserSub.Create(registredUserSub);
                repo.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(registredUserSub);
        }

        // GET: RegistredUserSubs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // var registredUserSub = await _context.RegistredUserSubs.FindAsync(id);
            var registredUserSub = repo.RegistredUserSub.FindByCondition(t => t.ID == id);
            if (registredUserSub == null)
            {
                return NotFound();
            }
            return View(registredUserSub);
        }

        // POST: RegistredUserSubs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,No")] RegistredUserSub registredUserSub)
        {
            if (id != registredUserSub.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //_context.Update(registredUserSub);
                    //await _context.SaveChangesAsync();
                    repo.RegistredUserSub.Update(registredUserSub);
                    repo.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegistredUserSubExists(registredUserSub.ID))
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
            return View(registredUserSub);
        }

        // GET: RegistredUserSubs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // var registredUserSub = await _context.RegistredUserSubs
            //     .FirstOrDefaultAsync(m => m.ID == id);
            var registredUserSub = repo.RegistredUserSub.FindByCondition(t => t.ID == id);
            if (registredUserSub == null)
            {
                return NotFound();
            }

            return View(registredUserSub);
        }

        // POST: RegistredUserSubs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            // var registredUserSub = await _context.RegistredUserSubs.FindAsync(id);
            // _context.RegistredUserSubs.Remove(registredUserSub);
            // await _context.SaveChangesAsync();
            var registredusersub = repo.RegistredUserSub.FindByCondition(t => t.ID == id);
            repo.RegistredUserSub.Delete(registredusersub);
            repo.Save();
            return RedirectToAction(nameof(Index));
        }

        private bool RegistredUserSubExists(int id)
        {
            // return _context.RegistredUserSubs.Any(e => e.ID == id);
            bool found = repo.RegistredUserSub.Exists(id);
            return found;
        }
    }
}
