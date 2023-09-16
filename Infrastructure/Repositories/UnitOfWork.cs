using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly LibraryDbContext _dbContext;
        private readonly IBaseRepository<Book> _bookRepository;

        public UnitOfWork(LibraryDbContext context, IBaseRepository<Book> bookRepository)
        {
            _dbContext = context;
            _bookRepository = bookRepository;
        }

        public IBaseRepository<Book> Books => _bookRepository;


        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task RollBackChangesAsync()
        {
            await _dbContext.Database.RollbackTransactionAsync();
        }
    }
}
