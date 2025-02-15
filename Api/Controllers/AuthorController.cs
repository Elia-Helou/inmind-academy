using Microsoft.AspNetCore.Mvc;
using Lab3.Data;
using Lab3.Domain.Entities;
using System.Collections.Generic;

namespace Lab3.Api.Controllers
{
    [ApiController]
    [Route("api/author")]
    public class AuthorController : ControllerBase
    {
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetAuthorsGroupedByBirthYear()
        {
            var groupedAuthors = DataStore.Authors
                .GroupBy(a => a.BirthDate.Year)
                .Select(g => new
                {
                    BirthYear = g.Key,
                    Authors = g.ToList()
                })
                .ToList(); 

            return Ok(groupedAuthors);
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult GetAuthorsGroupedByBirthYearAndCountry()
        {
            var groupedAuthors = DataStore.Authors
                .GroupBy(a => new { a.BirthDate.Year, a.Country }) 
                .Select(g => new
                {
                    BirthYear = g.Key.Year,
                    Country = g.Key.Country,
                    Authors = g.ToList()
                })
                .ToList();

            return Ok(groupedAuthors);
        }


    }
}
