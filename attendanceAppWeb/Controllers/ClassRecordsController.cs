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
    public class ClassRecordsController : ControllerBase
    {
        private readonly IMongoClient _mongoClient;
        private readonly IMongoCollection<ClassRecords> _classRecords;

        public ClassRecordsController(IMongoClient mongoClient)
        {
            _mongoClient = mongoClient;
            var database = _mongoClient.GetDatabase("attendanceApp");
            _classRecords = database.GetCollection<ClassRecords>("ClassRecords");
        }

        /// <summary>
        /// Retrieves a specific classRecord by ID.
        /// </summary>
        /// <param name="id">The ID of the classRecord.</param>
        /// <returns>The classRecord details.</returns>
        [HttpGet("{id:length(24)}", Name = "GetClassRecord")]
        public async Task<ActionResult<ClassRecords>> GetClassRecord(string id)
        {
            var classRecord = await _classRecords.Find<ClassRecords>(c => c.ClassRecordId == id).FirstOrDefaultAsync();

            if (classRecord == null)
            {
                return NotFound();
            }

            return classRecord;
        }

        // evaluate if i really want to return the user I created

        /// <summary>
        /// Creates a new ClassRecord.
        /// </summary>
        /// <param name="classRecord">The ClassRecords object to create.</param>
        [HttpPost]
        public async Task<ActionResult<ClassRecords>> CreateClassRecord(ClassRecords classRecord)
        {
            await _classRecords.InsertOneAsync(classRecord);
            return CreatedAtRoute("GetClassRecord", new { id = classRecord.ClassRecordId.ToString() }, classRecord);
        }

        /// <summary>
        /// Updates details of an existing ClassRecords.
        /// </summary>
        /// <param name="id">The ID of the ClassRecords to update.</param>
        /// <param name="classRecordIn">The updated ClassRecords object.</param>
        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> UpdateClassRecord(string id, ClassRecords classRecordIn)
        {
            var classRecord = await _classRecords.Find<ClassRecords>(c => c.ClassRecordId == id).FirstOrDefaultAsync();

            if (classRecord == null)
            {
                return NotFound();
            }

            await _classRecords.ReplaceOneAsync(classRecord => classRecord.ClassRecordId == id, classRecordIn);

            return NoContent();
        }

        /// Business Rule: Shouldn't be used unless an administrator of the system is performing the action.
        /// <summary>
        /// Deletes a specific ClassRecord by its ID.
        /// </summary>
        /// <param name="id">The ID of the course to delete.</param>
        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> DeleteClassRecords(string id)
        {
            var classRecord = await _classRecords.Find<ClassRecords>(c => c.ClassRecordId == id).FirstOrDefaultAsync();

            if (classRecord == null)
            {
                return NotFound();
            }

            await _classRecords.DeleteOneAsync(student => classRecord.ClassRecordId == id);

            return NoContent();
        }
    }
}
