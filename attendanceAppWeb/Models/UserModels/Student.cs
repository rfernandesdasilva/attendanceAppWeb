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

        public List<CourseModels.Course> EnrolledClasses { get; set; }
        public List<string> Emails { get; set; }
        public List<string> AuthorizedDevices { get; set; }

    }
}

