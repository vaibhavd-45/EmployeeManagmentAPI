# Employee Management System API

## Overview
The **Employee Management System API** is a RESTful API designed for managing employee data in an organization. The API follows modern best practices such as:

✅ .NET 8 Web API
✅ CRUD Operations
✅ Dependency Injection
✅ SOLID Principles
✅ Entity Framework Core for database interaction
✅ JWT Authentication for security
✅ Swagger for API documentation

---

## Features
- **Employee Management:** Perform Create, Read, Update, and Delete operations on employee data.
- **Authentication:** Uses JWT for secure API access.
- **Dependency Injection:** Ensures code maintainability and scalability.
- **SOLID Principles:** Clean, organized, and scalable design.
- **SQL Database Integration:** Efficient database interaction using Entity Framework Core.

---

## Technologies Used
- **.NET 8 Web API**
- **Entity Framework Core**
- **SQL Server**
- **JWT Authentication**
- **Swagger (Swashbuckle)**

---

## Project Structure
```
├── Controllers
│   └── EmployeesController.cs
│   └── AuthController.cs
│
├── Data
│   └── ApplicationDbContext.cs
│
├── Models
│   └── Employee.cs
│   └── User.cs
│
├── Services
│   └── IEmployeeService.cs
│   └── EmployeeService.cs
│   └── IAuthService.cs
│   └── AuthService.cs
│
├── DTOs
│   └── EmployeeDTO.cs
│   └── UserLoginDTO.cs
│   └── UserRegisterDTO.cs
│
├── Helpers
│   └── JwtHelper.cs
│
├── Program.cs
├── appsettings.json
```

---

## Database Design
**Employee Table Structure:**
| Column        | Type         | Constraints |
|----------------|--------------|--------------|
| Id             | int           | Primary Key, Auto-Increment |
| FirstName       | string        | Required |
| LastName        | string        | Required |
| Email           | string        | Required, Unique |
| DateOfBirth     | DateTime      | Required |
| Position        | string        | Required |
| Salary          | decimal       | Required |

---

## Endpoints
### **Authentication Endpoints**
| HTTP Verb | Endpoint               | Description                     |
|------------|------------------------|---------------------------------|
| `POST`      | `/api/auth/register-hr` | Register an HR (Admin only)     |
| `POST`      | `/api/auth/login`       | Authenticate and generate JWT   |

### **Employee Endpoints**
| HTTP Verb | Endpoint                | Description                      |
|------------|------------------------|----------------------------------|
| `GET`       | `/api/employees`        | Fetch all employees             |
| `GET`       | `/api/employees/{id}`   | Fetch an employee by ID         |
| `POST`      | `/api/employees`        | Create a new employee            |
| `PUT`       | `/api/employees/{id}`   | Update an employee by ID         |
| `DELETE`    | `/api/employees/{id}`   | Delete an employee by ID         |

---

## Installation Instructions
### **Step 1: Clone the Repository**
```bash
git clone <repository-url>
cd Employee_Management_System_API
```

### **Step 2: Setup Database Configuration**
1. Open the `appsettings.json` file.
2. Add your SQL Server connection string under `"ConnectionStrings"`:
```json
"ConnectionStrings": {
    "DefaultConnection": "Server=DESKTOP-T6E7Q6Q\\SQLEXPRESS;Initial Catalog=EmployeeManagment;Integrated Security=True;Encrypt=True;Trust Server Certificate=True;"
}
```

### **Step 3: Run Database Migrations**
Run the following commands in the terminal to apply migrations:
```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

### **Step 4: Run the Application**
```bash
dotnet run
```
---

## Authentication Process
1. **Register an Admin .**
2. **Login to Generate a JWT Token.**
3. Add the JWT token in the **Authorization** header in Swagger or Postman like this:
```
Authorization: Bearer {your_token_here}
```

---

## Best Practices Followed
✅ **SOLID Principles** (Single Responsibility, Open/Closed, etc.)  
✅ **Dependency Injection** for better maintainability  
✅ **Exception Handling** for error management  
✅ **Proper HTTP Verbs** for RESTful practices  
✅ **Clean Code** and consistent naming conventions  

---

## Future Improvements
- Implement pagination for improved performance in large datasets.
- Enhance validation rules for better data integrity.

---









