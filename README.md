# AccountService

Simple ASP.NET Core Identity + JWT project. Provides registration 
for Instructor and Customer, plus login that issues JWTs.
(developed using Rider on macOS)

## Summary
- Provides registration endpoints for `Instructor` and `Customer`.
- Login endpoint issues JWTs.
- Uses Entity Framework Core with SQL Server and ASP.NET Core Identity.
# Structure
```bash
AccountService/
 ├── Controllers/      # API endpoints
 ├── Models/           # Entities & DTOs
 ├── Services/         # Business logic
 ├── Data/             # DbContext & Migrations
 ├── Validators/       # Validation of DTOs
 ├── Program.cs        # App startup
 └── appsettings.json  # Config (connection string + JWT)

```

## Prerequisites
- .NET 9
- SQL Server accessible (local or remote)

## Configuration
Update `appsettings.json` (or environment variables) with a `Jwt` section and a connection string:

Example `appsettings.json` snippet:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "your_connection_string"
  },
  "Jwt": {
    "Key": "32_characters_long_random_secret_key",
    "Issuer": "Issuer",
    "Audience": "Audience",
    "ExpiresHours": "1"
  }
}
```

Run:
```bash
git clone https://github.com/WIN24-GruppProjekt/AccountService.git
cd AccountService/AccountService
dotnet ef database update
dotnet run
```
## API 
- Registration (Instructor / Customer)
- Login → returns { token, expires }
- Use on frontend: Authorization: Bearer <token>
```http
POST /api/Register/instructor
Content-Type: application/json

{
  "email": "instructor@example.com",
  "password": "Str0ng!Pass",
  "firstName": "Jane",
  "lastName": "Doe"
}
```
```http
POST /api/Register/customer
Content-Type: application/json

{
  "email": "customer@example.com",
  "password": "Str0ng!Pass",
  "firstName": "John",
  "lastName": "Doe"
}
```
```http
POST /api/Login
Content-Type: application/json

{
  "email": "instructor@example.com",
  "password": "Str0ng!Pass"
}
```
## Team Workflow
- Backend: Identity, JWT, DB schema/migrations
- Frontend: Forms, token storage, role-dependent UI

## Usefull Links
- [Microsoft Identity](https://learn.microsoft.com/en-gb/aspnet/core/security/authentication/identity?view=aspnetcore-9.0&tabs=visual-studio)
- [JWT](https://www.jwt.io/introduction#what-is-json-web-token)
