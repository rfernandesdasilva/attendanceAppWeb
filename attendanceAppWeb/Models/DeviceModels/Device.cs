using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace attendanceAppWeb.Models.DeviceModels
{
	public class Device
	{

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)] // Use MongoDB's ObjectId for the primary key
        public string DeviceId { get; set; }
        public string UserId { get; set; }

        // is DeviceName something needed?

        public DateTime DeviceAddedDate { get; set; }
        public DateTime DeviceLastUpdatedDate { get; set; }

        // not really sure how needed this will be
        public string DeviceDetails { get; set; }

        // If the user adds a new device, this must be changed to false.
        public bool IsActive { get; set; }
    }
}

