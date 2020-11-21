using System.Collections.Generic;
using AutoMapper;
using MyApi.Data;
using MyApi.Dtos;
using MyApi.Models;
using Microsoft.AspNetCore.Mvc;


namespace MyApi.Controllers
{

    [Route("api/courses")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseRepo _repository;
        private readonly IMapper _mapper;

        public CoursesController(ICourseRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        //GET api/course
        [HttpGet]
        public ActionResult<IEnumerable<CourseReadDto>> GetAllCourses()
        {
            var courseItems = _repository.GetAllCourses();

            return Ok(_mapper.Map<IEnumerable<CourseReadDto>>(courseItems));
        }

        //GET api/course/{id}
        [HttpGet("{id}", Name = "GetCourseById")]
        public ActionResult<CourseReadDto> GetCourseById(int id)
        {
            var CourseItem = _repository.GetCourseById(id);
            if (CourseItem != null)
            {
                return Ok(_mapper.Map<CourseReadDto>(CourseItem));
            }
            return NotFound();
        }

        //POST api/course
        [HttpPost]
        public ActionResult<CourseReadDto> CreateCourse(CourseCreateDto courseCreateDto)
        {
            var courseModel = _mapper.Map<Course>(courseCreateDto);
            _repository.CreateCourse(courseModel);
            _repository.SaveChanges();

            var courseReadDto = _mapper.Map<CourseReadDto>(courseModel);

            return CreatedAtRoute(nameof(GetCourseById), new { Id = courseReadDto.Id }, courseReadDto);
        }

        //PUT api/course/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateCourse(int id, CourseUpdateDto courseUpdateDto)
        {
            var courseModelFromRepo = _repository.GetCourseById(id);
            if (courseModelFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(courseUpdateDto, courseModelFromRepo);

            _repository.UpdateCourse(courseModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }


        //DELETE api/course/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteCourse(int id)
        {
            var courseModelFromRepo = _repository.GetCourseById(id);
            if (courseModelFromRepo == null)
            {
                return NotFound();
            }
            _repository.DeleteCourse(courseModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

    }
}