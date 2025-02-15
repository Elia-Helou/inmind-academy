using Microsoft.AspNetCore.Mvc;
using Lab3.Data;
using Lab3.Domain.Entities;
using System.Collections.Generic;

namespace Lab3.Api.Controllers
{
    [ApiController]
    [Route("api/book")]
    public class BookController : ControllerBase
    {
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetBooksByYear([FromQuery] int year, [FromQuery] string order)
        {
            if (year < 0)
            {
                return BadRequest("Invalid year");
            }

            if (order != "asc" && order != "desc")
            {
                return BadRequest("Invalid order. Use 'asc' or 'desc'!");
            }

            var books = DataStore.Books
                .Where(b => b.PublishedYear == year);

            if (order == "asc")
            {
                books = books.OrderBy(b => b.PublishedYear);
            }
            else
            {
                books = books.OrderByDescending(b => b.PublishedYear);
            }

            return Ok(books.ToList());
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult GetTotalNumberOfBooks()
        {
            var totalNumberOfBooks = DataStore.Books.Count();
            return Ok(totalNumberOfBooks);
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult GetBooksPaged([FromQuery] int pageNumber, [FromQuery] int pageSize)
        {
            if (pageNumber < 1 || pageSize < 1)
            {
                return BadRequest("page number and page size must be positive.");
            }

            var books = DataStore.Books
                .Skip((pageNumber - 1) * pageSize)  
                .Take(pageSize)                     
                .ToList();

            return Ok(books);
        }
    }
}
