using BooksManagementSystem.Common;
using BooksManagementSystem.Interfaces;
using System.Xml.Linq;


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
        Author MapFields(AuthorDTO authorDTO)
        {
            var author = new Author
            {
               Id = authorDTO.Id,
               Name = authorDTO.Name,   
            };
            return author;
        }

        AuthorDTO MapFields(Author author)
        {
            AuthorDTO authorDTO = new AuthorDTO()
            {
                Id= author.Id,
                Name = author.Name,
            };
            return authorDTO;
        }
        public void Delete(AuthorDTO authorDTO)
        {

            _authorDAL.Delete(MapFields(authorDTO), _appDbContext);
        }
        public AuthorDTO GetByID(int id)
        {
            var author = _authorDAL.GetByID(id, _appDbContext);
            return MapFields(author);
        }
        public void Insert(AuthorDTO authorDTO)
        {
            _authorDAL.Insert(MapFields(authorDTO), _appDbContext);
        }
        public void Update(AuthorDTO authorDTO)
        {
           
            _authorDAL.Update(MapFields(authorDTO), _appDbContext);
        }
        public IEnumerable<AuthorDTO> GetAll()
        {
            var author = _authorDAL.GetAll(_appDbContext);
            if (!author.Any())
            {
                return null;
            }
            return author.Select(MapFields);
        }
        public IEnumerable<AuthorDTO> Search(string name)
        {
            var author = _authorDAL.Search(name, _appDbContext);

            if (!author.Any())
            {
                return null;
            }
            return author.Select(MapFields);
        }
        
    }
}
