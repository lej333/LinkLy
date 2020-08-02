# LinkLy
LinkLy is built to give you a possibility to self-host a link shortner application. 
- You can create multiple user accounts for your own customers.
- You can assign customer domains as base links.

This application is built with ASP.NET Core, so you can run this application on multiple platforms ie Linux and Windows. The SQL Server is currently the only supported database server to run this application. The support for other rational database servers will be added in the future versions.

### Techniques
LinkLy is built with the following techniques.
- ASP.NET Core MVC 3.1 (C#)
- Depencency Injection
- Repository Pattern
- Entity Framework Core
- Microsoft SQL Server

### Configurations
You need to change the following configuration settings in appconfig.json (make a copy of appconfig.example.json).
`{
  "ConnectionStrings": {
    "DefaultConnection": "{{ChangeThisWithConnectionString}}"
  },
  "Defaults": {
    "Domain": "k.swalbe.nl"
  }
}`

### Features in the future versions
- Support for Docker
- Support for Azure
- Support for MySQL, PostGreSQL, and MariaDB
- Implementation of admin and configuration sections
- Implementation of translations and customs
