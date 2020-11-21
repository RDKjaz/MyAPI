using System.Collections.Generic;
using MyApi.Models;

namespace MyApi.Data
{
    public interface IGradeRepo
    {
        bool SaveChanges();

        IEnumerable<Grade> GetAllGrades();
        IEnumerable<Grade> GetGradesCourse(int id);
        IEnumerable<Grade> GetGradesStudent(int id);
        Grade GetGradeById(int sid, int cid);

        void CreateGrade(Grade grd);
        void UpdateGrade(Grade grd);
        void DeleteGrade(Grade grd);
    }
}