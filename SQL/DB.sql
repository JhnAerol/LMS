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

ALTER TABLE Users
ADD CONSTRAINT ProfileID
FOREIGN KEY (ProfileID) REFERENCES Profiles(ProfileID)
ON DELETE CASCADE

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

EXEC sp_fkeys 'Teachers';

CREATE TABLE Students (
	StudentID INT PRIMARY KEY IDENTITY(1,1),
	ProfileID INT,
	FOREIGN KEY (ProfileID) REFERENCES Profiles(ProfileID),
	EnrollmentDate DATETIME
)

ALTER TABLE Students
ADD CONSTRAINT ProfileID
FOREIGN KEY (ProfileID) REFERENCES Profiles(ProfileID)
ON DELETE CASCADE


CREATE TABLE Semesters (
	SemesterID INT PRIMARY KEY,
	AcademicYear NVARCHAR(50),
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

INSERT INTO Semesters(SemesterID, AcademicYear, TermName)
VALUES
(1, '2025-2026', 'First Semester'),
(2, '2025-2026', 'Second Semester')

ALTER TABLE Courses
ALTER COLUMN Credits DECIMAL(5,2)

INSERT INTO Courses( CourseName, CourseCode, Description, Credits, TeacherID, DepartmentID)
VALUES
( 'Web', 'WEB101', 'Introduction to Website Development', 3.0, NULL, 1),
('Data Structures', 'CS201', 'Study of Data Structures', 3.0, NULL, 1),
('Database Systems', 'CS202', 'Introduction to Databases', 3.0, NULL, 1),
('Marketing Principles', 'BM201', 'Basics of Marketing', 3.0, NULL, 2),
('Business Law', 'BM202', 'Introduction to Business Law', 3.0, NULL, 2),
('Anatomy', 'NU201', 'Human Anatomy Basics', 3.0, NULL, 3),
('Pharmacology', 'NU202', 'Introduction to Drugs and Medicine', 3.0, NULL, 3),
('Educational Psychology', 'ED201', 'Psychology Applied to Teaching', 3.0, NULL, 4),
('Curriculum Development', 'ED202', 'Principles of Curriculum Design', 3.0, NULL, 4),
('Forensic Science', 'CJ201', 'Introduction to Forensic Science', 3.0, NULL, 5),
('Criminal Law', 'CJ202', 'Principles of Criminal Law', 3.0, NULL, 5),
( 'Programming', 'PROG1', 'Computer Programming 1', 3.0, 3, 1),
( 'Biology', 'BIO1', 'Biology 1', 3.0, 6, 3),
( 'Finance', 'FNCE', 'Finance Fundamentals', 3.0, 4, 2),
( 'Math', 'MATH1', 'Basic Math', 3.0, 5, 4),
( 'Criminology', 'CRIM101', 'Introduction to Criminology', 3.0, 3, 5),
( 'Artificial Intelligence', 'AI101', 'Introduction to AI', 3.0, NULL, 1)

INSERT INTO Enrollments (StudentID, CourseID, SemesterID)
VALUES
(2, 15, 1),
(2, 16, 1)


EXEC sp_rename 'Teachers.TeaacherID', 'TeacherID', 'COLUMN';
EXEC sp_rename 'COURSES', 'Courses';

UPDATE Courses
SET TeacherID = 5
WHERE CourseID = 4

UPDATE Enrollments
SET CourseID = 4
WHERE EnrollmentID = 1004

SELECT * FROM Departments
SELECT * FROM Semesters
SELECT * FROM Courses
SELECT * FROM Teachers
SELECT * FROM Profiles
SELECT * FROM Users
SELECT * FROM Enrollments
SELECT * FROM Students
SELECT * FROM Roles

DROP TABLE Roles
DROP TABLE Users
DROP TABLE Profiles
DROP TABLE Teachers
DROP TABLE Students
DROP TABLE Semesters
DROP TABLE Enrollments
DROP TABLE Courses

SELECT Teachers.TeacherID,
		CONCAT(Profiles.FirstName, ' ', Profiles.LastName) AS FullName,
		Courses.CourseName
FROM Teachers
LEFT JOIN Courses
ON Teachers.TeacherID = Courses.TeacherID
LEFT JOIN Profiles
ON Teachers.ProfileID = Profiles.ProfileID
WHERE Courses.CourseName IS NULL


CREATE PROC SP_GetAvTeacher

AS 
BEGIN
SELECT CONCAT(Profiles.FirstName, ' ', Profiles.LastName) AS FullName
		FROM Teachers
		 LEFT JOIN Courses
			ON Teachers.TeacherID = Courses.TeacherID
		 LEFT JOIN Profiles
			ON Teachers.ProfileID = Profiles.ProfileID
		WHERE Courses.CourseName IS NULL

END

CREATE PROC SP_TeacherInCourse
AS
BEGIN
SELECT Courses.CourseID,
		CONCAT(Profiles.FirstName, ' ', Profiles.LastName) AS FullName,
		Courses.CourseName
FROM Courses
INNER JOIN Teachers
ON Courses.TeacherID = Teachers.TeacherID
INNER JOIN Profiles
ON Teachers.ProfileID = Profiles.ProfileID
END

ALTER PROC SP_DeleteStudent
    @StudentID INT
AS
BEGIN
    SET NOCOUNT ON

    DECLARE @ProfileID INT

    SELECT @ProfileID = ProfileID 
    FROM Students
    WHERE StudentID = @StudentID

    DELETE FROM Enrollments
    WHERE StudentID = @StudentID

    DELETE FROM Users
    WHERE ProfileID = @ProfileID

    DELETE FROM Students
    WHERE StudentID = @StudentID

    DELETE FROM Profiles
    WHERE ProfileID = @ProfileID
END


ALTER PROC SP_DeleteTeacher
    @TeacherID INT
AS
BEGIN
    SET NOCOUNT ON

    DECLARE @ProfileID INT

    SELECT @ProfileID = ProfileID 
    FROM Teachers
    WHERE TeacherID = @TeacherID

    UPDATE Courses
    SET TeacherID = NULL   
    WHERE TeacherID = @TeacherID

    DELETE FROM Users
    WHERE ProfileID = @ProfileID

    DELETE FROM Teachers
    WHERE TeacherID = @TeacherID

    DELETE FROM Profiles
    WHERE ProfileID = @ProfileID
END
	
CREATE PROC SP_DeleteSubject
	@CourseID INT
AS
BEGIN
	DELETE Enrollments
	WHERE CourseID = @CourseID

	DELETE FROM Courses
	WHERE CourseID = @CourseID
END

ALTER PROC SP_UpdateStudent
    @StudentID INT,
    @FirstName NVARCHAR(50),
    @LastName NVARCHAR(50),
    @Age INT,
    @Gender NVARCHAR(10),
    @Phone INT,
    @Address NVARCHAR(100),
    @Email NVARCHAR(100),
    @Status NVARCHAR(20),
    @RoleCodeNumber NVARCHAR(20),
    @EnrollmentDate DATETIME
AS
BEGIN
    SET NOCOUNT ON

    DECLARE @ProfileID INT

    SELECT @ProfileID = ProfileID FROM Students WHERE StudentID = @StudentID

    IF @ProfileID IS NULL
    BEGIN
        PRINT 'Student not found.'
        RETURN
    END

    UPDATE Profiles
    SET FirstName = @FirstName,
        LastName = @LastName,
        Age = @Age,
        Gender = @Gender,
        Phone = @Phone,
        Address = @Address,
        Email = @Email,
        Status = @Status,
        RoleCodeNumber = @RoleCodeNumber
    WHERE ProfileID = @ProfileID;

    UPDATE Students
    SET EnrollmentDate = @EnrollmentDate
    WHERE StudentID = @StudentID;

END

CREATE PROC SP_UpdateTeacher
    @TeacherID INT,
    @HireDate DATE,
    @DepartmentID INT,
    @FirstName NVARCHAR(50),
    @LastName NVARCHAR(50),
    @Age INT,
    @Gender NVARCHAR(10),
    @Phone NVARCHAR(20),
    @Address NVARCHAR(255),
    @Email NVARCHAR(100),
    @Status NVARCHAR(20),
    @RoleCodeNumber NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON

    UPDATE Teachers
    SET HireDate = @HireDate,
        DepartmentID = @DepartmentID
    WHERE TeacherID = @TeacherID

    UPDATE Profiles
    SET FirstName = @FirstName,
        LastName = @LastName,
        Age = @Age,
        Gender = @Gender,
        Phone = @Phone,
        Address = @Address,
        Email = @Email,
        Status = @Status,
        RoleCodeNumber = @RoleCodeNumber
    WHERE ProfileID = (
        SELECT ProfileID
        FROM Teachers
        WHERE TeacherID = @TeacherID
    )
END

CREATE PROC SP_UpdateCourse
    @CourseID INT,
    @CourseName NVARCHAR(100),
    @CourseCode NVARCHAR(50),
    @Description NVARCHAR(255),
    @Credits INT
AS
BEGIN
    SET NOCOUNT ON

    IF NOT EXISTS (SELECT 1 FROM Courses WHERE CourseID = @CourseID)
    BEGIN
        PRINT 'Course not found.'
        RETURN;
    END

    UPDATE Courses
    SET CourseName = @CourseName,
        CourseCode = @CourseCode,
        Description = @Description,
        Credits = @Credits
    WHERE CourseID = @CourseID

END

CREATE PROC SP_GetActiveTeacher
AS
BEGIN
    SELECT Teachers.TeacherID,
			Teachers.HireDate,
			Teachers.DepartmentID,
			Profiles.FirstName,
			Profiles.LastName, 
			Profiles.Age, 
			Profiles.Gender,
			Profiles.Phone,
			Profiles.Address,
			Profiles.Email,
			Profiles.Status,
			Profiles.RoleCodeNumber FROM Teachers 
	LEFT JOIN Profiles
	ON Teachers.ProfileID = Profiles.ProfileID
    WHERE Profiles.Status = 'Active'
	ORDER BY Teachers.TeacherID DESC
END

CREATE PROC SP_GetActiveStudent
AS
BEGIN
    SELECT Students.StudentID,
			Students.EnrollmentDate,
			Profiles.FirstName,
			Profiles.LastName, 
			Profiles.Age, 
			Profiles.Gender,
			Profiles.Phone,
			Profiles.Address,
			Profiles.Email,
			Profiles.Status,
			Profiles.RoleCodeNumber
			 FROM Students 
	LEFT JOIN Profiles
	ON Students.ProfileID = Profiles.ProfileID
    WHERE Profiles.Status = 'Active'
	ORDER BY Students.StudentID DESC
END


ALTER PROC SP_GetStudentsFromTeacher
    @TeacherID INT
AS
BEGIN
    SELECT 
        e.StudentID,
        c.CourseName,
        CONCAT(p.FirstName, ' ', p.LastName) AS StudentName,
        p.Status,
        p.RoleCodeNumber
    FROM Teachers t
    INNER JOIN Courses c ON t.TeacherID = c.TeacherID
    INNER JOIN Enrollments e ON c.CourseID = e.CourseID
    INNER JOIN Students s ON e.StudentID = s.StudentID
    INNER JOIN Profiles p ON s.ProfileID = p.ProfileID
    WHERE t.TeacherID = @TeacherID
    ORDER BY c.CourseName, StudentName
END


ALTER PROC SP_GetStudentFromCourse
    @CourseID INT
AS
BEGIN
    SELECT 
        e.StudentID,
        c.CourseName,
        CONCAT(p.FirstName, ' ', p.LastName) AS StudentName,
        p.Status,
        p.RoleCodeNumber,
        CONCAT(tp.FirstName, ' ', tp.LastName) AS TeacherName
    FROM Courses c
    INNER JOIN Teachers t ON c.TeacherID = t.TeacherID
    INNER JOIN Profiles tp ON t.ProfileID = tp.ProfileID
    INNER JOIN Enrollments e ON c.CourseID = e.CourseID
    INNER JOIN Students s ON e.StudentID = s.StudentID
    INNER JOIN Profiles p ON s.ProfileID = p.ProfileID
    WHERE c.CourseID = @CourseID
    ORDER BY c.CourseName, StudentName
END

ALTER PROC SP_GetStudentCoursesAndTeacher
    @StudentID INT
AS
BEGIN
    SELECT 
        c.CourseName,
        c.CourseCode,
        CONCAT(tp.FirstName, ' ', tp.LastName) AS TeacherName
    FROM Enrollments e
    INNER JOIN Students s ON e.StudentID = s.StudentID
    INNER JOIN Profiles sp ON s.ProfileID = sp.ProfileID
    INNER JOIN Courses c ON e.CourseID = c.CourseID
    INNER JOIN Teachers t ON c.TeacherID = t.TeacherID
    INNER JOIN Profiles tp ON t.ProfileID = tp.ProfileID
    WHERE s.StudentID = @StudentID
END