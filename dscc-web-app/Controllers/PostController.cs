using dscc_web_app.Models;
using dscc_web_app.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace dscc_web_app.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostService _postService;
        private readonly IAuthorService _authorService;

        public PostController(IPostService postService, IAuthorService authorService)
        {
            _postService = postService;
            _authorService = authorService;
        }

        // GET: Post/Index
        public async Task<IActionResult> Index()
        {
            var posts = await _postService.GetPostsAsync();
            return View(posts);
        }

        // GET: Post/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var post = await _postService.GetPostAsync(id);
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        // GET: Post/Create
        public async Task<IActionResult> Create()
        {
            var authors = await _authorService.GetAuthorsAsync();
            var authorSelectList = authors.Select(a => new SelectListItem 
                { Value = a.AuthorId.ToString(), Text = $"{a.FirstName} {a.LastName}" }).ToList();
            var viewModel = new PostViewModel
            {
                PublicationDate= DateTime.Now,
                LastUpdated = DateTime.Now,
                AuthorSelectList = new SelectList(authorSelectList, "Value", "Text")
            };
            return View(viewModel);
        }

        // POST: Post/CreatePost
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatePost(PostViewModel post)
        {
            ModelState.Remove("postId");
            if (ModelState.IsValid)
            {
                var response = await _postService.CreatePostAsync(post);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Failed to create the post. Please try again.");
                }
            }

            var authors = await _authorService.GetAuthorsAsync();
            var authorSelectList = authors.Select(a => new SelectListItem
            { Value = a.AuthorId.ToString(), Text = $"{a.FirstName} {a.LastName}" }).ToList();
            var viewModel = new PostViewModel
            {
                PublicationDate = DateTime.Now,
                LastUpdated = DateTime.Now,
                AuthorSelectList = new SelectList(authorSelectList, "Value", "Text")
            };
            return View(viewModel);
        }

        // GET: Post/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var post = await _postService.GetPostAsync(id);
            if (post == null)
            {
                return NotFound();
            }

            var authors = await _authorService.GetAuthorsAsync();
            var authorSelectList = authors.Select(a => new SelectListItem
            { Value = a.AuthorId.ToString(), Text = $"{a.FirstName} {a.LastName}" }).ToList();
            var viewModel = new PostViewModel
            {
                PostId = post.PostId,
                Title = post.Title,
                Content = post.Content,
                PublicationDate = post.PublicationDate,
                LastUpdated = post.LastUpdated,
                AuthorId = post.AuthorId,
                AuthorSelectList = new SelectList(authorSelectList, "Value", "Text")
            };
            return View(viewModel);
        }

        // POST: Post/EditPost/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(PostViewModel post)
        {
            if (ModelState.IsValid)
            {
                var response = await _postService.UpdatePostAsync(post);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Failed to update the post. Please try again.");
                }
            }

            var authors = await _authorService.GetAuthorsAsync();
            var authorSelectList = authors.Select(a => new SelectListItem
            { Value = a.AuthorId.ToString(), Text = $"{a.FirstName} {a.LastName}" }).ToList();
            var viewModel = new PostViewModel
            {
                PostId = post.PostId,
                Title = post.Title,
                Content = post.Content,
                PublicationDate = post.PublicationDate,
                LastUpdated = post.LastUpdated,
                AuthorId = post.AuthorId,
                AuthorSelectList = new SelectList(authorSelectList, "Value", "Text")
            };
            return View(viewModel);
        }

        // GET: Post/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var post = await _postService.GetPostAsync(id);
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        // POST: Post/DeletePost/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletePost(int id)
        {
            var response = await _postService.DeletePostAsync(id);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Failed to delete the post. Please try again.");
                return View("Delete", "Post");
            }
        }
    }
}
