# Course-Registration
Course-Registration is an ASP.NET Core MVC Web application having Student, Instructor and Course endpoints.
It uses code-first EF Core approach and Migrtation technique for connection with MS Sql Server database on the local host.
The app simply depicts RESTfull Web API to add functionality for performing CRUD operations on Student, Instructor and Course by Http GET and POST method in its General Controller.
Student and Course implements many-to-many relationship in the database. It utilizes Typescript for basic input validation for various fields while registering a new Student, Instructor and Course.
It uses DTO classes for the user to communicate with the API. AutoMapper Nuget package is being used for mpping the DTO's with actual objects that communicate with database.
