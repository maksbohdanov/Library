namespace Application.Models.DTOs
{
    public class BookDTO
    {
        public int ID { get; set; }

        public string Title { get; set; }

        public DateTime PublishingDate { get; set; }

        public string Description { get; set; }

        public int Pages { get; set; }
    }
}
