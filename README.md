# SigmaCandidate

SigmaCandidate is a web developed using .NET Core that provides a REST API for storing and updating information about job candidates. The API allows creating and updating candidate profiles with essential contact details.

## Table of Contents

- [Features](#features)
- [Getting Started](#getting-started)
  - [Prerequisites](#prerequisites)
  - [Installation](#installation)
  - [Running the Application](#running-the-application)
- [API Endpoints](#api-endpoints)
- [Project Structure](#project-structure)
- [Testing](#testing)
- [Contributing](#contributing)
- [License](#license)

## Features

- Create and update candidate profiles
- Use email as a unique identifier for candidates
- Store essential contact information including phone number, preferred call time, LinkedIn profile URL, GitHub profile URL, and free text comments

## Getting Started

### Prerequisites

- [.NET 5 SDK](https://dotnet.microsoft.com/download/dotnet/5.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)

### Installation

1. Clone the repository:

```bash
git clone https://github.com/AyoubBouizou/SigmaProject.git
cd SigmaProject

Project Structure

├── Controllers
│   └── CandidatesController.cs
├── Data
│   ├── CandidateContext.cs
│   └── Candidate.cs
├── DTOs
│   └── CandidateDto.cs
├── Mappings
│   └── MappingProfile.cs
├── Services
│   └── CandidateService.cs
├── Tests
│   └── CandidateServiceTests.cs
├── Program.cs
├── Startup.cs
└── appsettings.json

### Change Connexion

Create database and table Named 'Candidates' :
CREATE TABLE Candidates (
    Id INT PRIMARY KEY IDENTITY(1,1),
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
    Phone NVARCHAR(20),
    Email NVARCHAR(100) NOT NULL,
    BestCallTime NVARCHAR(50),
    LinkedIn NVARCHAR(200),
    GitHub NVARCHAR(200),
    Comment NVARCHAR(MAX) NOT NULL,
    CreatedAt DATETIME NOT NULL DEFAULT GETUTCDATE(),
    UpdatedAt DATETIME NOT NULL DEFAULT GETUTCDATE()
);


Update the database connection string in appsettings.json:

### SetupProject

Build the project:

dotnet build

Apply migrations and update the database:

dotnet ef database update


### Running the Application

To run the application, use the following command:

dotnet run

API Endpoints

POST /api/candidates: Create or update a candidate
Request body:
json
Copier le code
{
  "firstName": "name1",
  "lastName": "name1",
  "phoneNumber": "123-456-7890",
  "email": "names@example.com",
  "preferredCallTime": "9 AM - 5 PM",
  "linkedInUrl": "https://linkedin.com/in/name",
  "gitHubUrl": "https://github.com/name",
  "comments": "Candidate is highly skilled in C# and .NET."
}


### Testing

This project uses NUnit for unit testing. The test classes are located in the TestCandidates project. To run the tests, use the following command :

dotnet test









