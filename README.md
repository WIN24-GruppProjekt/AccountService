# AccountService

Simple ASP.NET Core Identity + JWT project.
(project was developed using Rider on macOS)

## Summary
- Provides registration endpoints for `Instructor` and `Customer`.
- Login endpoint issues JWTs.
- Uses Entity Framework Core with SQL Server and ASP.NET Core Identity.

## Prerequisites
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