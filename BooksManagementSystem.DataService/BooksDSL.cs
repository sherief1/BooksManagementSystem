using BooksManagementSystem.Common;
using BooksManagementSystem.Interfaces;
using Microsoft.AspNetCore.Http;


namespace BooksManagementSystem.DataService
{
    public class BooksDSL : IBooksDSL
    {
        private readonly IBooksRepo _booksRepo;
        public BooksDSL(IBooksRepo booksRepo)
        {
            _booksRepo = booksRepo;
        }
        public bool Delete(int id)
        {
            BookDTO bookToDelete = GetByID(id);
            if (bookToDelete == null)
                return false;
            _booksRepo.Delete(bookToDelete);
            return true;
        }
        public BookDTO GetByID(int id)
        {
            return _booksRepo.GetByID(id);
        }

        public IEnumerable<BookDTO> GetAll()
        {
            return _booksRepo.GetAll();
        }

        public async Task Insert(BookDTO bookDTO)
        {   
            await _booksRepo.Insert(bookDTO);
        }

        public async Task Update(BookDTO bookDTO)
        {
            await _booksRepo.Update(bookDTO);
        }

        public IEnumerable<BookDTO> Search(string name)
        {
            return _booksRepo.Search(name);
        }
    }
}
