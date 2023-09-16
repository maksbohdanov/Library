namespace Domain.Entities
{
    public class Book: BaseEntity
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public DateTime PublishingDate { get; set; }
        
        public string Description { get; set; }

        public int Pages { get; set; }
    }
}
