using System.ComponentModel.DataAnnotations;

namespace Application.Models.Requests
{
    public class BookReq
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public DateTime PublishingDate { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int Pages { get; set; }
    }
}
