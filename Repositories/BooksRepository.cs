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
                new Book(Guid.Parse("5210c496-61f7-407c-92ba-820850322584")){
                    Author="Robert Martin",
                    Description="Building upon the success of best-sellers The Clean Coder and Clean Code, legendary software craftsman Robert C. 'Uncle Bob' Martin shows how to bring greater professionalism and discipline to application architecture and design.",
                    Price=35.00,
                    Title="Clean Architecture: A Craftsman's Guide to Software Structure and Design",
                    CoverImage="https://images-na.ssl-images-amazon.com/images/I/41TPrNDI50L._SX387_BO1,204,203,200_.jpg"
                    },
                new Book(Guid.Parse("2a713f28-a83e-482f-a5e9-56405c26c2ad")){
                    Author="Erich Gamma",
                    Description="These texts cover the design of object-oriented software and examine how to investigate requirements, create solutions and then translate designs into code, showing developers how to make practical use of the most significant recent developments. A summary of UML notation is included.",
                    Price=69.13,
                    Title="Design Patterns: Elements of Reusable Object-Oriented Software",
                    CoverImage="https://images-na.ssl-images-amazon.com/images/I/51szD9HC9pL._SX395_BO1,204,203,200_.jpg"
                    }
        };

        public async Task<IEnumerable<Book>> GetAsync(){
            await Task.CompletedTask;
            return Books;
        }

        public async Task<Book> AddAsync(Book newBook)
        {
            await Task.CompletedTask;
            Books.Add(newBook);
            return newBook;
        }


        public async Task<Book> GetByIdAsync(Guid id)
        {
            await Task.CompletedTask;

            var book = Books.SingleOrDefault(b=>b.Id == id);
            return book;
        }

        public async Task<Book> UpdateAsync(BookDTO updatedBook)
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