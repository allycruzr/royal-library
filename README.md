# Royal Library

Personal book library system built with .NET 9 and React.

## Screenshot
<img width="1134" height="1120" alt="image" src="https://github.com/user-attachments/assets/aa010555-c505-4b9c-8340-679948dc9a54" />

## Features

- Search books by author, ISBN, or ownership status ("own", "love", "want to read")
- Paginated results with responsive design
- REST API with Swagger documentation

## Tech Stack

- **Backend:** .NET 9, Entity Framework Core, SQLite
- **Frontend:** React 19.1.1, TypeScript, Axios

## Quick Start

### Prerequisites
- .NET 9.0 SDK
- Node.js 16+

### Run Backend
```bash
cd backend/src/RoyalLibrary.Api
dotnet restore
dotnet ef database update
dotnet run
```
API: `http://localhost:5000`

### Run Frontend
```bash
cd frontend
npm install
npm start
```
App: `http://localhost:3000`

## API

**GET /api/books**
- `author` - Search by author name
- `isbn` - Search by ISBN prefix  
- `status` - Filter by ownership status
- `page` - Page number (default: 1)
- `pageSize` - Items per page (default: 10, max: 100)

**Examples:**
```
GET /api/books?author=Harper
GET /api/books?status=own
GET /api/books?page=1&pageSize=5
```

## Database

**SQLite** database (`library.db`) with 13 sample books. Includes realistic publishers and varied ownership status.

**Key Fields:**
- `title`, `first_name`, `last_name` - Book and author info
- `isbn`, `category`, `publisher` - Additional details
- `ownership_status` - "own", "love", "want to read"
- `total_copies`, `copies_in_use` - Inventory tracking

## Architecture

- **Backend:** Repository pattern, service layer, dependency injection
- **Frontend:** Component-based, TypeScript interfaces
- **Database:** Entity Framework migrations, indexed queries

## Documentation

- API docs: `http://localhost:5000/swagger`
- Database scripts: `backend/DatabaseScripts/`

## Testing

**Windows PowerShell:**
```powershell
# Backend tests
cd backend\src\RoyalLibrary.Api.Tests; dotnet test

# Frontend tests
cd frontend; npm test
```

**Linux/macOS:**
```bash
# Backend tests
cd backend/src/RoyalLibrary.Api.Tests && dotnet test

# Frontend tests  
cd frontend && npm test
```

