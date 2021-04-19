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

    public class DeleteBookCommand:IRequest<bool?>
    {
        public Guid Id { get; }
        public DeleteBookCommand(Guid id)
        {
            Id = id;
        }
    }

    public class DeleteBookHandler : IRequestHandler<DeleteBookCommand, bool?>
    {
        private readonly IBooksRepository booksRepository;
        private readonly ILogger<DeleteBookHandler> logger;

        public DeleteBookHandler(IBooksRepository _booksRepository,ILogger<DeleteBookHandler> _logger)
        {
            booksRepository = _booksRepository;
            logger = _logger;
        }
        public async Task<bool?> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            var result = await booksRepository.DeleteAsync(request.Id);
            if(result is null) logger.LogWarning($"A delete request was submitted with a non-existing Id : {request.Id}");
            else logger.LogInformation($"This book with Id : {request.Id} has been deleted!");
            return result;
        }
    }

}
