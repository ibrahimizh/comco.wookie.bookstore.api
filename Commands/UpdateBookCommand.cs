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

    public class UpdateBookCommand:BookDTO,IRequest<BookDTO>
    {
        
    }

    public class UpdateBookHandler : IRequestHandler<UpdateBookCommand, BookDTO>
    {
        private readonly IBooksRepository booksRepository;
        private readonly IMapper mapper;
        private readonly ILogger<UpdateBookHandler> logger;

        public UpdateBookHandler(IBooksRepository _booksRepository,IMapper _mapper, ILogger<UpdateBookHandler> _logger)
        {
            booksRepository = _booksRepository;
            mapper = _mapper;
            logger = _logger;
        }
        public async Task<BookDTO> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var result = await booksRepository.UpdateAsync(request);
            if (result is null) logger.LogWarning($@"Update request submitted with a book which doesn't exist in the repository! 
            Submitted Book Object : {JsonConvert.SerializeObject(request)}");
            else logger.LogInformation($"This book has been updated : {JsonConvert.SerializeObject(request)}");
            return mapper.Map<BookDTO>(result);
        }
    }

}
