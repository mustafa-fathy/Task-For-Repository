using GoFor1.Migrations;
using GoFor1.Models;

namespace GoFor1.Repository
{
    public class StudentRepository : IStudent
    {
        DbCon db;
        public StudentRepository(DbCon _db)
        {
            db = _db;
        }
        public List<Students> GetAllStudents()
        {
            return db.Student.ToList();
        }

        

        public Students AddStudent(Students student) 
        {
            if (student == null) return null;
            db.Student.Add(student);
            return student;
        }

        public bool EditStudent(Students student, int id)
        {
            var existingStudent = db.Student.Find(id);
            if (existingStudent == null) return false;

            existingStudent.Name = student.Name;
            existingStudent.Email = student.Email;
            existingStudent.Phone = student.Phone;
            existingStudent.Address = student.Address;
            existingStudent.BirthDate = student.BirthDate;
            existingStudent.Courses = student.Courses;

            return true;
        }
        //public bool EditStudent(Students student)
        //{
        //    var existingStudent = db.Student.Find(student.Id);
        //    if (existingStudent == null) return false;

        //  db.Update(existingStudent);
        //    return true;
        //}

        public bool DeleteStudent(int id)
        {
            var existingStudent = db.Student.Find(id);
            if (existingStudent == null) return false;
            db.Student.Remove(existingStudent);
          
            return true;
        }
    

        public void Save()
        {
            
            db.SaveChanges();

        }




    }
}
