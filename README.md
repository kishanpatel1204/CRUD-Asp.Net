# CRUD Operations in ASP.NET
# Employees Managment System


# Overview
- This project demonstrates how to perform CRUD (Create, Read, Update, Delete) operations in ASP.NET. CRUD operations are fundamental to many web applications, allowing users to interact with data stored in a database.

# Roles and Features
# Employee
- Role-based login for employees, managers, and admins.
- Ability for employees to change their password after identity verification.
- Access to view their assigned manager.
- Logout functionality for employees.
# Admin
- Login functionality for administrators using their ID and password.
- Registration capability for new employees and managers.
- Assignment of employees to specific departments and managers upon registration.
- Updating employee positions and salaries.
- Creation of new departments as needed.
- Viewing the position history of employees from registration.
- Viewing the manager of an employee from registration.
- Access to a help page for system support.
- Logout functionality for administrators.

# Technologies Used
- ASP.NET MVC (Model-View-Controller) framework
- C# programming language
- Entity Framework for data access
- SQL Server for database management

# Prerequisites
- Before running this project, ensure you have the following installed:
  - Visual Studio (preferably the latest version)
  - .NET SDK
  - SQL Server Management Studio (SSMS) or any other database management tool

# Setup Instructions
1. Clone the repository to your local machine:
bash
Copy code
git clone https://github.com/kishanpatel1204/CRUD-Asp.Net
2. Open the solution file (ProjectEMS.sln) in Visual Studio.
3. Update the connection string in Web.config file to point to your SQL Server instance.
4. Open Package Manager Console (Tools -> NuGet Package Manager -> Package Manager Console) and run the following command to create the database:
bash
Copy code
Update-Database
5. Build the solution (Build -> Build Solution) to ensure all dependencies are resolved.
6. Run the application (Debug -> Start Debugging) or (Debug -> Start Without Debugging).

# Usage
- Follow the appropriate login process based on the user role (employee, manager, admin).
- Perform the designated actions based on the role's features and responsibilities.
- Logout from the system once tasks are completed.

# Project Structure
- Controllers: Contains the ASP.NET MVC controllers responsible for handling requests and generating responses.
- Models: Defines the data model classes used by the application.
- Views: Contains the HTML templates and Razor syntax used to generate the user interface.
- Scripts: Contains client-side JavaScript files.
- Styles: Contains CSS files for styling the application.

# Contributing
Contributions are welcome! If you'd like to enhance the project or fix any issues, feel free to fork the repository and submit a pull request.

# Acknowledgements
- ASP.NET documentation
- Entity Framework documentation
- Microsoft Visual Studio

# Contact
For any questions or feedback, please feel free to contact me.

