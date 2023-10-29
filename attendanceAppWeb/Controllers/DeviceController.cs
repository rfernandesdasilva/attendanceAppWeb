using attendanceAppWeb.Models.DeviceModels;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace attendanceAppWeb.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class DeviceController : ControllerBase
    {
        private readonly IMongoClient _mongoClient;
        private readonly IMongoCollection<Device> _devices;

        public DeviceController(IMongoClient mongoClient)
        {
            _mongoClient = mongoClient;
            var database = _mongoClient.GetDatabase("attendanceApp");
            _devices = database.GetCollection<Device>("Devices");
        }

        /// <summary>
        /// Retrieves a specific device by deviceID.
        /// </summary>
        /// <param name="id">The ID of the device.</param>
        /// <returns>The device details.</returns>
        [HttpGet("{id:length(24)}", Name = "GetDevice")]
        public async Task<ActionResult<Device>> GetDevice(string id)
        {
            var device = await _devices.Find<Device>(c => c.UserId == id).FirstOrDefaultAsync();

            if (device == null)
            {
                return NotFound();
            }

            return device;
        }

        /// <summary>
        /// Creates a new Device.
        /// </summary>
        /// <param name="device">The Device object to create.</param>
        [HttpPost]
        public async Task<ActionResult<Device>> CreateDevice(Device device)
        {
            await _devices.InsertOneAsync(device);
            return CreatedAtRoute("GetDevice", new { id = device.DeviceId.ToString() }, device);
        }

        /// <summary>
        /// Updates details of an existing Device.
        /// </summary>
        /// <param name="id">The ID of the device to update.</param>
        /// <param name="deviceIn">The device student object.</param>
        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> UpdateDevice(string id, Device deviceIn)
        {
            var device = await _devices.Find<Device>(c => c.DeviceId == id).FirstOrDefaultAsync();

            if (device == null)
            {
                return NotFound();
            }

            await _devices.ReplaceOneAsync(device => device.DeviceId == id, deviceIn);

            return NoContent();
        }

        /// <summary>
        /// Deletes a specific Device by its ID.
        /// </summary>
        /// <param name="id">The ID of the device to delete.</param>
        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> DeleteDevice(string id)
        {
            var device = await _devices.Find<Device>(c => c.UserId == id).FirstOrDefaultAsync();

            if (device == null)
            {
                return NotFound();
            }

            await _devices.DeleteOneAsync(device => device.DeviceId == id);

            return NoContent();
        }
    }
}
