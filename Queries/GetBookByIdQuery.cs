using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using comco.wookie.bookstore.api.Models;
using comco.wookie.bookstore.api.Repositories;
using MediatR;

namespace comco.wookie.bookstore.api.Queries{

    public class GetBookByIdQuery:IRequest<Book>
    {
        public Guid Id{get;}
        public GetBookByIdQuery(Guid id)
        {
            Id = id;
        }
    }

    public class GetBookByIdHandler : IRequestHandler<GetBookByIdQuery, Book>
    {
        private readonly IBooksRepository booksRepository;

        public GetBookByIdHandler(IBooksRepository _booksRepository)
        {
            booksRepository = _booksRepository;
        }
        public async Task<Book> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            var book = await booksRepository.GetByIdAsync(request.Id);
            return book;
        }
    }

}
