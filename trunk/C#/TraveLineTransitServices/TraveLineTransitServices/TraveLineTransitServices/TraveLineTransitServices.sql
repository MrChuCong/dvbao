USE master
GO

IF EXISTS (SELECT * FROM sysdatabases WHERE name='TraveLineTransitServices')
BEGIN
	DROP DATABASE TraveLineTransitServices
END
GO

CREATE DATABASE TraveLineTransitServices
GO

USE TraveLineTransitServices
GO

CREATE TABLE Customer
(
	CustomerID char(4) PRIMARY KEY,
	CustomerName varchar(100) NOT NULL,
	Address varchar(100) NOT NULL,
	City varchar(50) NOT NULL,
	State varchar(50) NOT NULL,
	ZipCode varchar(20) NOT NULL,
	Email varchar(50) NOT NULL,
	ContactNumber varchar(20) NOT NULL
)
GO

INSERT INTO Customer VALUES ('C001', 'John Benson', '29 Spadina Avenue',
	'Alachua', 'Florida',
	'094521', 'johnbenson@alrinc.com', '0955323146')
INSERT INTO Customer VALUES ('C002', 'Maryanne Berger', '46 Spadina Avenue',
	'Altamonte', 'Florida',
	'556412', 'maryanneberger@alrinc.com', '9956231485')
INSERT INTO Customer VALUES ('C003', 'Bob Bingham', '67 Spadina Avenue',
	'Apalachicola', 'Florida',
	'112233', 'bobbingham@alrinc.com', '0902356147')
INSERT INTO Customer VALUES ('C004', 'Mike Boltz', '11 Spadina Avenue',
	'Apopka', 'Florida',
	'556134', 'mikeboltz@alrinc.com', '0907456525')
INSERT INTO Customer VALUES ('C005', 'Jonathan Bredenkamp', '7 Spadina Avenue',
	'Auburndale', 'Florida',
	'223495', 'jonathanbredenkamp@alrinc.com', '0945512346')

CREATE TABLE Department
(
	DepartmentID char(3) PRIMARY KEY,
	DepartmentName varchar(100) NOT NULL
)
GO

INSERT INTO Department VALUES ('D01', 'Customer Relations')
INSERT INTO Department VALUES ('D02', 'Human Resources')
INSERT INTO Department VALUES ('D03', 'Logistics')
INSERT INTO Department VALUES ('D04', 'Information Technology')

CREATE TABLE Employee
(
	EmployeeID char(4) PRIMARY KEY,
	EmployeeName varchar(100) NOT NULL,
	Address varchar(100) NOT NULL,
	DateOfBirth datetime NOT NULL,
	DateOfJoininng datetime NOT NULL,
	Designation varchar(50) NOT NULL,
	DepartmentID char(3) NOT NULL REFERENCES Department(DepartmentID),
	Password varchar(50) NOT NULL
)
GO
INSERT INTO Employee VALUES ('E000', '', '',
	'', '', '', 'D01', '');
INSERT INTO Employee VALUES ('E001', 'Darin Buscaglia', '901 12th Avenue',
	'10-10-1980', '01-01-2000', 'KeyPerson', 'D01', '123');
INSERT INTO Employee VALUES ('E002', 'Ryan Culver', '152 12th Avenue',
	'10-10-1980', '01-01-2000', 'KeyPerson', 'D01', '123');
INSERT INTO Employee VALUES ('E003', 'Tyrone Currie', '362 12th Avenue',
	'10-10-1980', '01-01-2000', 'KeyPerson', 'D01', '123');
INSERT INTO Employee VALUES ('E004', 'Debbie Daniel', '451 12th Avenue',
	'10-10-1980', '01-01-2000', 'KeyPerson', 'D02', '123');
INSERT INTO Employee VALUES ('E005', 'Sean Darcy', '56 13th Avenue',
	'10-10-1980', '01-01-2000', 'Assignee', 'D02', '123');
INSERT INTO Employee VALUES ('E006', 'Dennis Davis', '14 15th Avenue',
	'10-10-1980', '01-01-2000', 'Assignee', 'D02', '123');
INSERT INTO Employee VALUES ('E007', 'Bob Foppiano', '111 12th Avenue',
	'10-10-1980', '01-01-2000', 'KeyPerson', 'D03', '123');
INSERT INTO Employee VALUES ('E008', 'Ward Fulcher', '112 14th Avenue',
	'10-10-1980', '01-01-2000', 'Assignee', 'D03', '123');
