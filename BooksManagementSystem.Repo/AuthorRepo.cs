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

        public void Insert(Author author)
        {
            _authorDAL.Insert(author, _appDbContext);
        }

        public void Update(Author author)
        {
            _authorDAL.Update(author, _appDbContext);
        }
        public List<Author> Search(string name)
        {
            return _authorDAL.Search(name, _appDbContext);
        }
        //public void Delete(Author author)
        //{
        //    if (author != null)
        //    {
        //        _appDbContext.author.Remove(author);
        //        _appDbContext.SaveChanges();
        //    }
        //}

        //public IEnumerable<Author> GetAuthors()
        //{
        //    return _appDbContext.author.ToList();

        //}

        //public void Insert(Author author)
        //{
        //    if (author != null)
        //    {
        //        _appDbContext.author.Add(author);
        //        _appDbContext.SaveChanges();
        //    }

        //}

        //public IEnumerable<Author> Search(string name)
        //{
        //    var query = _appDbContext.author.AsQueryable();

        //    if (!string.IsNullOrEmpty(name))//IF name != null
        //    {
        //        query = query.Where(a => a.Name.Contains(name));
        //    }
        //    return query.ToList();
        //}

        //public void Update(Author author)
        //{
        //    if (author != null)
        //    {
        //        _appDbContext.author.Update(author);
        //        _appDbContext.SaveChanges();
        //    }
        //}
    }
}
