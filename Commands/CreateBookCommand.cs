using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using comco.wookie.bookstore.api.Models;
using comco.wookie.bookstore.api.Repositories;
using MediatR;

namespace comco.wookie.bookstore.api.Commands
{

    public class CreateBookCommand:BookDTO,IRequest<BookDTO>
    {
        
    }

    public class CreateBookHandler : IRequestHandler<CreateBookCommand, BookDTO>
    {
        private readonly IBooksRepository booksRepository;
        private readonly IMapper mapper;

        public CreateBookHandler(IBooksRepository _booksRepository,IMapper _mapper)
        {
            booksRepository = _booksRepository;
            mapper = _mapper;

        }
        public async Task<BookDTO> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var book = await booksRepository.AddAsync(mapper.Map<BookDTO,Book>(request,new Book()));
            return mapper.Map<BookDTO>(book);
        }
    }

}
