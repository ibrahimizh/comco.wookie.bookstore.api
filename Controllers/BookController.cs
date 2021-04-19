using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MediatR;
using comco.wookie.bookstore.api.Queries;
using comco.wookie.bookstore.api.Commands;

namespace comco.wookie.bookstore.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private readonly ILogger<BookController> _logger;
        private readonly IMediator _mediator;

        public BookController(ILogger<BookController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var query = new GetAllBooksQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var query = new GetBookByIdQuery(id);
            var result = await _mediator.Send(query);
            return result != null ? (IActionResult) Ok(result) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateBookCommand command)
        {
            var result = await _mediator.Send(command);
            return CreatedAtAction("Get",new{id = result.Id},result);
        }

        [HttpPatch]
        public async Task<IActionResult> Patch([FromBody] UpdateBookCommand command)
        {
            var result = await _mediator.Send(command);
            return result != null ? CreatedAtAction("Get",new{id = result.Id},result) : NotFound();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deleteCommand = new DeleteBookCommand(id);
            var result = await _mediator.Send(deleteCommand);
            return result != null ? (IActionResult) Ok(result) : NotFound();
        }
    }
}
