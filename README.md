# Vigilant Umbrella

Vigilant Umbrella is a .NET 9.0 based application designed to manage countries and cities. This project includes multiple layers such as API, Application, Domain, Infrastructure, and Test projects.

## Project Structure

```
vigilant-umbrella-api
vigilant-umbrella-application
vigilant-umbrella-domain
vigilant-umbrella-infrastructure
vigilant-umbrella-test
```

## Getting Started

### Prerequisites

- .NET 9.0 SDK
- Docker (optional, for containerization)
- SQL Server (or use the in-memory database for development)

### Setup

1. Clone the repository:
    ```sh
    git clone https://github.com/ffcoders/vigilant-umbrella.git
    cd vigilant-umbrella
    ```

2. Restore the dependencies:
    ```sh
    dotnet restore
    ```

3. Build the solution:
    ```sh
    dotnet build
    ```

4. Configure the database in the `Properties/launchSettings.json` file of the `vigilant-umbrella-api` project.

## Running the Application

To run the application locally, use the following command:

```sh
dotnet run --project src/vigilant-umbrella-api
```

## Running Tests

To run the tests, use the following command:
```sh
dotnet test
```

## Project Details

### API

The API layer contains controllers for managing countries and cities.

### Application

The application layer contains services for business logic.

### Domain

The domain layer contains the core entities and business rules.

### Infrastructure

The infrastructure layer handles data access and migrations.

### Tests
The test layer contains unit tests for the application and API layers.

## CI/CD

The project uses GitHub Actions for CI/CD.

## License

This project is licensed under the MIT License.
