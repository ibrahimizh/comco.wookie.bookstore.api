using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using comco.wookie.bookstore.api.Models;
using comco.wookie.bookstore.api.Repositories;
using MediatR;

namespace comco.wookie.bookstore.api.Queries{

    public class GetAllBooksQuery:IRequest<IEnumerable<BookDTO>>
    {

    }

    public class GetAllBooksHandler : IRequestHandler<GetAllBooksQuery, IEnumerable<BookDTO>>
    {
        private readonly IBooksRepository booksRepository;
        private readonly IMapper mapper;

        public GetAllBooksHandler(IBooksRepository _booksRepository,IMapper _mapper)
        {
            booksRepository = _booksRepository;
            mapper = _mapper;
        }
        public async Task<IEnumerable<BookDTO>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
        {
            var books = await booksRepository.GetAsync();
            return mapper.Map<IEnumerable<BookDTO>>(books);
        }
    }

}
