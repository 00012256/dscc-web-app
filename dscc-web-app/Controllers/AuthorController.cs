using dscc_web_app.Models;
using dscc_web_app.Services;
using Microsoft.AspNetCore.Mvc;

namespace dscc_web_app.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        // GET: Author/Index
        public async Task<IActionResult> Index()
        {
            var authors = await _authorService.GetAuthorsAsync();
            return View(authors);
        }

        // GET: Author/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var author = await _authorService.GetAuthorAsync(id);
            if (author == null)
            {
                return NotFound();
            }
            return View(author);
        }

        // GET: Author/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Author/CreateAuthor
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAuthor(AuthorViewModel author)
        {
            ModelState.Remove("authorId");
            if (ModelState.IsValid)
            {
                var response = await _authorService.CreateAuthorAsync(author);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Failed to create the author. Please try again.");
                }
            }

            return View(author);
        }

        // GET: Author/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var author = await _authorService.GetAuthorAsync(id);
            if (author == null)
            {
                return NotFound();
            }
            return View(author);
        }

        // POST: Author/EditAuthor
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAuthor(AuthorViewModel author)
        {
            if (ModelState.IsValid)
            {
                var response = await _authorService.UpdateAuthorAsync(author);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "Author");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Failed to update the author. Please try again.");
                }
            }

            return View(author);
        }

        // GET: Author/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var author = await _authorService.GetAuthorAsync(id);
            if (author == null)
            {
                return NotFound();
            }
            return View(author);
        }

        // POST: Author/DeleteAuthor/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            var response = await _authorService.DeleteAuthorAsync(id);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            } else
            {
                ModelState.AddModelError(string.Empty, "Failed to delete the author. Please try again.");
                return View("Delete", "Author");
            }
        }
    }
}
