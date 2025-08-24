CREATE DATABASE Proel2D

USE Proel2D

CREATE TABLE Users(
	UserID INT PRIMARY KEY IDENTITY(1,1),
	Username NVARCHAR(50),
	Password NVARCHAR(50),
	RoleID INT,
	ProfileID INT,
	FOREIGN KEY (RoleID) REFERENCES Roles(RoleID),
	FOREIGN KEY (ProfileID) REFERENCES Profiles(ProfileID)
)

CREATE TABLE Profiles(
	ProfileID INT PRIMARY KEY IDENTITY(1,1),
	FirstName NVARCHAR(50),
	LastName NVARCHAR(50),
	Age INT,
	Gender NVARCHAR(50),
	Phone INT,
	Address NVARCHAR(50),
	Email NVARCHAR(50),
	Status NVARCHAR(50),
)

CREATE TABLE Roles(
	RoleID INT PRIMARY KEY IDENTITY (1,1),
	RoleCode NVARCHAR(50),
	RoleName NVARCHAR(50)
)

ALTER TABLE Users
ADD RoleCodeNumber NVARCHAR(50)

INSERT INTO Roles (RoleCode, RoleName)
VALUES 
('ST', 'Student'),
('AD', 'Admin'),
('TH', 'Teacher')


DROP TABLE Roles
DROP TABLE Users
DROP TABLE Profiles
