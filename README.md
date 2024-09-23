Here’s a refreshed version of the `README.md` for your JWT Authentication API project:

```markdown
# JWT Authentication API

This repository provides a **JWT Authentication API** built with ASP.NET Core. It demonstrates how to implement user registration, login, and secured endpoints using JSON Web Tokens (JWT).

## Table of Contents

- [Overview](#overview)
- [Features](#features)
- [Getting Started](#getting-started)
- [Configuration](#configuration)
- [API Endpoints](#api-endpoints)
- [Models](#models)
- [Running the Application](#running-the-application)
- [Testing](#testing)
- [Contributing](#contributing)
- [License](#license)

## Overview

The **JWT Authentication API** sample application showcases secure API authentication with JWT in .NET 5. It provides features for user registration, login, and access control through JWT tokens.

## Features

- **User Registration**: Allows new users to register with hashed passwords.
- **Login and JWT Generation**: Authenticates users and provides JWT tokens.
- **Role-Based Access Control**: Secures specific API endpoints based on user roles.
- **Protected API Endpoints**: Access is granted only with valid JWT tokens.

## Getting Started

### Prerequisites

Ensure you have the following installed:

- [.NET 5 SDK](https://dotnet.microsoft.com/download/dotnet/5.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- [Entity Framework Core Tools](https://docs.microsoft.com/en-us/ef/core/cli/dotnet)

### Clone the Repository

To clone the repository, run:

```bash
git clone https://github.com/SajidShahsroha/WebAPI.git
cd WebAPI/JWT
```

### Setting Up the Database

1. Configure your database connection string in the `appsettings.json` file:

   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=YOUR_SERVER_NAME;Database=JWTAuthDB;Trusted_Connection=True;"
   }
   ```

2. Run database migrations:

   ```bash
   dotnet ef migrations add InitialCreate
   dotnet ef database update
   ```

## Configuration

### appsettings.json

Update the `appsettings.json` file for JWT configuration:

```json
{
  "Jwt": {
    "Key": "YourSecretSigningKeyHere",
    "Issuer": "YourIssuer",
    "Audience": "YourAudience",
    "ExpiryMinutes": 60
  },
  "ConnectionStrings": {
    "DefaultConnection": "Server=YOUR_SERVER_NAME;Database=JWTAuthDB;Trusted_Connection=True;"
  }
}
```

- **Jwt:Key**: The secret key for signing JWT tokens.
- **Jwt:Issuer**: The issuer of the token.
- **Jwt:Audience**: The audience intended to consume the token.
- **Jwt:ExpiryMinutes**: Duration before token expiration.

## API Endpoints

### 1. **Employee Endpoints**

#### Get All Employees

- **Endpoint**: `GET /api/employee`
- **Description**: Retrieve a list of all employees.
- **Authorization**: Requires a valid JWT token.

#### Get Employee by ID

- **Endpoint**: `GET /api/employee/{id}`
- **Description**: Retrieve details of a specific employee by ID.
- **Authorization**: Requires a valid JWT token.

#### Add Employee

- **Endpoint**: `POST /api/employee`
- **Description**: Add a new employee.
- **Request Body**:
  ```json
  {
    "name": "string",
    "position": "string",
    "company": "string"
  }
  ```
- **Response**: Returns the added employee object.
- **Authorization**: Requires a valid JWT token.

#### Update Employee

- **Endpoint**: `PUT /api/employee/{id}`
- **Description**: Update details of an existing employee.
- **Request Body**:
  ```json
  {
    "name": "string",
    "position": "string",
    "company": "string"
  }
  ```
- **Response**: Returns the updated employee object.
- **Authorization**: Requires a valid JWT token.

#### Delete Employee

- **Endpoint**: `DELETE /api/employee/{id}`
- **Description**: Delete an employee by ID.
- **Response**: Returns true if deletion was successful.
- **Authorization**: Requires a valid JWT token.

### 2. **User Endpoints**

#### Login

- **Endpoint**: `POST /api/auth`
- **Description**: Authenticate a user and receive a JWT token.
- **Request Body**:
  ```json
  {
    "username": "string",
    "password": "string"
  }
  ```
- **Response**: Returns a JWT token if successful.

#### Add User

- **Endpoint**: `POST /api/auth/addUser`
- **Description**: Register a new user.
- **Request Body**:
  ```json
  {
    "name": "string",
    "email": "string",
    "password": "string"
  }
  ```
- **Response**: Returns the added user object.

## Models

### Employee Model

```csharp
public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Position { get; set; }
    public string Company { get; set; }
}
```

### User Model

```csharp
public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}
```

### Login Request Model

```csharp
public class LoginRequest
{
    public string Username { get; set; }
    public string Password { get; set; }
}
```

## Running the Application

1. Restore packages:

   ```bash
   dotnet restore
   ```

2. Run the application:

   ```bash
   dotnet run
   ```

The application will run on `https://localhost:5001` by default.

## Testing

You can test the API using tools like **Postman** or **curl**.

### Example:

1. **Login** using `/api/auth` to get the JWT token.
2. **Access Protected Routes** by including the token in the `Authorization` header:

   ```
   Authorization: Bearer {your_token}
   ```

## Contributing

Contributions are welcome! Please follow these steps:

1. Fork the repository.
2. Create a feature branch (`git checkout -b feature/new-feature`).
3. Commit your changes (`git commit -m 'Add new feature'`).
4. Push to the branch (`git push origin feature/new-feature`).
5. Open a Pull Request.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for more details.
```

Feel free to modify any sections as needed! If you need further adjustments, just let me know!
