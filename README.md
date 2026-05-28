System Overview
The Coffee Machine API is a RESTful web service built in .NET Core that simulates an internet-connected coffee brewer. It relies on standard MVC Controller routing to handle HTTP GET requests at the /brew-coffee endpoint.

To handle complex business logic without losing state between web requests, the system utilizes Dependency Injection. It uses a Singleton service with thread-safe operations (Interlocked) to track the number of requests and trigger a 503 "Out of Coffee" error on every fifth call. It also integrates an asynchronous HttpClient service to fetch live weather data, dynamically altering the response payload to serve either "hot" or "iced" coffee based on the temperature, while also handling date-specific easter eggs (418 "I'm a teapot").



Tools and Technologies Used
Tool / Technology	Category	Purpose in Project
Visual Studio 2026	IDE	The primary development environment used for writing, compiling, and managing the solution.
.NET 10.0 (C#)	Framework & Language	The core cross-platform framework and programming language powering the application.
ASP.NET Core	Web Framework	Provided the ControllerBase, routing attributes, and built-in JSON serialization for the API endpoint.
xUnit	Testing Framework	Used to structure, assert, and execute our automated unit tests.
Moq	NuGet Package	A mocking library used in our tests to fake the Counter and Weather services for isolated testing.
Open-Meteo API	External Service	A free, authentication-less third-party REST API used to fetch live temperature data.


Postman (or Swagger)	API Client	Used to manually send HTTP requests and verify the JSON payloads and status codes (200, 503, 418).
