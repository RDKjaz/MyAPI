using System.Collections.Generic;
using MyApi.Models;

namespace MyApi.Data
{
    public interface ICourseRepo
    {
        bool SaveChanges();

        IEnumerable<Course> GetAllCourses();
        Course GetCourseById(int id);
        void CreateCourse(Course crs);
        void UpdateCourse(Course crs);
        void DeleteCourse(Course crs);
    }
}