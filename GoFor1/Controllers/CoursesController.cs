using GoFor1.DTO;
using GoFor1.Models;
using GoFor1.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace GoFor1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        CoursesRepository CR;
        public CoursesController(CoursesRepository _CR)
        {
            CR = _CR;
        }
        [HttpGet]
        public IActionResult GetAllCourses()
        {
            List<Courses> Cos = CR.GetAllCourses();
            
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
           

            Courses CO=CR.GetCourseById(id);
            
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
            CR.AddCourse(C);
            CR.Save();
            return Created("DoneCreating",CD);
           // return CreatedAtAction("Getbyid", new {id=C.Id}, C);
        }
        [HttpPut("EditCourses")]
        public IActionResult EditCourses (CoursesDTO CD,int id)
        {
            var existingCourse = CR.GetCourseById(id);
            if (existingCourse == null)
            {
                return NotFound("Course not found");
            }
          existingCourse.Name = CD.Name;
            existingCourse.Description = CD.Description;
            existingCourse.Duration = CD.Duration;
            existingCourse.Price = CD.Price;
            

            CR.Save();

            // return Ok(C);
            return NoContent();

        }
        [HttpDelete("DeleteCourse")]
        public IActionResult DeleteCourse(int id)
        {
            if (CR.GetCourseById(id) == null)
            {
                return NotFound("Course not found");
            }
            CR.DeleteCourse(id);
            CR.Save();
            //return Ok(Co);
            return Ok("Deleted Done!");
        }
    }
}
