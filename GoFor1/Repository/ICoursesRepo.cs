using GoFor1.Models;

namespace GoFor1.Repository
{
    public interface ICoursesRepo
    {
       
        public List<Courses> GetAllCourses();

        public Courses? GetCourseById(int id);

        public Courses? GetCourseByName(string name);

        public Courses AddCourse(Courses course);
        
        public bool EditCourse(Courses course, int id);

        public bool DeleteCourse(int id);

        public void Save();
        
    }
}
