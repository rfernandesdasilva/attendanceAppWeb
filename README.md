# attendanceAppWeb

attendanceApp is an application designed for universities to facilitate marking presence for students, sharing some of the responsibility from the professor back to the students. 

Students will be utilizing the iOS version where depending on the professor's preferences, they will be utilizing different ways of verifying presence such as FaceID and QR Code Reading. For more about the iOS version, check: https://github.com/rfernandesdasilva/attendanceReportApp

# Features of the web-based project:
- Professors via the web-based application can create classes and manage students, schedules, and content for the lectures. 
- Professors can configure if they would like students to use Location Services, FaceID, or QRCode to verify campus presence.
- Professors can generate reports of student attendance, with visualizations.

This project is also the backbone of the iOS application. The API was developed in ASP.NET C# to perform database operations for the app, as well as more complex tasks as such QR code generation, report export (.xls), Login/Logout and so on.

The project is designed highly configurable, which would be beneficial for the implementation of new features and technologies that clients deem necessary.

# Technologies:
NoSQL MongoDB, Swagger, and OAuth 2.0 are being utilized in this project.


# Future implementations

- Administrators of courses view.
- Email-reminder service communicates absent students of their failure to attend class.
- Report service configured to generate visualizations.
