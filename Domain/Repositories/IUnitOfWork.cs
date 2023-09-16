using Domain.Entities;

namespace Domain.Repositories
{
    public interface IUnitOfWork
    {
        IBaseRepository<Book> Books { get; }

        Task SaveChangesAsync();
        Task RollBackChangesAsync();
    }
}
