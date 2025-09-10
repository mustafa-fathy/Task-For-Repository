using GoFor1.Models;

namespace GoFor1.DTO
{
    public class StudentsDTo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public DateTime BirthDate { get; set; }
        public Courses? Courses { get; set; }   
    }
}
