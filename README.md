# Premium Calculator Solution

## Overview

This solution is a .NET-based Insurance Premium Calculator developed as part of a coding assessment.

The application enables users to:

- Enter member details
- Select an occupation
- Calculate monthly premium based on occupation rating factors
- Display premium dynamically on the UI
- Expose calculation functionality through REST APIs
- Demonstrate enterprise-level architecture patterns and coding standards

---

## Business Requirement

Calculate Monthly Premium using the following formula:

Monthly Premium =
(Death Sum Insured × Occupation Factor × Age Next Birthday)
/ 1000 × 12

### Occupation Ratings

| Occupation | Rating |
|------------|---------|
| Cleaner | Light Manual |
| Doctor | Professional |
| Author | White Collar |
| Farmer | Heavy Manual |
| Mechanic | Heavy Manual |
| Florist | Light Manual |
| Other | Heavy Manual |

### Rating Factors

| Rating | Factor |
|----------|----------|
| Professional | 1.5 |
| White Collar | 2.25 |
| Light Manual | 11.50 |
| Heavy Manual | 31.75 |

---

## Solution Architecture

┌─────────────────────────────┐
│       MVC Frontend          │
│ (HTML/CSS/JavaScript)       │
└─────────────┬───────────────┘
              │
              │ REST API Calls
              ▼
┌─────────────────────────────┐
│      ASP.NET Core API       │
├─────────────────────────────┤
│ Controllers                 │
│ Services                    │
│ DTOs                        │
│ Middleware                  │
└─────────────┬───────────────┘
              │
              ▼
┌─────────────────────────────┐
│ Repository Layer            │
│ (Mock/In-Memory Data)       │
└─────────────┬───────────────┘
              │
              ▼
┌─────────────────────────────┐
│ Future SQL Server Database  │
└─────────────────────────────┘


## Project Structure


MonthlyPremiumCalculator.sln

├── MonthlyPremiumCalculator.API
│
├── MonthlyPremiumCalculator.MVC
│
├── MonthlyPremiumCalculator.Core
│
├── MonthlyPremiumCalculator.Infrastructure
│
└── MonthlyPremiumCalculator.Tests


## Project Responsibilities

### MonthlyPremiumCalculator.API

Contains:

- REST APIs
- Controllers
- Logging
- Exception Handling Middleware
- Dependency Injection

#### Controllers

OccupationController
PremiumController


### MonthlyPremiumCalculator.MVC

Contains:

- HTML UI
- Bootstrap Styling
- JavaScript API Calls
- Client-side Validations


### MonthlyPremiumCalculator.Core

Contains:

- Domain Models
- DTOs
- Interfaces
- Business Services


### MonthlyPremiumCalculator.Infrastructure

Contains:

- Repository Implementations
- Mock Data Store


### MonthlyPremiumCalculator.Tests

Contains:

- Unit Tests
- Mocking using Moq
- Assertions using FluentAssertions


## Design Patterns Implemented

### Repository Pattern

Purpose:

- Decouples business logic from data source
- Allows future database implementation

Example:

IOccupationRepository
OccupationRepository


### Service Layer Pattern

Purpose:

- Encapsulates business logic
- Keeps controllers lightweight

Example:

IPremiumService
PremiumService


### Dependency Injection

Purpose:

- Loose coupling
- Better testability

Example:

builder.Services.AddScoped<
    IOccupationRepository,
    OccupationRepository>();

builder.Services.AddScoped<
    IPremiumService,
    PremiumService>();


### DTO Pattern

Purpose:

- Separate API contracts from domain models
- Improve maintainability

Example:

PremiumRequestDto
PremiumResponseDto
OccupationDto

## APIs

### Get Occupations

GET /api/occupation


Response (json)

[
  {
    "name": "Doctor",
    "rating": "Professional"
  }
]


### Calculate Premium


POST /api/premium/calculate

Request (json)

{
  "name": "Vivek",
  "age": 35,
  "dateOfBirth": "01/1990",
  "occupation": "Doctor",
  "deathSumInsured": 500000
}


Response (json)

{
  "monthlyPremium": 315000
}



## Error Handling

Global Exception Handling has been implemented using middleware.

### Middleware

GlobalExceptionMiddleware

Responsibilities:

- Catch unhandled exceptions
- Log errors
- Return standard error response


## Logging

Logging implemented using:

ILogger
Serilog


### Sample Log Events

Premium calculation request received

Premium calculated successfully

Unhandled Exception


### Log File Location

Logs/log-yyyyMMdd.txt


## Validation Rules

### Mandatory Fields

- Name
- Age Next Birthday
- Date of Birth
- Occupation
- Death Sum Insured

### Date Format

MM/YYYY

Example:


01/1990
12/1985


### Numeric Rules

Age > 0
Death Sum Insured > 0



## Unit Testing

### Frameworks Used

xUnit
Moq
FluentAssertions


### Test Coverage

#### Premium Service

- Doctor Premium Calculation
- Author Premium Calculation
- Cleaner Premium Calculation
- Farmer Premium Calculation
- Invalid Occupation Handling
- Zero Age Scenario
- Negative Age Scenario


#### Repository

- Occupation Retrieval Tests


## Mocking

Implemented using:

Moq

Example:

var _repoMock =
    new Mock<IOccupationRepository>();


Allows testing without actual database dependency.

---

## Database Design

### OccupationMaster

OccupationId (PK)
OccupationName
OccupationRating
Factor


### MemberQuote

QuoteId (PK)
Name
AgeNextBirthday
DateOfBirth
OccupationId (FK)
DeathSumInsured
MonthlyPremium
CreatedDate


## Entity Relationship Diagram


+----------------------+
| OccupationMaster     |
+----------------------+
| OccupationId (PK)    |
| OccupationName       |
| Rating               |
| Factor               |
+----------------------+

           │
           │
           ▼

+----------------------+
| MemberQuote          |
+----------------------+
| QuoteId (PK)         |
| Name                 |
| AgeNextBirthday      |
| DateOfBirth          |
| OccupationId (FK)    |
| DeathSumInsured      |
| MonthlyPremium       |
| CreatedDate          |
+----------------------+


## Running the Solution

### Restore Packages

dotnet restore


### Build Solution

dotnet build


### Run API

cd MonthlyPremiumCalculator.API

dotnet run


Swagger URL:

https://localhost:<port>/swagger


### Run MVC Application

cd MonthlyPremiumCalculator.MVC

dotnet run


Application URL:

https://localhost:<port>


### Run Unit Tests

dotnet test

## Future Enhancements

- SQL Server Integration
- Entity Framework Core
- Authentication & Authorization
- API Versioning
- Dashboard & Reporting


## Technology Stack

| Component | Technology |
|------------|------------|
| Backend API | ASP.NET Core 10 |
| Frontend | ASP.NET MVC |
| Language | C# |
| UI | HTML, CSS, JavaScript, Bootstrap |
| Testing | xUnit |
| Mocking | Moq |
| Assertions | FluentAssertions |
| Logging | ILogger, Serilog |
| Database (Future) | SQL Server |
| Source Control | Git |
