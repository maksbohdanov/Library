using Domain.Entities;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class BookRepository : BaseRepository<Book>
    {
        public BookRepository(LibraryDbContext dbContext): base(dbContext)
        {

        }
    }
}
