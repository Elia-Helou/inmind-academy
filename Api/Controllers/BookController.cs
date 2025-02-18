using lab4.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace lab4.Api.Controllers
{
    [Route("odata/books")]
    public class BookController : ODataController
    {
        private readonly LibrarydbContext _context;
        public BookController(LibrarydbContext context)
        {
            _context = context;
        }

        [EnableQuery]
        [HttpGet("[action]")]
        public IActionResult Get()
        {
            return Ok(_context.Books);
        }

        [EnableQuery]
        [HttpGet("[action]")]
        public IActionResult GetTotalNumberOfBooks()
        {
            return Ok(_context.Books.Count());
        }

        [EnableQuery]
        [HttpGet("[action]")]
        public IActionResult GetBooksPaged()
        {
            return Ok(_context.Books);
        }
    }
}
