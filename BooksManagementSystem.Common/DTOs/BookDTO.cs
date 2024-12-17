﻿namespace BooksManagementSystem.Common
{
    public class BookDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime PublishDate { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
    }
}
