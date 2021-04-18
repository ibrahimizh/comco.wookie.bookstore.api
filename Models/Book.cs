
using System;

namespace comco.wookie.bookstore.api.Models{
    public class Book{

        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string CoverImage { get; set; }
        public double Price { get; set; }
    }
}