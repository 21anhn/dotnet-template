# .NET Clean Architecture Template

## Overview
A ASP.NET Core template implementing Clean Architecture with essential modern development patterns and technologies.

## Tech Stack
- **.NET 8**
- **PostgreSQL** - Database
- **Docker** - Containerization
- **Jenkins** - CI/CD automation
- **ELK Stack** - Centralized logging
- **Prometheus & Grafana** - Monitoring and visualization
  
## Architecture & Patterns
- **Clean Architecture** - Core, Application, Infrastructure, Web layers
- **Repository Pattern & Unit of Work** - Data access abstraction
- **SOLID Principles** - Maintainable and testable design

## Key Features
-  **Generic Repository & UoW Pattern**
-  **Request Validation** with FluentValidation
-  **Standardized API Responses** (message, success, error, data)
-  **Modular DI Registration**
-  **Structured Logging** (file-based, extensible to ELK)
-  **JWT Authentication**
-  **Object Mapping** with AutoMapper

## Project Structure
```
|- src
   |- MyProject.Core                 # Domain entities, interfaces
   |- MyProject.Application          # Use cases, DTOs, validation
   |- MyProject.Infrastructure       # Data access, external services
   |- MyProject.Web                  # API endpoints, configuration
|- tests
|- docker
|- jenkins
```

## Quick Start
```bash
# Clone repository
git clone https://github.com/21anhn/dotnet-template.git

# With Docker
docker-compose up -d

# Without Docker
cd src/MyProject.Web
dotnet run
```

## Docker Support
Includes Dockerfile and docker-compose.yml for development and production environments.

## CI/CD
Jenkins pipeline for automated build, test and deployment.

## Extensions
Easily extensible with:
- ELK Stack integration
- Prometheus & Grafana monitoring
- Message queues (RabbitMQ/Kafka)
- Redis caching
- Kubernetes orchestration

## License
MIT
