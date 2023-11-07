using System.ComponentModel.DataAnnotations;

namespace dscc_web_app.Models
{
    public class AuthorViewModel
    {
        public int AuthorId { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string Biography { get; set; }

        public List<PostViewModel> Posts { get; set; }
    }
}
