using GoFor1.DTO;
using GoFor1.Models;
using GoFor1.Repository;
using GoFor1.Unit_of_Work;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GoFor1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        //GenericRepo<Students> stR;
        unitWork stR;
        public StudentsController(unitWork _stR )
        {
            stR = _stR;
        }
        [HttpGet]
        public IActionResult GetAllStudents()
        {
            List<Students> sts = stR.StudentRepo.GetAll();

            List<StudentsDTo> stsDto =new List<StudentsDTo>();
            foreach (Students s in sts)
            {
                StudentsDTo sdto = new StudentsDTo()
                {
                    Id = s.Id,
                    Name = s.Name,
                    Email = s.Email,
                    Phone = s.Phone,
                    Address = s.Address,
                    BirthDate = s.BirthDate,
                    Courses = s.Courses
                };
                stsDto.Add(sdto);

            }
        
            return Ok(stsDto);
        }
        [HttpPost("AddStudent")]
        public IActionResult AddStudent(StudentsDTo s)
        {
            
            if (s == null)
            {
                return BadRequest("Student data is null");
            }
           var newStudent = new Students
            {
                Name = s.Name,
                Email = s.Email,
                Phone = s.Phone,
                Address = s.Address,
                BirthDate = s.BirthDate,
                Courses = s.Courses

           };
            stR.StudentRepo.Add(newStudent);
            stR.StudentRepo.Save();
            return Created("DoneCreating",s);


        }
        [HttpPut("EditStudent")]
        public IActionResult EditStudent(int id, StudentsDTo s)
        {
            var Sts = new Students()
            {
                Id = id,
                Name = s.Name,
                Email = s.Email,
                Phone = s.Phone,
                Address = s.Address,
                BirthDate = s.BirthDate,
                Courses = s.Courses
            };
            stR.StudentRepo.Edit(Sts,id);
            stR.StudentRepo.Save();
            return Ok("Student updated successfully");


        }
        [HttpDelete("DeleteStudent")]
        public IActionResult DeleteStudent(int id)
        {
            var success =stR.StudentRepo.Delete(id);
            if (!success)
            {
                return NotFound("Student not found");
            }
            stR.StudentRepo.Save();
            return Ok("Student deleted successfully");
        }
    }
}
