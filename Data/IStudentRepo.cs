using System.Collections.Generic;
using MyApi.Models;

namespace MyApi.Data
{
    public interface IStudentRepo
    {
        bool SaveChanges();

        IEnumerable<Student> GetAllStudents();
        Student GetStudentById(int id);
        void CreateStudent(Student sdt);
        void UpdateStudent(Student sdt);
        void DeleteStudent(Student sdt);
    }
}