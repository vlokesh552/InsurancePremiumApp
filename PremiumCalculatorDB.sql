-- ========================================
-- Database: PremiumCalculatorDB
-- Tables: Ratings, Occupations, UserPremium
-- ========================================
CREATE DATABASE PremiumCalculatorDB;
USE PremiumCalculatorDB;

-- ========================================
-- Create Ratings Table
-- ========================================
CREATE TABLE Ratings (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    RatingName VARCHAR(50) NOT NULL,
    Factor DECIMAL(5,2) NOT NULL
);

-- Insert initial rating data
INSERT INTO Ratings (RatingName, Factor) VALUES
('Professional', 1.0),
('White Collar', 1.25),
('Light Manual', 1.5),
('Heavy Manual', 1.75);

-- ========================================
-- Create Occupations Table
-- ========================================
CREATE TABLE Occupations (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name VARCHAR(50) NOT NULL,
    RatingFactor DECIMAL(5,2) NOT NULL
);

-- Insert sample occupations
INSERT INTO Occupations (Name, RatingFactor) VALUES
('Cleaner', 1.75),
('Doctor', 1.0),
('Author', 1.25),
('Farmer', 1.75),
('Mechanic', 1.75),
('Florist', 1.5);

-- ========================================
-- Create UserPremium Table
-- ========================================
CREATE TABLE UserPremium (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    UserName VARCHAR(100) NOT NULL,
    Age INT NOT NULL,
    DateOfBirth VARCHAR(7) NOT NULL, -- yyyy-MM
    OccupationId INT NOT NULL,
    DeathSumInsured DECIMAL(18,2) NOT NULL,
    MonthlyPremium DECIMAL(18,2) NOT NULL,
    CreatedAt DATETIME DEFAULT GETDATE(),

    CONSTRAINT FK_UserPremium_Occupation FOREIGN KEY (OccupationId)
        REFERENCES Occupations(Id)
);
