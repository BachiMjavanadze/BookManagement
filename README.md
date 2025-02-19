# Book Management API

The Book Management API is a RESTful service built with ASP.NET Core (.NET 8) that allows managing books. It supports CRUD operations—including bulk add and soft deletion—while calculating a book's popularity score dynamically based on its view count and publication year. Additionally, the API implements user authentication using JWT tokens.

## Features

* Complete CRUD operations for books
* Single and bulk operations support
* Authentication using JWT tokens
* Automatic popularity score calculation
* Soft delete functionality
* Swagger documentation
* Global exception handling
* Input validation
* Pagination support

## Technology Stack

* .NET 8
* ASP.NET Core Web API
* Entity Framework Core
* SQL Server
* JWT for authentication
* Swagger/OpenAPI for documentation

## Project Structure

The solution follows a clean 3-layer architecture:

* **API Layer** (BookManagement.API)
  * Controllers
  * Middleware
  * Configuration

* **Core Layer** (BookManagement.Core)
  * Models
  * DTOs
  * Interfaces
  * Mappers
  * Custom Attributes
  * Exceptions

* **Infrastructure Layer** (BookManagement.Infrastructure)
  * Data Access
  * Repositories
  * Services
  * Database Migrations

## Getting Started

### Prerequisites

* .NET 8 SDK
* SQL Server (LocalDB or full instance)
* Visual Studio 2022 or any preferred IDE

### Database Setup

Apply Migrations and Update the Database:
```bash
Update-Database
```

### Running the Application

1. Run the API.

3. Navigate to `https://localhost:7271/swagger/index.html` to access the Swagger UI.

## Authentication

The API uses JWT Bearer token authentication. To access protected endpoints:

1. Register a new user using the `/api/Auth/register` endpoint
2. Login using the `/api/Auth/login` endpoint to get a JWT token
3. In Swagger UI:
   * Click the "Authorize" button (🔓)
   * Enter your token in the format: `Bearer your-token-here`
   * Click "Authorize"

## API Endpoints

### Authentication
* POST `/api/Auth/register` - Register a new user
* POST `/api/Auth/login` - Login and receive JWT token

### Books
* GET `/api/Books` - Get paginated list of books sorted by popularity
* GET `/api/Books/{id}` - Get book details by ID
* GET `/api/Books/search` - Search books by title or author
* POST `/api/Books` - Create a new book
* POST `/api/Books/bulk` - Create multiple books
* PUT `/api/Books/{id}` - Update a book
* DELETE `/api/Books/{id}` - Soft delete a book
* DELETE `/api/Books/bulk` - Soft delete multiple books

## Book Popularity Calculation

Book popularity is calculated using the formula:
```
Popularity Score = (BookViews * 0.5) + (YearsSincePublished * 2)
```

* `BookViews`: Number of times the book details have been accessed
* `YearsSincePublished`: Current year minus publication year

## Validation Rules

### Books
* Title must be unique
* Title and Author name must be between 1-50 characters
* Publication year cannot be in the future

### User Registration
* Username must be between 1-50 characters
* Username can only contain letters, numbers, underscores, and hyphens
* Password must be between 6-100 characters
* Password must contain at least:
  * One uppercase letter
  * One lowercase letter
  * One number
  * One special character

## Error Handling

The API uses a global exception handler that returns consistent error responses:

```json
{
    "statusCode": 400,
    "message": "Error details here"
}
```

Common status codes:
* 200 - Success
* 201 - Created
* 400 - Bad Request
* 401 - Unauthorized
* 404 - Not Found
* 409 - Conflict (e.g., duplicate book title)
* 500 - Internal Server Error

