using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BasicApp1.Models;

namespace BasicApp1.Controllers
{
    public class PassController : Controller
    {
        private readonly BasicApp1Context _context;

        public PassController(BasicApp1Context context)
        {
            _context = context;    
        }

        // GET: Pass
        public async Task<IActionResult> Index()
        {
            return View(await _context.Class.ToListAsync());
        }

        // GET: Pass/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @class = await _context.Class
                .SingleOrDefaultAsync(m => m.ID == id);
            if (@class == null)
            {
                return NotFound();
            }

            return View(@class);
        }

        // GET: Pass/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pass/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,FirstName,LastName,HouseHoldNumber,StreetAdress,City_State,ZipCode,Email")] Class @class)
        {
            if (ModelState.IsValid)
            {
                _context.Add(@class);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(@class);
        }

        // GET: Pass/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @class = await _context.Class.SingleOrDefaultAsync(m => m.ID == id);
            if (@class == null)
            {
                return NotFound();
            }
            return View(@class);
        }

        // POST: Pass/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,FirstName,LastName,HouseHoldNumber,StreetAdress,City_State,ZipCode,Email")] Class @class)
        {
            if (id != @class.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(@class);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClassExists(@class.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(@class);
        }

        // GET: Pass/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @class = await _context.Class
                .SingleOrDefaultAsync(m => m.ID == id);
            if (@class == null)
            {
                return NotFound();
            }

            return View(@class);
        }

        // POST: Pass/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var @class = await _context.Class.SingleOrDefaultAsync(m => m.ID == id);
            _context.Class.Remove(@class);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ClassExists(int id)
        {
            return _context.Class.Any(e => e.ID == id);
        }
    }
}
