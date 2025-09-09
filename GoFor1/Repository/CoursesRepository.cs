using GoFor1.Models;

namespace GoFor1.Repository
{
    public class CoursesRepository
    {
        DbCon dbCon;
        public CoursesRepository(DbCon _dbCon)
        {
            dbCon = _dbCon;
        }
        public List<Courses> GetAllCourses()
        {
            return dbCon.Courses.ToList();
        }
        public Courses? GetCourseById(int id)
        {
            return dbCon.Courses.Find(id);
        }
        public Courses? GetCourseByName(string name)
        {
            return dbCon.Courses.FirstOrDefault(c => c.Name == name);
        }
        public Courses AddCourse(Courses course)
        {
            dbCon.Courses.Add(course);
            //dbCon.SaveChanges();
            return course;
        }
        public bool EditCourse(Courses course, int id)
        {
            if (course == null || course.Id != id) return false;
            dbCon.Entry(course).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
           // dbCon.SaveChanges();
            return true;
        }
        public bool DeleteCourse(int id)
        {
            var course = dbCon.Courses.Find(id);
            if (course == null) return false;
            dbCon.Courses.Remove(course);
           // dbCon.SaveChanges();
            return true;
        }
        public void Save()
        {
            dbCon.SaveChanges();
        }
    }
}
