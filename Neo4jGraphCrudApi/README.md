# Clean Architecture Template (.NET 9)

A reusable ASP.NET Core Web API Clean Architecture template with:

- Clean Architecture
- Entity Framework Core
- SQL Server
- Serilog
- AutoMapper
- FluentValidation
- Swagger/OpenAPI
- JWT Authentication Infrastructure
- Global Exception Handling
- Dependency Injection Setup

---

# Prerequisites

- .NET SDK 9.0+
- Visual Studio 2022 / VS Code

---

# Install Template

Clone repository:

```bash
git clone https://github.com/<your-username>/clean-architecture-template.git
```

Install template:

```bash
dotnet new install <path-to-template>
```

Example:

```bash
dotnet new install C:\Users\hp\Desktop\Neo4jGraphCrudApi
```

---

# Verify Template Installation

```bash
dotnet new list
```

Expected output:

```text
Clean Architecture Template
Short Name: cleanarch
```

---

# Create New Project

Navigate to desired location:

```bash
cd C:\Projects
```

Create project:

```bash
dotnet new cleanarch -n EmployeeManagement
```

This generates:

```text
EmployeeManagement
│
├── EmployeeManagement.API
├── EmployeeManagement.Application
├── EmployeeManagement.Domain
├── EmployeeManagement.Infrastructure
└── EmployeeManagement.sln
```

---

# Open Project

```bash
cd EmployeeManagement
```

VS Code:

```bash
code .
```

Visual Studio:

```bash
start EmployeeManagement.sln
```

---

# Build Project

```bash
dotnet build
```

Run API:

```bash
dotnet run --project EmployeeManagement.API
```

---

# Folder Structure

```text
API
├── Controllers
├── Middleware

Application
├── DTOs
├── Interfaces
├── Services
├── Validators
├── Mappings

Domain
├── Entities

Infrastructure
├── Data
├── Repositories
├── Migrations
```

---

# JWT Authentication

The template already contains:

- JWT Configuration
- Authentication Middleware
- Authorization Middleware
- Token Validation
- JWT Packages

Configured in:

## Program.cs

```csharp
builder.Services.AddAuthentication(...);
builder.Services.AddJwtBearer(...);

app.UseAuthentication();
app.UseAuthorization();
```

## appsettings.json

```json
{
  "AppSettings": {
    "Token": "CHANGE_ME",
    "Issuer": "YOUR_ISSUER",
    "Audience": "YOUR_AUDIENCE"
  }
}
```

---

# Implement JWT Authentication

## Step 1: Create User Entity

```csharp
public class User
{
    public int Id { get; set; }
    public string Username { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
}
```

---

## Step 2: Create Login DTO

```csharp
public class LoginDto
{
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}
```

---

## Step 3: Create Token Service

```csharp
public interface ITokenService
{
    string CreateToken(User user);
}
```

---

## Step 4: Register Services

```csharp
builder.Services.AddScoped<ITokenService, TokenService>();
```

---

## Step 5: Create Auth Controller

```csharp
[HttpPost("login")]
public IActionResult Login(LoginDto dto)
{
    // Validate user

    var token = _tokenService.CreateToken(user);

    return Ok(token);
}
```

---

# Update Template

If template changes:

Uninstall:

```bash
dotnet new uninstall Shubham.CleanArchitecture
```

Reinstall:

```bash
dotnet new install C:\Users\hp\Desktop\Neo4jGraphCrudApi
```

---

# Create Another Project

```bash
dotnet new cleanarch -n InventoryManagement
```

```bash
dotnet new cleanarch -n HospitalManagement
```

```bash
dotnet new cleanarch -n LeaveManagement
```

---

# Author

Shubham