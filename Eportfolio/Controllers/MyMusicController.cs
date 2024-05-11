using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Eportfolio.Data;
using Eportfolio.Models;

namespace Eportfolio.Controllers
{
    public class MyMusicController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MyMusicController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MyMusics
        public async Task<IActionResult> Index()
        {
            var myMusicList = await _context.MyMusic.ToListAsync();
            return View(myMusicList);
        }

        // GET: MyMusics/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var myMusic = await _context.MyMusic.FirstOrDefaultAsync(m => m.Id == id);
            if (myMusic == null)
            {
                return NotFound();
            }

            return View(myMusic);
        }

        // GET: MyMusics/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: MyMusics/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,YouTubeLink,ReleaseDate")] MyMusic myMusic)
        {
            if (ModelState.IsValid)
            {
                _context.Add(myMusic);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(myMusic);
        }

        // GET: MyMusics/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var myMusic = await _context.MyMusic.FindAsync(id);
            if (myMusic == null)
            {
                return NotFound();
            }
            return View(myMusic);
        }

        // POST: MyMusics/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,YouTubeLink,ReleaseDate")] MyMusic myMusic)
        {
            if (id != myMusic.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(myMusic);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MyMusicExists(myMusic.Id))
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
            return View(myMusic);
        }

        // GET: MyMusics/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var myMusic = await _context.MyMusic.FirstOrDefaultAsync(m => m.Id == id);
            if (myMusic == null)
            {
                return NotFound();
            }

            return View(myMusic);
        }

        // POST: MyMusics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var myMusic = await _context.MyMusic.FindAsync(id);
            if (myMusic != null)
            {
                _context.MyMusic.Remove(myMusic);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MyMusicExists(int id)
        {
            return _context.MyMusic.Any(e => e.Id == id);
        }
    }
}


