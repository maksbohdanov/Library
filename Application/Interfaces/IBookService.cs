using Application.Models.DTOs;
using Application.Models.Requests;

namespace Application.Interfaces
{
    public interface IBookService
    {
        Task<BookDTO> GetById(int id);

        Task<IEnumerable<BookDTO>> GetAll();

        Task<IEnumerable<BookDTO>> SearchByTitle(string title);

        Task<IEnumerable<BookDTO>> SearchByDatePeriod(DateTime startDate, DateTime endDate);

        Task<BookDTO> Add(BookReq model);

        Task<BookDTO> Update(int id, BookReq model);

        void DeleteById(int id);
    }
}
