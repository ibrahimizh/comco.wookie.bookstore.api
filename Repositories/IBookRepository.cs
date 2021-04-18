using System.Collections.Generic;
using System.Threading.Tasks;
using comco.wookie.bookstore.api.Models;

namespace comco.wookie.bookstore.api.Repositories
{
    public interface IBooksRepository
    {
        Task<IEnumerable<Book>> GetAsync();
        Task AddAsync(Book newBook);
        
    }
}