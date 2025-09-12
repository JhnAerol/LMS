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
	RoleCodeNumber NVARCHAR(50)
)

CREATE TABLE Roles(
	RoleID INT PRIMARY KEY IDENTITY (1,1),
	RoleCode NVARCHAR(50),
	RoleName NVARCHAR(50)
)

CREATE TABLE Departments(
	DepartmentID INT PRIMARY KEY IDENTITY(1,1),
	DepartmentName NVARCHAR(50)
)

CREATE TABLE Teachers(
	TeaacherID INT PRIMARY KEY IDENTITY(1,1),
	ProfileID INT,
	FOREIGN KEY (ProfileID) REFERENCES Profiles(ProfileID),
	HireDate DATETIME,
	DepartmentID INT
	FOREIGN KEY (DepartmentID) REFERENCES Departments(DepartmentID)
)

CREATE TABLE Students (
	StudentID INT PRIMARY KEY IDENTITY(1,1),
	ProfileID INT,
	FOREIGN KEY (ProfileID) REFERENCES Profiles(ProfileID),
	EnrollmentDate DATETIME
)

CREATE TABLE Semesters (
	SemesterID INT PRIMARY KEY IDENTITY(1,1),
	AcademicYear DATETIME,
	TermName NVARCHAR(50)
)

CREATE TABLE COURSES (
	CourseID INT PRIMARY KEY IDENTITY(1,1),
	CourseName NVARCHAR(50),
    CourseCode NVARCHAR(50),
    Description NVARCHAR(50),
    Credits INT,
	TeacherID INT,
	DepartmentID INT,
	FOREIGN KEY (TeacherID) REFERENCES Teachers(TeacherID),
	FOREIGN KEY (DepartmentID) REFERENCES Departments(DepartmentID)
)

CREATE TABLE Enrollments (
	EnrollmentID INT PRIMARY KEY IDENTITY(1,1),
	StudentID INT,
    CourseID INT,
    SemesterID INT,
	FOREIGN KEY (StudentID) REFERENCES Students(StudentID),
	FOREIGN KEY (CourseID) REFERENCES Courses(CourseID),
	FOREIGN KEY (SemesterID) REFERENCES Semesters(SemesterID)
)

INSERT INTO Roles (RoleCode, RoleName)
VALUES 
('ST', 'Student'),
('AD', 'Admin'),
('TH', 'Teacher')

INSERT INTO Departments(DepartmentID, DepartmentName)
VALUES
(1, 'College Computer Science'),
(2, 'College of Busines and Management'),
(3, 'College of Nursing'),
(4, 'College of Education'),
(5, 'College of Criminal Justice')

EXEC sp_rename 'Teachers.TeaacherID', 'TeacherID', 'COLUMN';
EXEC sp_rename 'COURSES', 'Courses';

SELECT * FROM Roles
SELECT * FROM Users
SELECT * FROM Profiles
SELECT * FROM Teachers
SELECT * FROM Departments
SELECT * FROM Students
SELECT * FROM Semesters
SELECT * FROM Enrollments
SELECT * FROM Courses

DROP TABLE Roles
DROP TABLE Users
DROP TABLE Profiles
DROP TABLE Teachers
DROP TABLE Students
