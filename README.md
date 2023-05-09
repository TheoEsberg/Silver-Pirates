# Silver-Pirates
This is a group project in the [Advanced .NET](https://qlok.notion.site/6-Avancerad-NET-d7035129aa1f46608d36dc8333dd1ecd) course organized by Campus Varberg for the students that are studying ".NET Systemdevelopment." We are three students working on this project, Theo Esberg, Lucas Person Öhlin and Emil Treptow.

  
## Table of Contents  
- [What it is about](#what-it-is-about) 
- [Todo List](#todo-list) 
- [Database Design](#database-design) 
- - [UML](#uml) 
- - [Employee](#employee) 
- - [Project](#project) 
- - [HourReport](#hourreport) 
- - [EmployeeProject](#employeeproject) 
- [DbContext](#dbcontext)
- [API Calls from Postman](#api-calls-from-postman)
- - [Employee API Calls](#employee-api-calls)
- - [Project API Calls](#project-api-calls)
- - [Hour Report API Calls](#hour-report-api-calls)
- [Contributors](#contributors)
- [NuGet Packages](#nuget-packages)
- - [Required NuGet Packages](#required-nuget-packages)
- - [Code to Inject NuGet Packages](#code-to-inject-nuget-packages)

## What it is about
The goal with this group project is to create a REST API with a database, fulfill the [criterias](https://qlok.notion.site/Projekt-Avancerad-NET-3017bd886c2646dda6e6424bd8f01cec) for the API and test our API with [Swagger](https://swagger.io/) and [Postman](https://www.postman.com/).

## Todo List
- [x] Create a UML for the database
- [x] Start the project in Visual Studio and post it to GitHub 
- [x] Start another project (Class Library) in the same Solution
- [x] Import the Entity Framework NuGet Packages
- [x] Create the database with Entity Framework
- [x] Add a DbContext to fill the database
- [x] Seed dummy data in the DbContext
- [x] Structure the project with Services, Models and Controllers folders
- [x] Create a Interface for each table
- [x] Create a Repository for each table
- [x] Create a Controller for each table
- [x] Add the ability to get all HourReports, Projects, Employees and EmployeeProjects 
- [x] Create the ability to Add, Update and Remove an entity in each table
- [x] Add the ability to get the total Hours Worked for each Employee for a specific week
- [ ] Test the API with Postman and Swagger
- [ ] Try to find and fix all eventual bugs
- [ ] Prettify the code <3
- [ ] Write the README file

## Database Design
Our database is constructed with three main tables and one connection table. The three main tables are Employee, Project and HourReport while the connection table is called EmployeeProject. 
### UML
![UML of our database](https://user-images.githubusercontent.com/113690228/236836776-7f4f39dc-77bc-4d21-8896-832ad0c80737.png)
### Employee
The Employee table is constructed with a primary key as int EmployeeId, a string Name, an ICollection of EmployeeProject and an ICollection of HourReport. 

![Employee Table Entity Framework](https://media.discordapp.net/attachments/811686462184882177/1105495673517908149/image.png)

### Project
The Project table has a primary key as int ProjectId, a string Name and an ICollection of EmployeeProject.

![Project Table Entity Framework](https://media.discordapp.net/attachments/811686462184882177/1105495672972644402/image.png)

### HourReport 
The HourReport has a primary key as int ReportId, an int EmployeeId, a DateTime DateWorked and an double HoursWorked.

![HourReport Table Entity Framework](https://media.discordapp.net/attachments/811686462184882177/1105495672645492846/image.png)

### EmployeeProject 
EmployeeProject have a many-to-many relation to both the Employee and Project tables. Employee have a one-to-many relation to HourReport. This means that one Employee can have many HourReports. One Employee can also have many EmployeeProjects. 

![Employee Table Entity Framework](https://media.discordapp.net/attachments/811686462184882177/1105495673253671064/image.png)

## DbContext
We used a DbContext file called AppDbContext to create and seed data into our database. The DbContext file has one DbSet of each table as in the picture below.

We seed the data of Employee, Projects, Hour Reports and Employee Project to easy and simply test our API. 
![DbContext File](https://cdn.discordapp.com/attachments/811686462184882177/1105536665470111764/image.png)

## API Calls from Postman
This is a gathered list of all of the avalible Postman API calls that you can do to get a response. 
The stars * in &darr; 
``` 
https://localhost:****/ 
``` 
are the Port that your API is currently hosted on. There are also some other things like &darr; 
```
/id(id)/(newName)
``` 
for example. The (id) is the Id you should provide and the (newName) is where you put your newName. Remember to remove the parentheses ( ) when executing the API call. 
For example this  &darr;
``` 
https://localhost:****/UpdateNameOfEmployee/id(id)/(newName) 
``` 
could look something like this &darr;
``` 
https://localhost:1234/UpdateNameOfEmployee/id7/FaaBar
```

### Employee API Calls
&darr; Get all Employees  &darr;
``` 
https://localhost:****/api/Employee 
```

&darr; Get Employee by Id &darr;
``` 
https://localhost:****/GetEmployee/id(id)
```

&darr; Change name of Employee &darr;
```
https://localhost:****/UpdateNameOfEmployee/id(id)/(newName) 
```

&darr; Delete Employee by Id &darr;
``` 
https://localhost:****/DeleteEmployee/id(id) 
```

&darr; Get all Employee on a Project with Id &darr;
``` 
https://localhost:****/GetEmployeesForProject/id(id) 
```

### Project API Calls
&darr; Get all Projects  &darr;
```
https://localhost:****/api/Project 
```

&darr; Get a Project by Id &darr;
``` 
https://localhost:****/api/Project/ProjectId?id=(id) 
```

&darr; Update the name of Project &darr;
``` 
https://localhost:****/UpdateNameOfProject/id(id)/(newName) 
```

&darr; Delete a Project &darr;
``` 
https://localhost:****/DeleteProject/id(id) 
```

### Hour Report API Calls
&darr; Get all Hour Reports  &darr;
``` 
https://localhost:****/api/HourReport 
```

&darr; Get Hour Report with Id  &darr;
``` 
https://localhost:****/api/HourReport/HourReportId?id=(id) 
```

&darr; Get all Hour Reports for Employee with Id &darr;
``` 
https://localhost:****/EmployeeHourReport/id(id) 
```

&darr; Get all Hours Worked in a specific week for a Employee with Id  &darr;
``` 
https://localhost:****/EmployeeHourReport/id(id)/week(week) 
```

&darr; Update a Hour Report with ReportId, EmployeeId and a new DateTime &darr;
``` 
https://localhost:****/UpdateHourReport/id(reportId)/employeeId/date?employeeId=(employeeId)&date=(date) 
```

&darr; Delete a Hour Report by Id  &darr;
``` 
https://localhost:****/DeleteHourReport/id(id) 
```

### Employee Project API Calls
&darr; Get Employee Projects &darr;
``` 
https://localhost:****/api/EmployeeProject 
```

&darr; Get Employee Projects by Id &darr;
``` 
https://localhost:****/GetEmployeeProject/id(id) 
```

&darr; Update Employee Projects &darr;
``` 
https://localhost:****/UpdateEmployeeProject/id(id)/employeeId/projectId?employeeId=(id)&projectId=(id) 
```

## Contributors 
This is the amazing people that worked and contributed to the Silver Pirates group project.

| | | | | |
| --- | --- | --- | --- | --- |
| | <img src="https://avatars.githubusercontent.com/u/58995506?v=4" width="100" height="100"> | **Theo Esberg** | [Theo Esberg](https://github.com/TheoEsberg) |
| | <img src="https://avatars.githubusercontent.com/u/113690228?v=4" width="100" height="100"> | **Lucas Person Öhlin** | [Lucas Person Öhlin](https://github.com/lucas-ohlin) |
| | <img src="https://avatars.githubusercontent.com/u/114058299?v=4" width="100" height="100"> | **Emil Treptow** | [Emil Treptow](https://github.com/Lykrat) |
| | | | | |

## NuGet Packages
There are a couple of NuGet Packages Required to run this application. 

### Required NuGet Packages
* Microsoft.EntityFrameworkCore
* Microsoft.EntityFrameworkCore.Design
* Microsoft.EntityFrameworkCore.SqlServer
* Microsoft.EntityFrameworkCore.Tools

### Code to Inject NuGet Packages
To install the NuGet Packages without the NuGet Package Manager you can copy ( CTRL + C ) and paste 
( CTRL ? V ) into the Package Manager Console in Visual Studio.
```
NuGet\Install-Package Microsoft.EntityFrameworkCore -Version 7.0.5 
NuGet\Install-Package Microsoft.EntityFrameworkCore.Design -Version 7.0.5 
NuGet\Install-Package Microsoft.EntityFrameworkCore.Tools -Version 7.0.5 
NuGet\Install-Package Microsoft.EntityFrameworkCore.SqlServer -Version 7.0.5
```
