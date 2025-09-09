using GoFor1.DTO;
using GoFor1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GoFor1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        DbCon db;
        public StudentsController(DbCon _db )
        {
            db = _db;
        }
        [HttpGet("GetAllStudents")]
        public IActionResult GetAllStudents()
        {
            List<Students> sts = db.Student.ToList();
            List<StudentDTO> stsDto =new List<StudentDTO>();
            foreach (Students s in sts)
            {
                StudentDTO sdto = new StudentDTO()
                {
                    Id = s.Id,
                    Name = s.Name,
                    Email = s.Email,
                    Phone = s.Phone,
                    Address = s.Address,
                    BirthDate = s.BirthDate,
                    CourseId = s.Course.Id
                };

            }
        
            return Ok(stsDto);
        }
    }
}
