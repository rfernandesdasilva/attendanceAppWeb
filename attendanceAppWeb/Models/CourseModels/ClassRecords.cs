using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace attendanceAppWeb.Models.CourseModels
{
	public class ClassRecords
	{
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)] // Use MongoDB's ObjectId for the primary key
        public string ClassRecordId { get; set; }

        public string CourseId { get; set; }

        // should I add classesDayOfWeek? a list of days that has the class maybe, enums

        public DateTime RecordCreationTime { get; set; }

        public DateTime RecordClosureTime { get; set; }

        
        // I want to add the time that the student marked attendance.
        // the decision between being on the OnTime list and the Late List is made
        // by the iOS when comparing the time of start and the time it currently is.
        // Maybe create an Object just for StudentAttendance? it would have only two
        // fields: studentId and timeOfAttendance

        // think about if this can be done in the API maybe. Idk
        public List<string> ClassOnTimeStudents { get; set; }
        public List<string> ClassLateStudents { get; set; }
    }
}

