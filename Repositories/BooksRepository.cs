using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using comco.wookie.bookstore.api.Models;

namespace comco.wookie.bookstore.api.Repositories
{

    public class BooksRepository : IBooksRepository
    {        
        private List<Book> Books {get;} = new List<Book>{
                new Models.Book{Author="Author 1",Description="Book 1 description",Price=99.99,Title="Book1"},
                new Models.Book{Author="Author 2",Description="Book 2 description",Price=199.99,Title="Book2"},
                new Models.Book{Author="Author 3",Description="Book 3 description",Price=299.99,Title="Book3"}
        };

        public async Task<IEnumerable<Book>> GetAsync(){
            await Task.CompletedTask;
            return Books;
        }

        public async Task AddAsync(Book newBook)
        {
            await Task.CompletedTask;
            Books.Add(newBook);
        }
    }

}