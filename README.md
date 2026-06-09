# Neo4j Clean Architecture API

A sample ASP.NET Core Web API built using Clean Architecture principles and Neo4j Graph Database.

This project demonstrates how to integrate Neo4j with .NET using the official Neo4j.Driver package and implement CRUD operations through a layered architecture.

## Features

- Clean Architecture
- ASP.NET Core Web API
- Neo4j Graph Database
- Repository Pattern
- Service Layer
- Dependency Injection
- Cypher Queries
- Swagger Integration
- CRUD Operations

## Tech Stack

- ASP.NET Core 9
- C#
- Neo4j
- Neo4j.Driver
- Swagger/OpenAPI

## Solution Structure

```text
Neo4jCleanArch
│
├── Neo4jCleanArch.API
├── Neo4jCleanArch.Application
├── Neo4jCleanArch.Domain
└── Neo4jCleanArch.Infrastructure
```

## Architecture

```text
Controller
    ↓
Service
    ↓
Repository
    ↓
Neo4j Driver
    ↓
Neo4j Database
```

## Entity Model

### Person Node

```text
(:Person {
    id,
    name,
    age
})
```

## Neo4j Setup

Install Neo4j Desktop and create a local instance.

Connection configuration:

```json
{
  "Neo4j": {
    "Uri": "neo4j://127.0.0.1:7687",
    "Username": "neo4j",
    "Password": "your-password"
  }
}
```

## API Endpoints

### Create Person

```http
POST /api/person
```

### Get All Persons

```http
GET /api/person
```

### Get Person By Id

```http
GET /api/person/{id}
```

### Update Person

```http
PUT /api/person
```

### Delete Person

```http
DELETE /api/person/{id}
```

## Sample Cypher Queries

### Create Node

```cypher
CREATE (p:Person {
 id:'1',
 name:'Rahul',
 age:28
})
```

### Get All Nodes

```cypher
MATCH (p:Person)
RETURN p
```

### Update Node

```cypher
MATCH (p:Person {id:'1'})
SET p.name='John'
RETURN p
```

### Delete Node

```cypher
MATCH (p:Person {id:'1'})
DELETE p
```

## Learning Goals

- Understand Graph Databases
- Learn Cypher Query Language
- Integrate Neo4j with ASP.NET Core
- Implement Repository Pattern with Neo4j
- Build CRUD APIs using Graph Data

## Future Enhancements

- Organization Nodes
- Person-Organization Relationships
- Relationship Properties (YOE, Role, Start Date)
- Authentication & Authorization
- Docker Support
- Unit Testing
- Graph Traversal Queries

## Getting Started

```bash
git clone <repository-url>
cd neo4j-clean-architecture-api
dotnet restore
dotnet run
```

Open Swagger:

```text
https://localhost:xxxx/swagger
```

## License

This project is intended for learning and demonstration purposes.
