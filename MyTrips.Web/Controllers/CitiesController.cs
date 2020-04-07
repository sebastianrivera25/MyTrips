using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyTrips.Web.Data;
using MyTrips.Web.Data.Entities;
using System;
using System.Threading.Tasks;

namespace MyTrips.Web.Controllers
{
    public class CitiesController : Controller
    {
        private readonly DataContext _context;

        public CitiesController(DataContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Cities.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CityEntity cityEntity = await _context.Cities
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cityEntity == null)
            {
                return NotFound();
            }

            return View(cityEntity);
        }

        // GET: Cities/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CityEntity cityEntity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cityEntity);
                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    if (ex.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, $"Already exists: {cityEntity.Name}.");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, ex.InnerException.Message);
                    }

                }
            }
            return View(cityEntity);
        }

        // GET: Cities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CityEntity cityEntity = await _context.Cities.FindAsync(id);
            if (cityEntity == null)
            {
                return NotFound();
            }
            return View(cityEntity);
        }

        // POST: Cities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CityEntity cityEntity)
        {
            if (id != cityEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(cityEntity);
                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    if (ex.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, $"Already exists  type: {cityEntity.Name}.");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, ex.InnerException.Message);
                    }

                }
            }
            return View(cityEntity);
        }


        // GET: Cities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CityEntity cityEntity = await _context.Cities
            .FirstOrDefaultAsync(m => m.Id == id);
            if (cityEntity == null)
            {
                return NotFound();
            }

            _context.Cities.Remove(cityEntity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
