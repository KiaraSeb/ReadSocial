using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReadSocial.Data;
using ReadSocial.Models;
using System.Linq;
using System.Threading.Tasks;

namespace ReadSocial.Controllers
{
    public class ForumController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ForumController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /Forum/Threads
        public async Task<IActionResult> Threads()
        {
            var threads = await _context.Threads.Include(t => t.Posts).ToListAsync();
            return View(threads);
        }

        // GET: /Forum/ThreadDetails/5
        public async Task<IActionResult> ThreadDetails(int id)
        {
            var thread = await _context.Threads
                .Include(t => t.Posts)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (thread == null)
            {
                return NotFound();
            }

            return View(thread);
        }

        // POST: /Forum/CreateThread
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateThread([Bind("Title, Author")] Thread thread)
        {
            if (ModelState.IsValid)
            {
                _context.Add(thread);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Threads));
            }
            return View(thread);
        }

        // POST: /Forum/CreatePost
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatePost(int threadId, [Bind("Content, Author")] Post post)
        {
            if (ModelState.IsValid)
            {
                post.ThreadId = threadId;
                _context.Add(post);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ThreadDetails), new { id = threadId });
            }
            return View(post);
        }
    }
}
