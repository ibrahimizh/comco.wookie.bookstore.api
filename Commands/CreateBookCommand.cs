using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using comco.wookie.bookstore.api.Models;
using comco.wookie.bookstore.api.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace comco.wookie.bookstore.api.Commands
{

    public class CreateBookCommand:BookDTO,IRequest<BookDTO>
    {
        
    }

    public class CreateBookHandler : IRequestHandler<CreateBookCommand, BookDTO>
    {
        private readonly IBooksRepository booksRepository;
        private readonly IMapper mapper;
        private readonly ILogger<CreateBookHandler> logger;

        public CreateBookHandler(IBooksRepository _booksRepository,IMapper _mapper,ILogger<CreateBookHandler> _logger)
        {
            booksRepository = _booksRepository;
            mapper = _mapper;
            logger = _logger;

        }
        public async Task<BookDTO> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var book = await booksRepository.AddAsync(mapper.Map<BookDTO,Book>(request,new Book()));
            logger.LogInformation($"A new book has been added to the repository {JsonConvert.SerializeObject(book)}");
            return mapper.Map<BookDTO>(book);
        }
    }

}
