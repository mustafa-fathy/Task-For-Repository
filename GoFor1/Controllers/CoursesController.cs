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
        [HttpGet("GetAllCourses")]
        public IActionResult GetAllCourses()
        {
            List<Courses> Cos = CR.GetAllCourses();
            CR.Save();
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
            return Ok();
        }
        [HttpGet("Getbyid")]
        public IActionResult Getbyid(int id)
        {
           

            Courses CO=CR.GetCourseById(id);
            CR.Save();
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
        public IActionResult AddCourse (Courses C)
        {
            CR.AddCourse(C);
            CR.Save();
            return Created("DoneCreating",C);
           // return CreatedAtAction("Getbyid", new {id=C.Id}, C);
        }
        [HttpPut("EditCourses")]
        public IActionResult EditCourses (Courses C,int id)
        {
         CR.EditCourse(C, id);
            CR.Save();

            // return Ok(C);
            return NoContent();

        }
        [HttpDelete("DeleteCourse")]
        public IActionResult DeleteCourse(int id)
        {
            CR.DeleteCourse(id);
            CR.Save();
            //return Ok(Co);
            return Ok("Deleted Done!");
        }
    }
}
