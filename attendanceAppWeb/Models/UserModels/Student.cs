using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace attendanceAppWeb.Models.UserModels
{
    public class Student
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)] // Use MongoDB's ObjectId for the primary key
        public string UserId { get; set; }

        public string StudentFirstName { get; set; }
        public string StudentLastName { get; set; }

        public List<string> EnrolledClasses { get; set; }
        public Users user { get; set; }

        // should it be a list? or maybe just keep the actual one that is
        // authorized?
        public List<string> AuthorizedDevices { get; set; }

        // not sure if this will be used. need to think a bit about it
        // if the user tries to change the device, we compare the date he is trying to
        // change devices with the date he last changed device.

        // public DateTime LastDeviceChangeDate { get; set; }

        // settings?
        // somethig like public UserSettings Configuration { get;set;}

    }
}

