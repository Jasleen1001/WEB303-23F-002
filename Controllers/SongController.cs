using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Jasleen.Models;

namespace Jasleen.Controllers
{
    public class SongController : Controller
    {
        private readonly MvcSongContext _context;

        public SongController(MvcSongContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(string songGenre, string searchString, string sortOrder)
        {
            // Use LINQ to get list of genres.
            IQueryable<string> genreQuery = from m in _context.Song
                                            orderby m.Genre
                                            select m.Genre;
            var songs = from m in _context.Song
                        select m;

            if (!string.IsNullOrEmpty(searchString))
            {
                songs = songs.Where(s => s.Title!.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(songGenre))
            {
                songs = songs.Where(x => x.Genre == songGenre);
            }

            ViewData["SearchTitle"] = searchString;
            ViewData["SearchGenre"] = songGenre;

            ViewData["TitleSort"] = String.IsNullOrEmpty(sortOrder) ? "title_desc" : "";
            ViewData["DateSort"] = sortOrder == "releaseDate" ? "releaseDate_desc" : "releaseDate";
            ViewData["GenreSort"] = sortOrder == "genre" ? "genre_desc" : "genre";
            ViewData["PriceSort"] = sortOrder == "price" ? "price_desc" : "price";
            ViewData["RatingSort"] = sortOrder == "rating" ? "rating_desc" : "rating";

            switch (sortOrder)
            {
                case "title_desc":
                    songs = songs = songs.OrderByDescending(m => m.Title);
                    break;
                case "releaseDate":
                    {
                        songs = songs.OrderBy(m => m.ReleaseDate);
                        break;
                    }
                case "releaseDate_desc":
                    {
                        songs = songs.OrderByDescending(m => m.ReleaseDate);
                        break;
                    }

                case "genre":
                    {
                        songs = songs.OrderBy(m => m.Genre);
                        break;
                    }

                case "genre_desc":
                    {
                        songs = songs.OrderByDescending(m => m.Genre);
                        break;
                    }
                case "price":
                    {
                        songs = songs.OrderBy(m => (double?)m.Price);
                        break;
                    }

                case "price_desc":
                    {
                        songs = songs.OrderByDescending(m => (double?)m.Price);
                        break;
                    }
                case "rating":
                    {
                        songs = songs.OrderBy(m => m.Rating);
                        break;
                    }

                case "rating_desc":
                    {
                        songs = songs.OrderByDescending(m => m.Rating);
                        break;
                    }
                default:
                    songs = songs.OrderBy(m => m.Title);
                    break;

            }
            var songGenreVM = new SongGenreViewModel
            {
                Genres = new SelectList(await genreQuery.Distinct().ToListAsync()),
                Song = await songs.ToListAsync()
            };

            return View(songGenreVM);
        }

        // GET: Song/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return View("NotFound");
            }

            var song = await _context.Song
                .FirstOrDefaultAsync(m => m.Id == id);
            if (song == null)
            {
                return View("NotFound");
            }

            return View(song);
        }

        // GET: Song/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Song/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,ReleaseDate,Genre,Price")] Song song)
        {
            if (ModelState.IsValid)
            {
                _context.Add(song);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(song);
        }

        // GET: Song/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return View("NotFound");
            }

            var song = await _context.Song.FindAsync(id);
            if (song == null)
            {
                return View("NotFound");
            }
            return View(song);
        }

        // POST: Song/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,ReleaseDate,Genre,Price")] Song song)
        {
            if (id != song.Id)
            {
                return View("NotFound");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(song);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SongExists(song.Id))
                    {
                        return View("NotFound");
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(song);
        }

        // GET: Song/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return View("NotFound");
            }

            var song = await _context.Song
                .FirstOrDefaultAsync(m => m.Id == id);
            if (song == null)
            {
                return View("NotFound");
            }

            return View(song);
        }

        // POST: Song/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var song = await _context.Song.FindAsync(id);
            _context.Song.Remove(song);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> HideItem(int[] idforsong)
        {
            if (idforsong == null || idforsong.Length == 0)
            {

                return RedirectToAction(nameof(Index));
            }

            var songToHide = await _context.Song
                .Where(m => idforsong.Contains(m.Id))
                .ToListAsync();

            foreach (var Song in songToHide)
            {
                Song.Hide = true;
            }

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Hidden()
        {
            var hiddenSong = await _context.Song
            .Where(m => m.Hide)
                .ToListAsync();

            return View(hiddenSong);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteHiddenSong()
        {
            var hiddenSong = await _context.Song
                .Where(m => m.Hide)
                .ToListAsync();

            foreach (var s in hiddenSong)
            {
                s.Hide = false;
            }

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Hidden));
        }
         public async Task<IActionResult> DeleteAll()
        {
            return View();
        }

        // POST: Movies/DeleteAll
        [HttpPost, ActionName("DeleteAll")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmedAll()
        {
            var allsong = _context.Song.ToList();
            if (allsong.Count > 0)
            {
                _context.Song.RemoveRange(allsong);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));

        }

        private bool SongExists(int id)
        {
            return _context.Song.Any(e => e.Id == id);
        }

    }
}