using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using comco.wookie.bookstore.api.Models;
using comco.wookie.bookstore.api.Repositories;
using MediatR;

namespace comco.wookie.bookstore.api.Queries{

    public class GetAllBooksQuery:IRequest<IEnumerable<Book>>
    {

    }

    public class GetAllBooksHandler : IRequestHandler<GetAllBooksQuery, IEnumerable<Book>>
    {
        private readonly IBooksRepository booksRepository;

        public GetAllBooksHandler(IBooksRepository _booksRepository)
        {
            booksRepository = _booksRepository;
        }
        public async Task<IEnumerable<Book>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
        {
            var books = await booksRepository.GetAsync();
            return books;
        }
    }

}
