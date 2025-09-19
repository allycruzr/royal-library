# Royal Library API

Personal book library API built with .NET 9, Entity Framework Core, and SQLite.

## Quick Start

```bash
cd src/RoyalLibrary.Api
dotnet restore
dotnet ef database update
dotnet run
```

API will be available at `http://localhost:5000`

## API Endpoint

**GET /api/books**

Query Parameters:
- `author` - Search by author name
- `isbn` - Search by ISBN prefix  
- `status` - Filter by ownership status: "own", "love", "want to read"
- `page` - Page number (default: 1)
- `pageSize` - Items per page (default: 10, max: 100)

Examples:
```
GET /api/books
GET /api/books?author=Harper
GET /api/books?status=own
GET /api/books?page=1&pageSize=5
```

## Configuration

- **Port:** 5000 (HTTP), 5001 (HTTPS)
- **Database:** SQLite (`library.db`)
- **CORS:** Enabled for `http://localhost:5173` (React)
- **Swagger:** Available at `/swagger`

## Sample Data

13 books with publishers and ownership status ("own", "love", "want to read").

## Architecture

- Repository Pattern
- Service Layer
- Dependency Injection
- Global Exception Handling
- Entity Framework Migrations
