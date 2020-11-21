using System;
using System.Collections.Generic;
using System.Linq;
using MyApi.Models;

namespace MyApi.Data
{
    public class SqlGradeRepo : IGradeRepo
    {
        private readonly DatabaseContext _context;

        public SqlGradeRepo(DatabaseContext context)
        {
            _context = context;
        }

        public void CreateGrade(Grade grd)
        {
            if (grd == null)
            {
                throw new ArgumentNullException(nameof(grd));
            }

            _context.Grades.Add(grd);
        }

        public void DeleteGrade(Grade grd)
        {
            if (grd == null)
            {
                throw new ArgumentNullException(nameof(grd));
            }
            _context.Grades.Remove(grd);
        }

        public IEnumerable<Grade> GetAllGrades()
        {
            return _context.Grades.ToList();
        }

        public IEnumerable<Grade> GetGradesCourse(int id)
        {
            return _context.Grades.Where(t => t.CourseId == id).ToList();
        }

        public IEnumerable<Grade> GetGradesStudent(int id)
        {
            return _context.Grades.Where(t => t.StudentId == id).ToList();
        }

        public Grade GetGradeById(int sid, int cid)
        {
            return _context.Grades.Where(p => p.StudentId == sid && p.CourseId == cid).FirstOrDefault();
        }


        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateGrade(Grade grd)
        {
            //Nothing
        }
    }
}