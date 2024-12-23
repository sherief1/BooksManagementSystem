﻿using BooksManagementSystem.Common;
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
            AuthorDTO AuthortoDelete = GetByID(id);
            if (AuthortoDelete == null)
                return false;
            _authorRepo.Delete(AuthortoDelete);
            return true;
        }
        public AuthorDTO GetByID(int id)
        {
            return _authorRepo.GetByID(id);
        }

        public IEnumerable<AuthorDTO> GetAll()
        {
            return _authorRepo.GetAll();
        }

        public void Insert(AuthorDTO authorDTO)
        {
            _authorRepo.Insert(authorDTO);
        }

        public void Update(AuthorDTO authorDTO)
        {
            _authorRepo.Update(authorDTO);
        }
        public IEnumerable<AuthorDTO> Search(string name)
        {
            return _authorRepo.Search(name);
        }
    }
}
