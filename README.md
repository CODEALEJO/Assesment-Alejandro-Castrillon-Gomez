# Product and Order Management API
A RESTful API for managing products, categories, and orders in an e-commerce system.
## Table of Contents
- [Features](#features)
- [Technologies Used](#technologies-used)
- [Getting Started](#getting-started)
  - [Prerequisites](#prerequisites)
  - [Installation](#installation)
  - [Configuration](#configuration)
  - [Running the API](#running-the-api)
- [API Endpoints](#api-endpoints)
  - [Products](#products)
  - [Categories](#categories)
  - [Orders](#orders)
  - [Special Endpoints](#special-endpoints)
- [Authentication](#authentication)
- [Additional Considerations](#additional-considerations)
## Features
- CRUD operations for users, patients, History dating, doctor and appointment
- JWT authentication for sensitive endpoints
- Advanced search and filtering capabilities
- Stock management integrated with order creation
## Technologies Used
- ASP.NET Core
- Entity Framework Core
- MySQL
- JWT for authentication
- Swagger for API documentation
## Getting Started
### Prerequisites
- [.NET SDK 8.0]
- [MySQL Server]
- A code editor like [Visual Studio](https://visualstudio.microsoft.com/) or [VS Code](https://code.visualstudio.com/)
### Installation
1. Clone the repository:
   ```bash
   git clone https://github.com/yourusername/product-order-api.git
   cd product-order-api
   ```
2. Restore the NuGet packages:
   ```bash
   dotnet restore
   ```
### Running the API
To start the API, run the following command:
```bash
dotnet run
```
The API will be available at `https://localhost:5054` by default.
## API Endpoints
### User
- `GET /api/v1/user` - Retrieve all users
- `GET /api/v1/user/{id}` - Retrieve a specific user
- `POST /api/v1/user` - Create a new user
- `PUT /api/v1/user/{id}` - Update a user
- `DELETE /api/v1/user/{id}` - Delete a user
### Patient
- `GET /api/v1/Patient` - Retrieve all Patients
- `GET /api/v1/Patient/{id}` - Retrieve a specific Patient
- `POST /api/v1/Patient` - Create a new Patient
- `PUT /api/v1/Patient/{id}` - Update a Patient
- `DELETE /api/v1/Patient/{id}` - Delete a Patient
### Doctor
- `GET /api/v1/Doctor` - Retrieve all Doctors
- `GET /api/v1/Doctor/{id}` - Retrieve a specific Doctor
- `POST /api/v1/Doctor` - Create a new Doctor
- `PUT /api/v1/Doctor/{id}` - Update an Doctor
- `DELETE /api/v1/Doctor/{id}` - Delete an Doctor
### Appointment
- `GET /api/v1/Appointment` - Retrieve all Appointments
- `GET /api/v1/Appointment/{id}` - Retrieve a specific Appointment
- `POST /api/v1/Appointment` - Create a new Appointment
- `PUT /api/v1/Appointment/{id}` - Update a Appointment
- `DELETE /api/v1/Appointment/{id}` - Delete a Appointment
### HistoryDating
- `GET /api/v1/HistoryDating` - Retrieve all History Datings
- `GET /api/v1/HistoryDating/{id}` - Retrieve a specific History Dating
- `POST /api/v1/HistoryDating` - Create a new History Dating
- `PUT /api/v1/HistoryDating/{id}` - Update an History Dating
- `DELETE /api/v1/HistoryDating/{id}` - Delete an History Dating
### Special Endpoints
- `GET /api/v1/appointments/patient/{patientId}` - Get appointments by patient ID
- `GET /api/v1/appointments/doctor/{doctorId}` - Get appointments by doctor ID
- `GET /api/v1/HistoryDatingControllerRead/filter` - Get filtered History datings entries
## Authentication
JWT authentication is implemented to protect sensitive endpoints. Ensure you include the JWT token in the Authorization header for protected requests.
## Additional Considerations
- **Validation**: Input validation is implemented for all endpoints to ensure data integrity.
- **DTOs**: Data Transfer Objects are used to shape API responses and protect domain entities.
- **Swagger**: API documentation is available via Swagger at the `/swagger` endpoint.
- **Repository Pattern**: The project follows the repository pattern for better separation of concerns.
- **SOLID Principles**: The Single Responsibility Principle is applied throughout the project structure.
For more details on the endpoints and their parameters, please refer to the Swagger documentation available at `/swagger` when the API is running
