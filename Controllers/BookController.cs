using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace comco.wookie.bookstore.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;

        public BookController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            
            await Task.CompletedTask;
            var books=new Models.Book[]{
                new Models.Book{Author="Author 1",Description="Book 1 description",Price=99.99,Title="Book1"},
                new Models.Book{Author="Author 2",Description="Book 2 description",Price=199.99,Title="Book2"}
                };
            return Ok(books);
        }
    }
}
