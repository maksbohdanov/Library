using Application.Interfaces;
using Application.Models.DTOs;
using Application.Models.Requests;
using AutoMapper;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Repositories;

namespace Application.Services
{
    public class BookService: IBookService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BookService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BookDTO> GetById(int id)
        {
            var result = await _unitOfWork.Books.GetByIdAsync(id);
            if (result == null)
            {
                throw new NotFoundException(id);
            }
            return _mapper.Map<BookDTO>(result);
        }

        public async Task<IEnumerable<BookDTO>> GetAll()
        {
            var result = await _unitOfWork.Books.GetAllAsync();
            return _mapper.Map<IEnumerable<BookDTO>>(result);
        }

        public async Task<IEnumerable<BookDTO>> SearchByTitle(string title)
        {
            var result = await _unitOfWork.Books
                .FindAsync(x => x.Title.Contains(title, StringComparison.OrdinalIgnoreCase));
            return _mapper.Map<IEnumerable<BookDTO>>(result);
        }


        public async Task<IEnumerable<BookDTO>> SearchByDatePeriod(DateTime startDate, DateTime endDate)
        {
            var result = await _unitOfWork.Books
                .FindAsync(x => x.PublishingDate >= startDate && x.PublishingDate <= endDate);
            return _mapper.Map<IEnumerable<BookDTO>>(result);
        }

        public async Task<BookDTO> Add(BookReq model)
        {
            var book = _mapper.Map<Book>(model);
            var result = await _unitOfWork.Books.CreateAsync(book);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<BookDTO>(result);
        }

        public async Task<BookDTO> Update(int id, BookReq model)
        {
            var book = await _unitOfWork.Books.GetByIdAsync(id);
            if (book == null)
            {
                throw new NotFoundException(id);
            }
            book.Title = model.Title;
            book.PublishingDate = model.PublishingDate;
            book.Description = model.Description;
            book.Pages = model.Pages;

            _unitOfWork.Books.Update(book);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<BookDTO>(book);
        }

        public async Task DeleteById(int id)
        {
            var book = await _unitOfWork.Books.GetByIdAsync(id);
            if (book == null)
            {
                throw new NotFoundException(id);
            }
            _unitOfWork.Books.Delete(book);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
