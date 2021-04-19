using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using comco.wookie.bookstore.api.Models;
using comco.wookie.bookstore.api.Repositories;
using MediatR;

namespace comco.wookie.bookstore.api.Commands
{

    public class UpdateBookCommand:BookDTO,IRequest<BookDTO>
    {
        
    }

    public class UpdateBookHandler : IRequestHandler<UpdateBookCommand, BookDTO>
    {
        private readonly IBooksRepository booksRepository;
        private readonly IMapper mapper;

        public UpdateBookHandler(IBooksRepository _booksRepository,IMapper _mapper)
        {
            booksRepository = _booksRepository;
            mapper = _mapper;
        }
        public async Task<BookDTO> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var result = await booksRepository.UpdateAsync(request);

            return mapper.Map<BookDTO>(result);
        }
    }

}
