using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace attendanceAppWeb.Models.UserModels
{
    public class Users
    {
        public string userEmail { get; set; }
        public string userPassword { get; set; }
    }
}

