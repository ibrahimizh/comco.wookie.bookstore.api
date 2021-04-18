using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using comco.wookie.bookstore.api.Models;

namespace comco.wookie.bookstore.api.Repositories
{

    public class BooksRepository : IBooksRepository
    {        
        private List<Book> Books {get;} = new List<Book>{
                new Models.Book{Id = Guid.NewGuid(),Author="Author 1",Description="Book 1 description",Price=99.99,Title="Book1"},
                new Models.Book{Id = Guid.NewGuid(),Author="Author 2",Description="Book 2 description",Price=199.99,Title="Book2"},
                new Models.Book{Id = Guid.NewGuid(),Author="Author 3",Description="Book 3 description",Price=299.99,Title="Book3"}
        };

        public async Task<IEnumerable<Book>> GetAsync(){
            await Task.CompletedTask;
            return Books;
        }

        public async Task<Book> AddAsync(Book newBook)
        {
            await Task.CompletedTask;
            newBook.Id = Guid.NewGuid();
            Books.Add(newBook);
            return newBook;
        }


        public async Task<Book> GetByIdAsync(Guid id)
        {
            await Task.CompletedTask;

            var book = Books.SingleOrDefault(b=>b.Id == id);
            return book;
        }

        public async Task<Book> UpdateAsync(Book updatedBook)
        {
            await Task.CompletedTask;

            var bookToUpdate = Books.SingleOrDefault(b=>b.Id == updatedBook.Id);
            if(bookToUpdate is null) return null;
            
            bookToUpdate.Author=updatedBook.Author;
            bookToUpdate.CoverImage=updatedBook.CoverImage;
            bookToUpdate.Description=updatedBook.Description;
            bookToUpdate.Price=updatedBook.Price;
            bookToUpdate.Title=updatedBook.Title;
            
            return bookToUpdate;
        }

        public async Task<bool?> DeleteAsync(Guid id)
        {
            await Task.CompletedTask;

            var bookToDelete = Books.SingleOrDefault(b=>b.Id == id);
            if(bookToDelete is null) return null;

            Books.Remove(bookToDelete);
            return true;
        }
    }

}