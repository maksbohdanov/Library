namespace Domain.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(int id) : base($"Book with specified id({id}) was not found.")
        { 
        }
    }
}
