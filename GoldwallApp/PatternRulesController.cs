using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GoldwallApp.Data;
using GoldwallApp.Models;

namespace GoldwallApp
{
    public class PatternRulesController : Controller
    {
        private readonly AppDbContext _context;

        public PatternRulesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: PatternRules
        public async Task<IActionResult> Index()
        {
            return View(await _context.PatternRules.ToListAsync());
        }

        // GET: PatternRules/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patternRule = await _context.PatternRules
                .FirstOrDefaultAsync(m => m.PatternRuleId == id);
            if (patternRule == null)
            {
                return NotFound();
            }

            return View(patternRule);
        }

        // GET: PatternRules/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PatternRules/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PatternRuleId,PatternId,FieldName,Operator,Value1,Value2")] PatternRule patternRule)
        {
            if (ModelState.IsValid)
            {
                _context.Add(patternRule);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(patternRule);
        }

        // GET: PatternRules/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patternRule = await _context.PatternRules.FindAsync(id);
            if (patternRule == null)
            {
                return NotFound();
            }
            return View(patternRule);
        }

        // POST: PatternRules/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PatternRuleId,PatternId,FieldName,Operator,Value1,Value2")] PatternRule patternRule)
        {
            if (id != patternRule.PatternRuleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(patternRule);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PatternRuleExists(patternRule.PatternRuleId))
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
            return View(patternRule);
        }

        // GET: PatternRules/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patternRule = await _context.PatternRules
                .FirstOrDefaultAsync(m => m.PatternRuleId == id);
            if (patternRule == null)
            {
                return NotFound();
            }

            return View(patternRule);
        }

        // POST: PatternRules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var patternRule = await _context.PatternRules.FindAsync(id);
            if (patternRule != null)
            {
                _context.PatternRules.Remove(patternRule);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PatternRuleExists(int id)
        {
            return _context.PatternRules.Any(e => e.PatternRuleId == id);
        }
    }
}
