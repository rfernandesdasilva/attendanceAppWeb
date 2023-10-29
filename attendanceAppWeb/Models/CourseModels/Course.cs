using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

// this entity will be the one defining the db object

namespace attendanceAppWeb.Models.CourseModels
{
    public class Course // // 
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)] // Use MongoDB's ObjectId for the primary key
        public string ClassId { get; set; }

        public string ClassName { get; set; }

        // should I add classesDayOfWeek? a list of days that has the class maybe, enums

        public DateTime ClassStartTime { get; set; }

        public DateTime ClassEndTime { get; set; }

        public DateTime ClassTermStart { get; set; }

        public DateTime ClassTermEnd { get; set; }

        public List<string> ClassStudentIds { get; set; }
    }
}


