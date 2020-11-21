using System.Collections.Generic;
using AutoMapper;
using MyApi.Data;
using MyApi.Dtos;
using MyApi.Models;
using Microsoft.AspNetCore.Mvc;


namespace MyApi.Controllers
{

    [Route("api/grades")]
    [ApiController]
    public class GradesController : ControllerBase
    {
        private readonly IGradeRepo _repository;
        private readonly IMapper _mapper;

        public GradesController(IGradeRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        //GET api/grades
        [HttpGet]
        public ActionResult<IEnumerable<GradeReadDto>> GetAllGrades()
        {
            var gradeItems = _repository.GetAllGrades();

            return Ok(_mapper.Map<IEnumerable<GradeReadDto>>(gradeItems));
        }

        //GET api/grades/course/{id}
        [HttpGet("course/{id}", Name = "GetGradesCourse")]
        public ActionResult<IEnumerable<GradeReadDto>> GetGradesCourse(int id)
        {
            var gradeItems = _repository.GetGradesCourse(id);

            return Ok(_mapper.Map<IEnumerable<GradeReadDto>>(gradeItems));
        }


        //GET api/grades/student/{id}
        [HttpGet("student/{id}", Name = "GetGradesStudent")]
        public ActionResult<IEnumerable<GradeReadDto>> GetGradesStudent(int id)
        {
            var gradeItems = _repository.GetGradesStudent(id);

            return Ok(_mapper.Map<IEnumerable<GradeReadDto>>(gradeItems));
        }

        //GET api/grades/{student_id}/{course_id}
        [HttpGet("{sid}/{cid}", Name = "GetGradeById")]
        public ActionResult<GradeReadDto> GetGradeById(int sid, int cid)
        {
            var gradeItems = _repository.GetGradeById(sid, cid);

            return Ok(_mapper.Map<GradeReadDto>(gradeItems));
        }

        //POST api/grades
        [HttpPost]
        public ActionResult<GradeReadDto> CreateGrade(GradeCreateDto gradeCreateDto)
        {
            var gradeModel = _mapper.Map<Grade>(gradeCreateDto);
            _repository.CreateGrade(gradeModel);
            _repository.SaveChanges();

            var gradeReadDto = _mapper.Map<GradeReadDto>(gradeModel);

            return CreatedAtRoute(nameof(GetGradeById), new { StudentId = gradeReadDto.StudentId, CourseId = gradeCreateDto.CourseGrade }, gradeReadDto);
        }

        //PUT api/grades/{id}
        [HttpPut("{sid}/{cid}")]
        public ActionResult UpdateGrade(int sid, int cid, GradeUpdateDto gradeUpdateDto)
        {
            var gradeModelFromRepo = _repository.GetGradeById(sid, cid);
            if (gradeModelFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(gradeUpdateDto, gradeModelFromRepo);

            _repository.UpdateGrade(gradeModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }


        //DELETE api/grades/{id}
        [HttpDelete("{sid}/{cid}")]
        public ActionResult DeleteGrade(int sid, int cid)
        {
            var gradeModelFromRepo = _repository.GetGradeById(sid, cid);
            if (gradeModelFromRepo == null)
            {
                return NotFound();
            }
            _repository.DeleteGrade(gradeModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

    }
}