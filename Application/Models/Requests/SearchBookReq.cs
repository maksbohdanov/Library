namespace Application.Models.Requests
{
    public class SearchBookReq
    {        
        public string Title { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}
