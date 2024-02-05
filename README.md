# attendanceAppWeb

attendanceApp is an application designed for universities to facilitate marking presence for students, sharing some of the responsibility from the professor back to the students. 

Students will be utilizing the iOS version where depending on the professor's preferences, they will be utilizing different ways of verifying presence such as FaceID and QR Code Reading. For more about the iOS version, check: https://github.com/rfernandesdasilva/attendanceReportApp

Professors via the web-based application will be creating classes, and managing students, schedules, and content for the lectures. Professors will be able to configure if they would like students to use Location Services, FaceID, or QRCode to verify campus presence.

API developed in ASP.NET C# to perform database operations for the iOS application, as well as more complex tasks as such QR code generation, report export (.xls), and so on.

# Technologies:
NoSQL MongoDB, Swagger, and OAuth 2.0 are being utilized in this project.


# Future implementations

- Administrators of courses view.
- Email-reminder service communicates absent students of their failure to attend class.
