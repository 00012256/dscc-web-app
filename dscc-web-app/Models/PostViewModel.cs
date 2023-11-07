using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace dscc_web_app.Models
{
    public class PostViewModel
    {
        public PostViewModel()
        {
            AuthorSelectList = new SelectList(Enumerable.Empty<SelectListItem>());
        }

        public int PostId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime PublicationDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime LastUpdated { get; set; }

        public int AuthorId { get; set; }

        public SelectList AuthorSelectList { get; set; }
    }
}
