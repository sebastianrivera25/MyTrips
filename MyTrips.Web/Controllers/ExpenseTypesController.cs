﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyTrips.Web.Data;
using MyTrips.Web.Data.Entities;
using System;
using System.Threading.Tasks;

namespace MyTrips.Web.Controllers
{
    public class ExpenseTypesController : Controller
    {
        private readonly DataContext _context;

        public ExpenseTypesController(DataContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.ExpenseTypes.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ExpenseTypeEntity expenseTypeEntity = await _context.ExpenseTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (expenseTypeEntity == null)
            {
                return NotFound();
            }

            return View(expenseTypeEntity);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ExpenseTypeEntity expenseTypeEntity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(expenseTypeEntity);
                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    if (ex.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, $"Already exists  type: {expenseTypeEntity.Name}.");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, ex.InnerException.Message);
                    }

                }
            }
            return View(expenseTypeEntity);
        }

        // GET: ExpenseTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ExpenseTypeEntity expenseTypeEntity = await _context.ExpenseTypes.FindAsync(id);
            if (expenseTypeEntity == null)
            {
                return NotFound();
            }
            return View(expenseTypeEntity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ExpenseTypeEntity expenseTypeEntity)
        {
            if (id != expenseTypeEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(expenseTypeEntity);
                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    if (ex.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, $"Already exists  type: {expenseTypeEntity.Name}.");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, ex.InnerException.Message);
                    }

                }
            }
            return View(expenseTypeEntity);
        }

        // GET: ExpenseTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ExpenseTypeEntity expenseTypeEntity = await _context.ExpenseTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (expenseTypeEntity == null)
            {
                return NotFound();
            }
            _context.ExpenseTypes.Remove(expenseTypeEntity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}

