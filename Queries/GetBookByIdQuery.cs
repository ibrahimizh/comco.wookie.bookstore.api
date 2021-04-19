using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using comco.wookie.bookstore.api.Models;
using comco.wookie.bookstore.api.Repositories;
using MediatR;

namespace comco.wookie.bookstore.api.Queries
{

    public class GetBookByIdQuery:IRequest<BookDTO>
    {
        public Guid Id{get;}
        public GetBookByIdQuery(Guid id)
        {
            Id = id;
        }
    }

    public class GetBookByIdHandler : IRequestHandler<GetBookByIdQuery, BookDTO>
    {
        private readonly IBooksRepository booksRepository;
        private readonly IMapper mapper;

        public GetBookByIdHandler(IBooksRepository _booksRepository,IMapper _mapper)
        {
            booksRepository = _booksRepository;
            mapper = _mapper;
        }
        public async Task<BookDTO> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            var book = await booksRepository.GetByIdAsync(request.Id);
            return mapper.Map<BookDTO>(book);
        }
    }

}
