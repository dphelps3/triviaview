using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TriviaLink.Data;
using TriviaLink.Models;

namespace TriviaLink.Controllers
{
    public class SlidesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SlidesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Slides
        public async Task<IActionResult> Index()
        {
            try
            {
                if (_context.Slide != null)
                {
                    var results = await _context.Slide.ToListAsync();
                    return View(results);
                }
                else
                {
                    return Problem("Entity set 'ApplicationDbContext.Slide'  is null.");
                }
            }
            catch(Exception ex)
            {
                var errorMessage = ex.Message;
                return Problem(errorMessage);
            }
            

            return _context.Slide != null ?
                        View(await _context.Slide.ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.Slide'  is null.");
        }

        // GET: Slides/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Slide == null)
            {
                return NotFound();
            }

            var slide = await _context.Slide
                .FirstOrDefaultAsync(m => m.SlideID == id);
            if (slide == null)
            {
                return NotFound();
            }

            return View(slide);
        }

        // GET: Slides/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Slides/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SlideID,SlideImage,Question,Answer,GameID")] Slide slide)
        {
            if (ModelState.IsValid)
            {
                _context.Add(slide);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(slide);
        }

        // GET: Slides/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Slide == null)
            {
                return NotFound();
            }

            var slide = await _context.Slide.FindAsync(id);
            if (slide == null)
            {
                return NotFound();
            }
            return View(slide);
        }

        // POST: Slides/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SlideID,SlideImage,Question,Answer,GameID")] Slide slide)
        {
            if (id != slide.SlideID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(slide);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SlideExists(slide.SlideID))
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
            return View(slide);
        }

        // GET: Slides/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Slide == null)
            {
                return NotFound();
            }

            var slide = await _context.Slide
                .FirstOrDefaultAsync(m => m.SlideID == id);
            if (slide == null)
            {
                return NotFound();
            }

            return View(slide);
        }

        // POST: Slides/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Slide == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Slide'  is null.");
            }
            var slide = await _context.Slide.FindAsync(id);
            if (slide != null)
            {
                _context.Slide.Remove(slide);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SlideExists(int id)
        {
            return (_context.Slide?.Any(e => e.SlideID == id)).GetValueOrDefault();
        }
    }
}
