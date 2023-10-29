using attendanceAppWeb.Models.UserModels;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace attendanceAppWeb.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IMongoClient _mongoClient;
        private readonly IMongoCollection<Student> _students;

        public StudentController(IMongoClient mongoClient)
        {
            _mongoClient = mongoClient;
            var database = _mongoClient.GetDatabase("attendanceApp");
            _students = database.GetCollection<Student>("Students");
        }

        /// <summary>
        /// Retrieves a specific student by ID.
        /// </summary>
        /// <param name="id">The ID of the stuendt.</param>
        /// <returns>The student details.</returns>
        [HttpGet("{id:length(24)}", Name = "GetStudent")]
        public async Task<ActionResult<Student>> GetStudent(string id)
        {
            var course = await _students.Find<Student>(c => c.UserId == id).FirstOrDefaultAsync();

            if (course == null)
            {
                return NotFound();
            }

            return course;
        }

        // evaluate if i really want to return the user I created

        /// <summary>
        /// Creates a new Student.
        /// </summary>
        /// <param name="student">The Student object to create.</param>
        [HttpPost]
        public async Task<ActionResult<Student>> CreateStudent(Student student)
        {
            await _students.InsertOneAsync(student);
            return CreatedAtRoute("GetStudent", new { id = student.UserId.ToString() }, student);
        }

        /// <summary>
        /// Updates details of an existing Student.
        /// </summary>
        /// <param name="id">The ID of the student to update.</param>
        /// <param name="studentIn">The updated student object.</param>
        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> UpdateStudent(string id, Student studentIn)
        {
            var course = await _students.Find<Student>(c => c.UserId == id).FirstOrDefaultAsync();

            if (course == null)
            {
                return NotFound();
            }

            await _students.ReplaceOneAsync(course => course.UserId == id, studentIn);

            return NoContent();
        }

        /// <summary>
        /// Deletes a specific Student by its ID.
        /// </summary>
        /// <param name="id">The ID of the course to delete.</param>
        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> DeleteStudent(string id)
        {
            var course = await _students.Find<Student>(c => c.UserId == id).FirstOrDefaultAsync();

            if (course == null)
            {
                return NotFound();
            }

            await _students.DeleteOneAsync(course => course.UserId == id);

            return NoContent();
        }
    }
}
