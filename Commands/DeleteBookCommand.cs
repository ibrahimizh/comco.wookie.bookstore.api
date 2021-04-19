using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using comco.wookie.bookstore.api.Models;
using comco.wookie.bookstore.api.Repositories;
using MediatR;

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

        public DeleteBookHandler(IBooksRepository _booksRepository)
        {
            booksRepository = _booksRepository;
        }
        public async Task<bool?> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            return await booksRepository.DeleteAsync(request.Id);
        }
    }

}
