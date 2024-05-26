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











