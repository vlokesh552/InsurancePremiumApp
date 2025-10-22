# InsurancePremiumApp
This project is a .NET Core Web API that calculates the monthly insurance premium for a member based on their age, occupation, and death cover amount. It provides endpoints to fetch occupation data and to calculate premiums dynamically.


Monthly Premium Calculator Application
====================================================================
A full-stack insurance premium calculator built with Angular 15 (frontend) and ASP.NET Core Web API (backend) using SQL Server for data storage.


Features:
---------
Calculate monthly premiums based on user input.

Reactive form validations:
-- Name is required
-- Age next birthday: 1–99 years
-- Date of birth: YYYY-MM format, cannot be a future month
-- Occupation selection is required
-- Death sum insured: 1,000–100,000,000 (numeric value)

Premium auto-calculation when occupation changes.
Error handling for API failures with user-friendly messages.
Optional logging of user calculations in the database.
CORS enabled for frontend-backend communication.


Tech Stack:
------------
Frontend: Angular 15, Reactive Forms, Bootstrap
Backend: ASP.NET Core Web API, Entity Framework Core
Database: SQL Server


Setup Instructions:
-------------------
Backend:
Update the connection string in appsettings.json.

Apply EF Core migrations:
dotnet ef database update

Run the API:
dotnet run

Frontend:
Navigate to client folder
cd PremiumCalculator.Client

Install dependencies:
npm install

Start Angular dev server:
ng serve

Open browser at https://localhost:52789/


Database Tables:
----------------------
Refer to the PremiumCalculatorDB.sql file


Usage:
---------
Fill in all fields in the form
Premium is calculated automatically or by clicking Calculate Premium
Reset form using Reset button
Refer to the screenshots in the screenshots/ folder for more visual guidance on form inputs and premium calculation results.


Assumptions:
----------------
Occupation Factors: Predefined in the database and used in premium calculation.
Age Validation: Must be between 1 and 99 years.
Sum Insured: Input is a numeric value between 1,000 and 100,000,000.
Date of Birth: Must be in YYYY-MM format and cannot be a future month.

***********************************************************************************************
Monthly Premium Formula:
Monthly Premium = (DeathSumInsured * OccupationFactor * AgeNextBirthday) / 1000 * 12
***********************************************************************************************

CORS: Enabled for local development; in production, restrict to allowed origins.
API Failure Handling: If API fails, frontend defaults premium to 0.
Data Persistence: Optional logging of user calculations in UserPremium table.
Authentication: No user authentication implemented; public access assumed for testing/demo.
Frontend-Backend Sync: Occupation dropdown triggers recalculation automatically; other fields require form submission or change handling.


Clarifications
-------------------
Ratings and occupation factors are simplified for demonstration.
Backend and database are designed for extensibility for more occupations or premium rules.
Error handling covers invalid user inputs but extreme edge cases are not fully validated.
Frontend communicates with API directly; no server-side rendering.
Refer to screenshots in screenshots/ folder for UI, validation messages, and premium calculation examples.


****************************************
Refer to program.cs file
Database Connection: The SQL Server connection string and configuration have been temporarily commented out.
For development and testing, the application is using an InMemoryDatabase. Switch back to SQL Server in production by uncommenting and updating the connection settings.
