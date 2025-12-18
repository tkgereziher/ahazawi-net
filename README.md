# Momona - Clean Architecture Solution

This solution is built using **Clean Architecture** principles with .NET 8.

## 🏗 Architecture Overview

The solution adheres to the Dependency Rule, where dependencies flow inwards. Core business logic is independent of frameworks and external concerns.

### 1. **Domain** (`Momona.Domain`)
- **Role**: The core of the application. Contains enterprise logic and types.
- **Contents**: Entities (`Student`, `Course`), Value Objects, Domain Events, and Aggregate Roots.
- **Dependencies**: None.

### 2. **Application** (`Momona.Application`)
- **Role**: Contains business logic and use cases. Orchestrates the flow of data.
- **Contents**: 
    - **Features** (Commands/Queries): Uses **CQRS** pattern providing specific handlers for operations.
    - **Behaviors**: Pipeline behaviors for Validation and Logging.
    - **Interfaces**: Abstractions for infrastructure (e.g., `IStudentRepository`, `ICurrentUser`).
- **Dependencies**: `Domain`.

### 3. **Infrastructure** (`Momona.Infrastructure`)
- **Role**: Implements interfaces defined in Application. Handles external concerns.
- **Contents**: 
    - **Persistence**: `AppDbContext` (EF Core), Repositories.
    - **Identity**: `CurrentUserService`.
    - **Files**: `FileStorageService`.
- **Dependencies**: `Application`, `Domain`.

### 4. **Api** (`Momona.Api`)
- **Role**: The entry point of the application.
- **Contents**: ASP.NET Core Web API Controllers, Filters, and Middleware.
- **Dependencies**: `Application`, `Infrastructure`.

## 🚀 Getting Started

### Prerequisites
- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- SQL Server (LocalDB or other)

### Build
Run the following command to build the solution:
```bash
dotnet build
```

### Database Setup
To create the database, run the following commands from the root folder:

```bash
# Create initial migration
dotnet ef migrations add InitialCreate -p Infrastructure -s Api

# Update database
dotnet ef database update -p Infrastructure -s Api
```

### Run
To start the API:
```bash
dotnet run --project Api/Momona.Api.csproj
```
The API will be available at `https://localhost:5001` (or similar, check console output).
API Documentation (Swagger) can be accessed at `/swagger`.

## 🛠 Technologies
- **ASP.NET Core 8 Web API**
- **Entity Framework Core 8** (SQL Server)
- **MediatR** (CQRS & Pipeline Behaviors)
- **FluentValidation** (Validation)
- **Swashbuckle** (Swagger/OpenAPI)

## 📂 Folder Structure
```
/
├── Domain/          # Enterprise Logic
├── Application/     # Business Logic & Use Cases
├── Infrastructure/  # External details (DB, File System)
├── Api/             # Entry Point (Controllers)
└── Momona.sln
```