INSERT INTO Employee VALUES ('E009', 'Brian Gardiner', '67 12th Avenue',
	'10-10-1980', '01-01-2000', 'Assignee', 'D03', '123');
INSERT INTO Employee VALUES ('E010', 'David Garibay', '5 12th Avenue',
	'10-10-1980', '01-01-2000', 'KeyPerson', 'D04', '123');
INSERT INTO Employee VALUES ('E011', 'Bob Gitsham', '41 11th Avenue',
	'10-10-1980', '01-01-2000', 'Assignee', 'D04', '123');
INSERT INTO Employee VALUES ('E012', 'Cathy Gottardi', '90 15th Avenue',
	'10-10-1980', '01-01-2000', 'Assignee', 'D04', '123');

CREATE TABLE Driver
(
	DriverID char(3) PRIMARY KEY,
	DriverName varchar(100) NOT NULL,
	Address varchar(100) NOT NULL,
	Age int NOT NULL,
	LicenseNumber varchar(50) NOT NULL
)
GO

INSERT INTO Driver VALUES ('R01', 'Steve Holdaway',
	'192 Baker Str', 35, '001956742345')
INSERT INTO Driver VALUES ('R02', 'Rich Jackson',
	'14 Baker Str', 29, '015656456131')
INSERT INTO Driver VALUES ('R03', 'Matt Jakeman',
	'196 Baker Str', 31, '897456456456')
INSERT INTO Driver VALUES ('R04', 'Aaron Lane',
	'32 Baker Str', 37, '056486486486')

CREATE TABLE FeedBack
(
	FeedBackID char(5) PRIMARY KEY,
	CustomerID char(4) NOT NULL REFERENCES Customer(CustomerID),
	RepresentativeID char(4) NOT NULL REFERENCES Employee(EmployeeID),
	DateOfFeedBack datetime NOT NULL,
	FeedBackSource varchar(50) NOT NULL,
	FeedBackType varchar(50) NOT NULL,
	FeedBackCategory varchar(50) NOT NULL,
	Description ntext NOT NULL,
	DepartmentID char(3) NOT NULL REFERENCES Department(DepartmentID),
	IncidentDate datetime NOT NULL,
	IncidentPlace varchar(50) NOT NULL,
	BusStop varchar(50) NOT NULL,
	VehicleNumber varchar(50) NOT NULL,
	AssignerID char(4) NOT NULL REFERENCES Employee(EmployeeID),
	AssigneeID char(4) NOT NULL REFERENCES Employee(EmployeeID),
	DateOfAssignment datetime NOT NULL,
	DateOfCompletion datetime NOT NULL,
	DateOfClosure datetime NOT NULL,
	Status varchar(50) NOT NULL
)
GO

CREATE TABLE InvestigationDetails
(
	FeedBackID char(5) NOT NULL REFERENCES FeedBack(FeedBackID),
	Validity varchar(10) NOT NULL,
	Reason ntext NOT NULL,
	DriverID char(3) NOT NULL REFERENCES Driver(DriverID),
	Details ntext NOT NULL,
)
GO

CREATE TABLE CorrectiveActions
(
	FeedBackID char(5) NOT NULL REFERENCES FeedBack(FeedBackID),
	ActionDetails ntext NOT NULL,
	RepresentativeID char(4) NOT NULL REFERENCES Employee(EmployeeID)
)
GO

CREATE TABLE ServicesDetails
(
	StartingPoint varchar(100) NOT NULL,
	Destination  varchar(100) NOT NULL,
	Agency varchar(100) NOT NULL,
	ContactPerson varchar(100) NOT NULL,
	Email varchar(100) NOT NULL,
	PhoneNo varchar(20) NOT NULL,
	Services ntext NOT NULL
)
GO

INSERT INTO ServicesDetails VALUES ('Front Royal Park & Ride',
	'Langley', 'VPSI', 'Daniel Corbin', 'daniel@gmail.com',
	'0956444102', 'Taxi')
INSERT INTO ServicesDetails VALUES ('Winchester',
	'Pentagon City/Arlington', 'VPSI', 'Dale Hurd', 'dale81@gmail.com',
	'0955321422', 'Cab Hire')
INSERT INTO ServicesDetails VALUES ('Shenandoah County',
	'Washington DC', 'CCDP', 'Micki Barbour', 'mike95@gmail.com',
	'0944623127', 'Bus')
INSERT INTO ServicesDetails VALUES ('Linden Park & Ride Lot',
	'Tysons Corner', 'CCDP', 'Joan Wright', 'joanw@yahoo.com',
	'0903262651', 'Train')