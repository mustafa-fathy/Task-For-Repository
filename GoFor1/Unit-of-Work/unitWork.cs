using GoFor1.Models;
using GoFor1.Repository;

namespace GoFor1.Unit_of_Work
{
    public class unitWork
    {
        GenericRepo<Students> studentRepo;
        GenericRepo<Courses> courseRepo;
        DbCon db;
        public unitWork(DbCon _db)
        {
            db = _db;
        }
        public GenericRepo<Students> StudentRepo
        {
            get
            {
                if (studentRepo == null)
                {
                    studentRepo = new GenericRepo<Students>(db);
                }
                return studentRepo;
            }
        }
        public GenericRepo<Courses> CourseRepo
        {
            get
            {
                if (courseRepo == null)
                {
                    courseRepo = new GenericRepo<Courses>(db);
                }
                return courseRepo;
            }
        }

    }
}
