System Overview
The Coffee Machine API is a RESTful web service built in .NET Core that simulates an internet-connected coffee brewer. It relies on standard MVC Controller routing to handle HTTP GET requests at the /brew-coffee endpoint.

To handle complex business logic without losing state between web requests, the system utilizes Dependency Injection. It uses a Singleton service with thread-safe operations (Interlocked) to track the number of requests and trigger a 503 "Out of Coffee" error on every fifth call. It also integrates an asynchronous HttpClient service to fetch live weather data, dynamically altering the response payload to serve either "hot" or "iced" coffee based on the temperature, while also handling date-specific easter eggs (418 "I'm a teapot").

<img width="946" height="403" alt="image" src="https://github.com/user-attachments/assets/8549693b-b83a-4a51-9a4d-39f2241dd07c" />

