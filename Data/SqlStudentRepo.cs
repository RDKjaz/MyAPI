using System;
using System.Collections.Generic;
using System.Linq;
using MyApi.Models;

namespace MyApi.Data
{
    public class SqlStudentRepo : IStudentRepo
    {
        private readonly DatabaseContext _context;

        public SqlStudentRepo(DatabaseContext context)
        {
            _context = context;
        }

        public void CreateStudent(Student cmd)
        {
            if (cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }

            _context.Students.Add(cmd);
        }

        public void DeleteStudent(Student cmd)
        {
            if (cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }
            _context.Students.Remove(cmd);
        }

        public IEnumerable<Student> GetAllStudents()
        {
            return _context.Students.ToList();
        }

        public Student GetStudentById(int id)
        {
            return _context.Students.FirstOrDefault(p => p.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateStudent(Student cmd)
        {
            //Nothing
        }
    }
}