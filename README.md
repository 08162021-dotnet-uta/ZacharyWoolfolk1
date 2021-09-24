# Store Web Application API/JS
## Project Description
This is a ASP.NET Core API project utilizing Entity Framework Core, a SQL Database, and JavaScript front-end to create a Web Store Application that allows a user to create an account, view store locations, and create an order.

## Technologies Used
- C#
- ADO.NET Entity Framework
- HTML5
- Microsoft SQL Server
- JavaScript

## Features
- Account registration
- User login
- Store-specific product lists
- Order creation
- Persistent data

To-do list:
- Display order histories
- Update inventory
- Logging
- Exception handling
- Client-side validation

## Getting Started
Git clone command: git clone https://github.com/08162021-dotnet-uta/ZacharyWoolfolk1.git

In Microsoft SQL Server Management Studio, the database "StoreApplicationDB" must be created.  Then the commands in [DDL_P1.sql](https://github.com/08162021-dotnet-uta/ZacharyWoolfolk1/blob/main/DDL_P1.sql) must be executed.  The database can then be populated with the INSERT commands in [DML_P1.sql](https://github.com/08162021-dotnet-uta/ZacharyWoolfolk1/blob/main/DML_P1.sql).

The [project](https://github.com/08162021-dotnet-uta/ZacharyWoolfolk1/tree/main/projects/project_1/project_1) is located in the following directory: ZacharyWoolfolk1/projects/project_1/project_1.  The solution file found there can be opened in Microsoft Visual Studio.  There, the project can be run.

## Usage
When the project runs, a browser window opens onto a page with three buttons.  

The leftmost button simply displays a list of all registered customers.  The back button can be used to return to the original page.

The login and register buttons both bring the user to a name entry page.  The register page, however, enters the given name into the database, while the login page checks to make sure that the given name is already in the database.  Both pages lead to a store selection page.

On the store selection page is a list of hyperlinks.  Clicking on one takes the user to the products page for that particular store, where a product can be selected from another list of hyperlinks.  Clicking on one takes the user to another page to confirm the order.  After confirming, the user can use a button on the next page to return to the original page and start the process over if they wish.

## License
This project uses the following license: [MIT License](https://github.com/08162021-dotnet-uta/ZacharyWoolfolk1/blob/main/LICENSE).
