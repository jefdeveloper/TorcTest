# Book Library Search System – Torc Test

This project is a technical test for the company Torc. It consists of a Book Library Search System, allowing users to search for books in a library database.

## Technologies Used

- **Backend:** .NET 9 (ASP.NET Core)
- **Frontend:** React (Create React App, Material UI)
- **Containerization:** Docker & Docker Compose

## How to Run

1. **Clone the repository** and navigate to the project root.
2. **Start the services** using Docker Compose:
   ```sh
   docker-compose up --build
   ```
3. **Access the application:**
   - **Backend API:** [http://localhost:5000/swagger](http://localhost:5000/swagger)
   - **Frontend:** [http://localhost:3000](http://localhost:3000)

## Project Structure

- `api`: .Net Core Web API
- `front`: React frontend
- `docker-compose.yml`: Orchestrates backend, frontend, and database containers

## Description

The system allows users to search for books. The backend is built with .Net Core and exposes endpoints for book queries. The frontend, built with React, provides an interface for searching and viewing results. All components run in containers for easy setup and deployment.

## Points for Improvement

While the current implementation fulfills the requirements for the technical test, there are several areas for improvement, for the backend:

- **Authentication/Authorization:** Implement user authentication and authorization to protect endpoints and data.
- **API Versioning:** Add versioning to the API to support future changes without breaking existing clients.
- **Rate Limiting:** Add rate limiting to prevent abuse and ensure fair usage of the API.
- **HTTPS Communication:** Enforce HTTPS to secure data between client and the backend.
- **Input Validation:** Strengthen input validation to protect against common vulnerabilities.
- **Sensitive Data Exposure:** Avoid exposing sensitive information in configuration files like `appsettings.json`.
- **Minimal API Usage:**  
  > **Attention:** Minimal APIs were used in this project due to the small scope and simplicity of the requirements. While they are suitable for lightweight scenarios, they may not be ideal for applications with complex business rules or larger architectures.

For the frontend:

- **Layout Improvements:** Enhance the visual layout for better usability.
- **Code Organization:** Refactor and modularize components to improve maintainability and readability.
- **Selectable Items Per Page:** Allow users to select the number of items displayed per page in the results grid.
- **Better Error Handling:** Implement more robust error management and user feedback for API and UI errors.
- **Performance:** Use virtualization, lazy loading and `React.memo` in the results list to improve performance and prevent page re-rendering.

---

This project is intended for evaluation purposes as part of the Torc hiring process.