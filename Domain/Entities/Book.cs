using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("Books")]
    public class Book
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public DateTime PublishingDate { get; set; }
        
        public string Description { get; set; }

        public int Pages { get; set; }
    }
}
