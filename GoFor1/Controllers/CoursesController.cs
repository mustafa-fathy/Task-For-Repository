using GoFor1.DTO;
using GoFor1.Models;
using GoFor1.Repository;
using GoFor1.Unit_of_Work;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace GoFor1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        unitWork CR;
        public CoursesController(unitWork _CR)
        {
            CR = _CR;
        }
        [HttpGet]
        public IActionResult GetAllCourses()
        {
            List<Courses> Cos = CR.CourseRepo.GetAll();
            
            List<CoursesDTO> CosDto = new List<CoursesDTO>();
            foreach (Courses c in Cos)
            {
                CoursesDTO cdto = new CoursesDTO()
                {
                    Id = c.Id,
                    Name = c.Name,
                    Description = c.Description,
                    Duration = c.Duration,
                    Price = c.Price
                };
                CosDto.Add(cdto);
            }
            return Ok(CosDto);
        }
        [HttpGet("Getbyid")]
        public IActionResult Getbyid(int id)
        {
           

            Courses CO=CR.CourseRepo.GetById(id);
            
            if (CO == null) return NotFound("No Course Found");
            else
            {
                CoursesDTO cdto = new CoursesDTO()
                {
                    Id = CO.Id,
                    Name = CO.Name,
                    Description = CO.Description,
                    Duration = CO.Duration,
                    Price = CO.Price
                };
                return Ok(cdto);
            }        
            
        }
        //[HttpGet("GetByName")]
        //public IActionResult GetByName(string name)
        //{
        //    Courses CO = ;
        //    if (CO == null) return NotFound("No Course Found");
        //    else return Ok(CO);
        //}
        [HttpPost]
        public IActionResult AddCourse (CoursesDTO CD)
        {
            if (CD == null)
            {
                return BadRequest("Course data is null");
            }
            var C = new Courses()
            {
                Name = CD.Name,
                Description = CD.Description,
                Duration = CD.Duration,
                Price = CD.Price
                
            };
            CR.CourseRepo.Add(C);
            CR.CourseRepo.Save();
            return Created("DoneCreating",CD);
           // return CreatedAtAction("Getbyid", new {id=C.Id}, C);
        }
        [HttpPut("EditCourses")]
        public IActionResult EditCourses (CoursesDTO CD,int id)
        {
            var existingCourse = CR.CourseRepo.GetById(id);
            if (existingCourse == null)
            {
                return NotFound("Course not found");
            }
          existingCourse.Name = CD.Name;
            existingCourse.Description = CD.Description;
            existingCourse.Duration = CD.Duration;
            existingCourse.Price = CD.Price;
            

            CR.CourseRepo.Save();

            // return Ok(C);
            return NoContent();

        }
        [HttpDelete("DeleteCourse")]
        public IActionResult DeleteCourse(int id)
        {
            if (CR.CourseRepo.GetById(id) == null)
            {
                return NotFound("Course not found");
            }
            CR.CourseRepo.Delete(id);
            CR.CourseRepo.Save();
            //return Ok(Co);
            return Ok("Deleted Done!");
        }
    }
}
