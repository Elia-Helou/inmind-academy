using AutoMapper;
using Lab4_2.API.ViewModels;
using Lab4_2.Domain;
using Lab4_2.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab4_2.API.Controllers
{
    [Route("api/classes")]
    [ApiController]
    public class ClassController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ClassController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllClasses()
        {
            var classes = await _context.Classes
                .Include(c => c.Teacher)
                .Include(c => c.Course)
                .ToListAsync();

            var classViewModels = _mapper.Map<List<ClassViewModel>>(classes);
            return Ok(classViewModels);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetClassById(int id)
        {
            var classEntity = await _context.Classes
                .Include(c => c.Teacher)
                .Include(c => c.Course)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (classEntity == null) return NotFound();

            return Ok(_mapper.Map<ClassViewModel>(classEntity));
        }

        [HttpPost]
        public async Task<IActionResult> CreateClass([FromBody] ClassViewModel classVm)
        {
            var classEntity = _mapper.Map<Class>(classVm);
            _context.Classes.Add(classEntity);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetClassById), new { id = classEntity.Id }, _mapper.Map<ClassViewModel>(classEntity));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClass(int id)
        {
            var classEntity = await _context.Classes.FindAsync(id);
            if (classEntity == null) return NotFound();

            _context.Classes.Remove(classEntity);
            await _context.SaveChangesAsync();
            return Ok("Class deleted successfully.");
        }
    }
}
