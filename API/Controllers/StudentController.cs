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
    [Route("api/students")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public StudentController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStudents()
        {
            var students = await _context.Students.ToListAsync();
            return Ok(_mapper.Map<List<StudentViewModel>>(students));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentById(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null) return NotFound();

            return Ok(_mapper.Map<StudentViewModel>(student));
        }

        [HttpPost]
        public async Task<IActionResult> CreateStudent([FromBody] StudentViewModel studentVm)
        {
            var studentEntity = _mapper.Map<Student>(studentVm);
            _context.Students.Add(studentEntity);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetStudentById), new { id = studentEntity.Id }, _mapper.Map<StudentViewModel>(studentEntity));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null) return NotFound();

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return Ok("Student deleted successfully.");
        }
    }
}
