using System.Collections.Generic;
using AutoMapper;
using MyApi.Data;
using MyApi.Dtos;
using MyApi.Models;
using Microsoft.AspNetCore.Mvc;


namespace MyApi.Controllers
{
    [Route("api/students")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentRepo _repository;
        private readonly IMapper _mapper;

        public StudentsController(IStudentRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        //GET api/students
        [HttpGet]

        public ActionResult<IEnumerable<StudentReadDto>> GetAllStudents()
        {
            var studentItems = _repository.GetAllStudents();

            return Ok(_mapper.Map<IEnumerable<StudentReadDto>>(studentItems));
        }

        //GET api/students/{id}
        [HttpGet("{id}", Name = "GetStudentById")]
        public ActionResult<StudentReadDto> GetStudentById(int id)
        {
            var studentItem = _repository.GetStudentById(id);
            if (studentItem != null)
            {
                return Ok(_mapper.Map<StudentReadDto>(studentItem));
            }
            return NotFound();
        }

        //POST api/students
        [HttpPost]
        public ActionResult<StudentReadDto> CreateStudent(StudentCreateDto studentCreateDto)
        {
            var studentModel = _mapper.Map<Student>(studentCreateDto);
            _repository.CreateStudent(studentModel);
            _repository.SaveChanges();

            var studentReadDto = _mapper.Map<StudentReadDto>(studentModel);

            return CreatedAtRoute(nameof(GetStudentById), new { Id = studentReadDto.Id }, studentReadDto);
        }

        //PUT api/students/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateStudent(int id, StudentUpdateDto studentUpdateDto)
        {
            var studentModelFromRepo = _repository.GetStudentById(id);
            if (studentModelFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(studentUpdateDto, studentModelFromRepo);

            _repository.UpdateStudent(studentModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }


        //DELETE api/students/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteStudent(int id)
        {
            var studentModelFromRepo = _repository.GetStudentById(id);
            if (studentModelFromRepo == null)
            {
                return NotFound();
            }
            _repository.DeleteStudent(studentModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}