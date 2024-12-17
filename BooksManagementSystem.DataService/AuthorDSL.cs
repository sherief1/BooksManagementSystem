using BooksManagementSystem.Common;
using BooksManagementSystem.Interfaces;

namespace BooksManagementSystem.DataService
{
    public class AuthorDSL : IAuthorDSL
    {
        private readonly IAuthorRepo _authorRepo;
        public AuthorDSL(IAuthorRepo authorRepo)
        {
            _authorRepo = authorRepo;
        }
        public bool Delete(int id)
        {
            Author AuthortoDelete = GetByID(id);
            if (AuthortoDelete == null)
                return false;
            _authorRepo.Delete(AuthortoDelete);
            return true;
        }
        public Author GetByID(int id)
        {
            return _authorRepo.GetByID(id);
        }

        public IEnumerable<Author> GetAll()
        {
            return _authorRepo.GetAll();
        }

        public void Insert(Author author)
        {
            _authorRepo.Insert(author);
        }

        public void Update(Author author)
        {
            _authorRepo.Update(author);
        }
        public List<Author> Search(string name)
        {
            return _authorRepo.Search(name);
        }
    }
}
