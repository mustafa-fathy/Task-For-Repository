using GoFor1.Models;

namespace GoFor1.Repository
{
    public interface IStudent
    {
        public List<Students> GetAllStudents();

        public Students AddStudent(Students student);

        public bool EditStudent(Students student, int id);

        public bool DeleteStudent(int id);

        public void Save();
    }
}
