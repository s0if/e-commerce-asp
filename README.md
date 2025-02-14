# Project Title: Secure ASP.NET Application with Logging and Error Handling
# Project Description
This project develops a robust ASP.NET web application focused on secure communication and reliable data handling. It features advanced logging, comprehensive error handling, and JWT-based authentication to enhance security across all routes and resources.
# Key Features
## JWT Authentication
- Security: Implements JWT to provide a scalable and secure authentication and authorization mechanism.
- Token Management: Generates tokens on user login, using them for session verification on protected endpoints and implementing token refresh to enhance security.
## Error Handling
- Centralized Error Management: Uses middleware to systematically manage exceptions and improve reliability.
- User Experience: Enhances user interaction by providing clear, actionable feedback during errors while maintaining security by not exposing sensitive data.
## Logging
- Advanced Logging: Incorporates frameworks like Serilog or NLog to log detailed application activities and errors.
- Diagnostic Support: Configures logs to include essential information for quick issue resolution.
- External Systems: Utilizes systems like Elasticsearch for log aggregation and analysis, ensuring scalability and searchability.
## Technologies
- ASP.NET Core: Serves as the backbone for server-side logic, ensuring performance and scalability.
- Entity Framework Core: Provides robust ORM capabilities for efficient database interactions.
- JWT Bearer: Manages JWTs for securing RESTful APIs.
- Serilog/NLog: Facilitates sophisticated logging with features such as structured logging and diverse output targets.
## Project Outcomes
- Security: Establishes secure user authentication and authorization with JWT.
- Reliability: Achieves improved application reliability through meticulous logging and error handling.
- Middleware Development: Creates reusable middleware components for logging and error handling that can be used in future projects.

# Setup and Configuration
#### Clone the repository
- git clone https://github.com/s0if/e-commerce-asp.git

#### Navigate to the project directory
- cd E-commerce-API

#### Install dependencies
- dotnet restore

#### Run the application
- dotnet run
