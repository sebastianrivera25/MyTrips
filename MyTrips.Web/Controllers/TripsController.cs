using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyTrips.Web.Data;
using MyTrips.Web.Data.Entities;

namespace MyTrips.Web.Controllers
{
    public class TripsController : Controller
    {
        private readonly DataContext _context;

        public TripsController(DataContext context)
        {
            _context = context;
        }

        // GET: Trips
        public async Task<IActionResult> Index()
        {
            return View(await _context.Trips.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TripEntity TripEntity = await _context.Trips
                 .FirstOrDefaultAsync(m => m.Id == id);
            if (TripEntity == null)
            {
                return NotFound();
            }

            return View(TripEntity);
        }

         public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,StartDate,EndDate")] TripEntity tripEntity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tripEntity);
                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    if (ex.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, $"Already exists  type: {tripEntity.Name}.");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, ex.InnerException.Message);
                    }

                }
            }
            return View(tripEntity);
        }

        // GET: Trips/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tripEntity = await _context.Trips.FindAsync(id);
            if (tripEntity == null)
            {
                return NotFound();
            }
            return View(tripEntity);
        }

        // POST: Trips/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, TripEntity tripEntity)
        {
            if (id != tripEntity.Id)
            {
                return NotFound();
            }
              _context.Add(tripEntity);
            try
            {
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                if (ex.InnerException.Message.Contains("duplicate"))
                {
                    ModelState.AddModelError(string.Empty, $"Already exists  type: {tripEntity.Name}.");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, ex.InnerException.Message);
                }

            }
        
            return View(tripEntity);
    }

    // GET: Trips/Delete/5
    public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TripEntity TripEntity = await _context.Trips
                .FirstOrDefaultAsync(m => m.Id == id);
            if (TripEntity == null)
            {
                return NotFound();
            }
            _context.Trips.Remove(TripEntity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}