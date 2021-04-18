using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using comco.wookie.bookstore.api.Models;

namespace comco.wookie.bookstore.api.Repositories
{
    public interface IBooksRepository
    {
        Task<IEnumerable<Book>> GetAsync();
        Task<Book> GetByIdAsync(Guid id);
        Task<Book> AddAsync(Book newBook);
        Task<Book> UpdateAsync(Book updatedBook);
        Task<bool?> DeleteAsync(Guid id);
    }
}