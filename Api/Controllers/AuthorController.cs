using lab4.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace lab4.Api.Controllers
{
    public class AuthorController : ODataController
    {
        private readonly LibrarydbContext _context;
        public AuthorController(LibrarydbContext context)
        {
            _context = context;
        }

        [EnableQuery]
        [HttpGet("[action]")]
        public IActionResult Get()
        {
            return Ok(_context.Authors);
        }


    }
}
