using attendanceAppWeb.Models.CourseModels;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace attendanceAppWeb.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly IMongoClient _mongoClient;
        private readonly IMongoCollection<Course> _courses;

        public CoursesController(IMongoClient mongoClient)
        {
            _mongoClient = mongoClient;
            var database = _mongoClient.GetDatabase("attendanceApp");
            _courses = database.GetCollection<Course>("Courses");
        }

        /// <summary>
        /// Retrieves a specific course by ID.
        /// </summary>
        /// <param name="id">The ID of the course.</param>
        /// <returns>The course details.</returns>
        [HttpGet("{id:length(24)}", Name = "GetCourse")]
        public async Task<ActionResult<Course>> GetCourse(string id)
        {
            var course = await _courses.Find<Course>(c => c.ClassId == id).FirstOrDefaultAsync();

            if (course == null)
            {
                return NotFound();
            }

            return course;
        }

        /// <summary>
        /// Creates a new course.
        /// </summary>
        /// <param name="course">The course object to create.</param>
        [HttpPost]
        public async Task<ActionResult<Course>> CreateCourse(Course course)
        {
            await _courses.InsertOneAsync(course);
            return CreatedAtRoute("GetCourse", new { id = course.ClassId.ToString() }, course);
        }

        /// <summary>
        /// Updates details of an existing course.
        /// </summary>
        /// <param name="id">The ID of the course to update.</param>
        /// <param name="courseIn">The updated course object.</param>
        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> UpdateCourse(string id, Course courseIn)
        {
            var course = await _courses.Find<Course>(c => c.ClassId == id).FirstOrDefaultAsync();

            if (course == null)
            {
                return NotFound();
            }

            await _courses.ReplaceOneAsync(course => course.ClassId == id, courseIn);

            return NoContent();
        }

        /// <summary>
        /// Deletes a specific course by its ID.
        /// </summary>
        /// <param name="id">The ID of the course to delete.</param>
        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> DeleteCourse(string id)
        {
            var course = await _courses.Find<Course>(c => c.ClassId == id).FirstOrDefaultAsync();

            if (course == null)
            {
                return NotFound();
            }

            await _courses.DeleteOneAsync(course => course.ClassId == id);

            return NoContent();
        }
    }
}
