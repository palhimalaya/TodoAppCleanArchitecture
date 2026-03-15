# TodoApp

TodoApp is a layered ASP.NET Core Web API for managing todo items.

It uses:

- .NET 10
- ASP.NET Core Web API
- Entity Framework Core
- PostgreSQL via Npgsql
- Swagger for API exploration

## Project Structure

- `TodoApp.API` - API entry point, controller, configuration
- `TodoApp.Application` - application handlers and contracts
- `TodoApp.Domain` - core domain entities
- `TodoApp.Repository` - EF Core persistence and repository implementation

## Packages and References

### Project References

```bash
dotnet add TodoApp.Application reference TodoApp.Domain
dotnet add TodoApp.Repository reference TodoApp.Application
dotnet add TodoApp.API reference TodoApp.Application
dotnet add TodoApp.API reference TodoApp.Repository
```

### Package References

`TodoApp.API`

```bash
dotnet add TodoApp.API package Microsoft.AspNetCore.OpenApi --version 10.0.4
dotnet add TodoApp.API package Microsoft.EntityFrameworkCore.Design --version 10.0.5
dotnet add TodoApp.API package Swashbuckle.AspNetCore --version 10.1.5
```

`TodoApp.Application`

```bash
dotnet add TodoApp.Application package Microsoft.Extensions.DependencyInjection --version 10.0.5
```

`TodoApp.Repository`

```bash
dotnet add TodoApp.Repository package Microsoft.EntityFrameworkCore --version 10.0.5
dotnet add TodoApp.Repository package Microsoft.EntityFrameworkCore.Design --version 10.0.5
dotnet add TodoApp.Repository package Microsoft.EntityFrameworkCore.Tools --version 10.0.5
dotnet add TodoApp.Repository package Microsoft.Extensions.DependencyInjection --version 10.0.5
dotnet add TodoApp.Repository package Npgsql.EntityFrameworkCore.PostgreSQL --version 10.0.1
```

## Features

- Create a todo item
- Get all todo items
- Update a todo item
- Delete a todo item

## Prerequisites

- .NET 10 SDK
- PostgreSQL running locally

## Configuration

Create a local development config at `TodoApp.API/appsettings.Development.json` based on `TodoApp.API/appsettings.Development.example.json`.

Example:

```json
"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Port=5432;Database=todo_db;Username=your_username;Password=your_password"
}
```

## Run the Application

From the repository root:

```bash
dotnet build TodoApp.sln
dotnet run --project TodoApp.API --launch-profile http
```

The API runs on:

```text
http://localhost:5110
```

Swagger UI is available when the app is running:

```text
http://localhost:5110/swagger
```

## Run with Watch

For hot reload during development:

```bash
dotnet watch run --project TodoApp.API --launch-profile http -c Debug
```

If a package or assembly reference changes, `dotnet watch` may require a restart. In that case:

- Press `Ctrl+R` in the watch terminal to restart

## Database Migrations

The repository already contains an initial EF Core migration.

Useful commands:

```bash
dotnet ef database update --project TodoApp.Repository --startup-project TodoApp.API
dotnet ef migrations add <MigrationName> --project TodoApp.Repository --startup-project TodoApp.API
```

## API Endpoints

### Create Todo

```http
POST /api/todos
Content-Type: application/json

{
  "title": "Buy groceries"
}
```

### Get Todos

```http
GET /api/todos
```

### Update Todo

```http
PUT /api/todos/{id}
Content-Type: application/json

{
  "title": "Buy groceries and milk",
  "isCompleted": true
}
```

### Delete Todo

```http
DELETE /api/todos/{id}
```

## Todo Entity

Each todo item contains:

- `id`
- `title`
- `isCompleted`
- `createdAt`

## Notes

- The root endpoint `/` returns a simple test response.
- The API is currently configured for local development.