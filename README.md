# LinkLy
LinkLy is built to give you a possibility to self-host a link shortner application. 
- You can create multiple user accounts for your own customers.
- You can assign customer domains as base links (branded links).

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

#### Connectionstring
Change the following connectionstring with connectionstring of your SQL Server.

`"ConnectionStrings": { "DefaultConnection": "{{change this with connectionstring}}" }`

#### Defaults
Change the following default in appsettings.config with your base domain name. This domain name will be used by default for all customers who will use your copy of LinkLy application.

`"Defaults": { "Domain": "{{your base domain}}" }`

### Features in the future versions
- Support for Docker
- Support for Azure
- Support for MySQL, PostGreSQL, and MariaDB
- Implementation of other admin and configuration sections
- Extended link statistics
- Referrers (social media, sms, email)
- Smart domain change/switch
- API
- Link tags
