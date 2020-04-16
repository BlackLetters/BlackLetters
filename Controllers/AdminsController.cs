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
    public class AdminsController : Controller
    {
        private readonly BibliotecaContext _context;
        private IRepositoryWrapper repo;

        public AdminsController(IRepositoryWrapper repo)
        {
            repo = repo;
        }

        // GET: Admins
        public async Task<IActionResult> Index()
        {
            //return View(await _context.Admins.ToListAsync());
            var admin = repo.Admin.FindAll();
            return View(admin);
        }

        // GET: Admins/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var admin = await _context.Admins
            //    .FirstOrDefaultAsync(m => m.ID == id);
            var admin = repo.Admin.FindByCondition(t => t.ID == id);

            if (admin == null)
            {
                return NotFound();
            }

            return View(admin);
        }

        // GET: Admins/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admins/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,FirstName,LastName,Email,Password")] Admin admin)
        {
            if (ModelState.IsValid)
            {
                //admin.ID = Guid.NewGuid();
                //_context.Add(admin);
                //await _context.SaveChangesAsync();
                repo.Admin.Create(admin);
                repo.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(admin);
        }

        // GET: Admins/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var admin = await _context.Admins.FindAsync(id);
            var admin = repo.Admin.FindByCondition(t => t.ID == id);
            if (admin == null)
            {
                return NotFound();
            }
            return View(admin);
        }

        // POST: Admins/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,FirstName,LastName,Email,Password")] Admin admin)
        {
            if (id != admin.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //_context.Update(admin);
                    //await _context.SaveChangesAsync();
                    repo.Admin.Update(admin);
                    repo.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdminExists(admin.ID))
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
            return View(admin);
        }

        // GET: Admins/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var admin = await _context.Admins
            //    .FirstOrDefaultAsync(m => m.ID == id);
            var admin = repo.Admin.FindByCondition(t => t.ID == id);

            if (admin == null)
            {
                return NotFound();
            }

            return View(admin);
        }

        // POST: Admins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            //var admin = await _context.Admins.FindAsync(id);
            //_context.Admins.Remove(admin);
            //await _context.SaveChangesAsync();
            var admin = repo.Admin.FindByCondition(t => t.ID == id);
            repo.Admin.Delete(admin);
            repo.Save();
            return RedirectToAction(nameof(Index));
        }

        private bool AdminExists(int id)
        {
            //return _context.Admins.Any(e => e.ID == id);
            bool found = repo.Admin.Exists(id);
            return found;
        }
    }
}
