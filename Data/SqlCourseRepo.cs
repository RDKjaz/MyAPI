using System;
using System.Collections.Generic;
using System.Linq;
using MyApi.Models;

namespace MyApi.Data
{
    public class SqlCourseRepo : ICourseRepo
    {
        private readonly DatabaseContext _context;

        public SqlCourseRepo(DatabaseContext context)
        {
            _context = context;
        }

        public void CreateCourse(Course crs)
        {
            if (crs == null)
            {
                throw new ArgumentNullException(nameof(crs));
            }

            _context.Courses.Add(crs);
        }

        public void DeleteCourse(Course crs)
        {
            if (crs == null)
            {
                throw new ArgumentNullException(nameof(crs));
            }
            _context.Courses.Remove(crs);
        }

        public IEnumerable<Course> GetAllCourses()
        {
            return _context.Courses.ToList();
        }

        public Course GetCourseById(int id)
        {
            return _context.Courses.FirstOrDefault(p => p.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateCourse(Course crs)
        {
            //Nothing
        }
    }
}