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
    public class RegistredUsersController : Controller
    {
        private readonly BibliotecaContext _context;
        private IRepositoryWrapper repo;

        public RegistredUsersController(IRepositoryWrapper repo)
        {
            repo = repo;
        }

        // GET: RegistredUsers
        public async Task<IActionResult> Index()
        {
            var RegistredUser = repo.RegistredUser.FindAll();
            return View(RegistredUser);
        }

        // GET: RegistredUsers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registredUser = repo.RegistredUser.FindByCondition(t => t.ID == id);
           
            if (registredUser == null)
            {
                return NotFound();
            }

            return View(registredUser);
        }

        // GET: RegistredUsers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RegistredUsers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,FirstName,LastName,Email,Password")] RegistredUser registredUser)
        {
            if (ModelState.IsValid)
            {
                repo.RegistredUser.Create(registredUser);
                repo.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(registredUser);
        }

        // GET: RegistredUsers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registredUser = repo.RegistredUser.FindByCondition(t => t.ID == id);
            if (registredUser == null)
            {
                return NotFound();
            }
            return View(registredUser);
        }

        // POST: RegistredUsers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,FirstName,LastName,Email,Password")] RegistredUser registredUser)
        {
            if (id != registredUser.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    repo.RegistredUser.Update(registredUser);
                    repo.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegistredUserExists(registredUser.ID))
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
            return View(registredUser);
        }

        // GET: RegistredUsers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registredUser = repo.RegistredUser.FindByCondition(t => t.ID == id);
            if (registredUser == null)
            {
                return NotFound();
            }

            return View(registredUser);
        }

        // POST: RegistredUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var RegistredUser = repo.RegistredUser.FindByCondition(t => t.ID == id);
            repo.RegistredUser.Delete(RegistredUser);
            repo.Save();
            return RedirectToAction(nameof(Index));
        }

        private bool RegistredUserExists(int id)
        {
            bool found = repo.RegistredUser.Exists(id);
            return found;
        }
    }
}
