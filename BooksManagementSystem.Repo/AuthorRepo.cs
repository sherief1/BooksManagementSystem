using BooksManagementSystem.Common;
using BooksManagementSystem.Interfaces;


namespace BooksManagementSystem.Repo
{
    public class AuthorRepo : IAuthorRepo
    {
        private readonly IAuthorDAL _authorDAL;
        private readonly AppDbContext _appDbContext;
        public AuthorRepo(IAuthorDAL authorDAL, AppDbContext AppDbContext)
        {
            _authorDAL = authorDAL;
            _appDbContext = AppDbContext;
        }

        public void Delete(Author author)
        {

            _authorDAL.Delete(author, _appDbContext);
        }
        public Author GetByID(int id)
        {
            return _authorDAL.GetByID(id, _appDbContext);
        }

        public IEnumerable<Author> GetAll()
        {
            return _authorDAL.GetAll(_appDbContext);
        }

        public void Insert(AuthorDTO authorDTO)
        {
            var author = new Author
            {
                Name = authorDTO.Name,
            };
            _authorDAL.Insert(author, _appDbContext);
        }

        public void Update(AuthorDTO authorDTO)
        {
            var author = new Author
            {
                Id = authorDTO.Id,
                Name = authorDTO.Name,
            };
            _authorDAL.Update(author, _appDbContext);
        }
        public List<Author> Search(string name)
        {
            return _authorDAL.Search(name, _appDbContext);
        }
        
    }
}
