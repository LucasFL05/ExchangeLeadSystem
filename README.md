# ExchangeLeadSystem

Backend API for capturing, managing, and tracking leads for a currency exchange business.

## Overview

ExchangeLeadSystem is a RESTful API designed to help currency exchange companies organize client contacts, manage follow-ups, and monitor lead conversion efficiently.

This project was built with a focus on clean architecture, scalability, and real-world business scenarios, making it suitable both for portfolio demonstration and production environments (with proper configurations).

## Tech Stack

- .NET 10
- ASP.NET Core Web API
- Entity Framework Core
- SQLite (can be replaced with SQL Server or PostgreSQL)
- JWT Authentication
- Scalar (API documentation)

## Architecture

The project follows a layered architecture:

- **Controllers** → Handle HTTP requests and responses
- **Services** → Business logic
- **Domain** → Entities and Enums
- **Infrastructure** → Database and persistence
- **DTOs** → Data transfer objects
- **Middlewares** → Global error handling

## Design Principles

- Separation of concerns
- Clean code practices
- Centralized error handling
- DTO-based communication
- Scalable structure for future growth

## Features

- Public lead registration endpoint (for frontend integration)
- Lead lifecycle management (New, Contacted, Converted, Lost)
- Notes and interaction history per lead
- JWT authentication for protected endpoints
- Global exception handling middleware
- Standardized API responses
- Input validation
- Traceable error responses (TraceId)

## Authentication

The API uses JWT (JSON Web Token) for securing administrative endpoints.

## API Endpoints

### Auth

| Method | Route | Auth | Description |
|--------|-------|------|-------------|
| POST | /api/v1/auth/login | No | Authenticate and receive JWT |

### Leads

| Method | Route | Auth | Description |
|--------|-------|------|-------------|
| POST | /api/v1/leads | No | Create a new lead |
| GET | /api/v1/leads | Yes | Retrieve all leads |
| GET | /api/v1/leads/{id} | Yes | Retrieve lead by ID |
| PATCH | /api/v1/leads/{id}/status | Yes | Update lead status |
| POST | /api/v1/leads/{id}/notes | Yes | Add a note to a lead |

## API Documentation

After running the project, access:
```
http://localhost:5208/scalar
```

## Running Locally

### Prerequisites

- .NET 10 SDK

### Steps
```bash
# Clone the repository
git clone https://github.com/LucasFL05/ExchangeLeadSystem.git

# Navigate to the project folder
cd ExchangeLeadSystem

# Run the application
dotnet run
```

### Default Credentials
```
Email: admin@exchange.com
Password: admin123
```

> **Important:** change these credentials in production environments.

## Production Considerations

For production usage, consider:

- Secure environment variables (JWT secret, connection strings)
- Replace SQLite with a robust database (SQL Server or PostgreSQL)
- Implement logging (Serilog, ELK, etc.)
- Add rate limiting for public endpoints
- Strengthen authentication and password policies
- Enable HTTPS and proper CORS policies

## Future Improvements

- Pagination and filtering for leads
- Role-based authorization (RBAC)
- Integration with email or CRM systems
- Dashboard and analytics
- Unit and integration tests
- Docker support

## License

This project is intended for portfolio and educational purposes.
Production usage is allowed with proper adjustments and security practices.

## Author

Lucas Ferreira Lourenço