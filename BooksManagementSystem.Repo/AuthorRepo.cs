using BooksManagementSystem.Data;
using BooksManagementSystem.Interfaces;
using BooksManagementSystem.Model;


namespace BooksManagementSystem.Repo
{
    internal class AuthorRepo : IAuthorRepo
    {
        private readonly AppDbContext _context;
        public AuthorRepo(AppDbContext context)
        {
            _context = context;
        }

        public void Delete(Author author)
        {
            if (author != null)
            {
                _context.author.Remove(author);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Author> GetAuthors()
        {
            return _context.author.ToList();

        }

        public void Insert(Author author)
        {
            if (author != null)
            {
                _context.author.Add(author);
                _context.SaveChanges();
            }
         
        }

        public IEnumerable<Author> Search(string name)
        {
            var query = _context.author.AsQueryable();

            if (!string.IsNullOrEmpty(name))//IF name != null
            {
                query = query.Where(a => a.Name.Contains(name));
            }
            return query.ToList();
        }

        public void Update(Author author)
        {
            if (author != null)
            {
                _context.author.Update(author);
                _context.SaveChanges();
            }
        }
    }
}
