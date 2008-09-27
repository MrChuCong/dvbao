USE master
GO

IF EXISTS (SELECT * FROM sysdatabases WHERE name='OnlineBankSystem')
BEGIN
	DROP DATABASE OnlineBankSystem
END
GO

CREATE DATABASE OnlineBankSystem
GO

USE OnlineBankSystem
GO

CREATE TABLE AccountType
(
	AccountTypeID varchar(10) PRIMARY KEY,
	AccountTypeName varchar(50) NOT NULL,
	MinAmount int NOT NULL,
	InterestRate float NOT NULL,
	Description text
)
GO

INSERT INTO AccountType VALUES ('AT001', 'Current Account', 300, 2.50,
	'Our standard current account offers a range of services you’d expect from a current account and gives you the flexibility to manage your account online, by phone or in branch.')
INSERT INTO AccountType VALUES ('AT002', 'Active Savings Account', 10, 3.75,
	'This is the ideal account if you need immediate access to your money for unplanned expenses or special treats. You don’t have to be a regular saver and it’s easy to open from just $10. Plus, a cash card is available allowing you to withdraw up to $300 a day from Earnest Bank.')
INSERT INTO AccountType VALUES ('AT003', 'e-Savings Account', 100, 3.98,
	'Getting into the savings habit is as easy as putting the kettle on. And with our e-savings account you can get started in less time than it takes to make a cup of tea.')
INSERT INTO AccountType VALUES ('AT004', 'Savings Bonds Account', 500, 5.12,
	'If you''re happy to keep your money tied up for a while to get a great rate of interest guaranteed, consider the benefits of a savings bond.')
INSERT INTO AccountType VALUES ('AT005', 'Credit Account', 200, 2.08,
	'You will not pay interest on new purchases if you pay your balance in full and on time. Even if you pay the balance in full, the interest charge for the period from the previous statement to the date of full repayment will be debited the following month.')

CREATE TABLE Loan
(
	LoanID varchar(4) PRIMARY KEY,
	LoanType varchar(50) NOT NULL,
	InterestRate float NOT NULL,
	MinDownPayment int NOT NULL,
	Description text
)
GO

INSERT INTO Loan VALUES ('L001', 'Personal Loan', 7.30, 100,
	'Personal loan is our specialty and providing you with fast online personal loan services is what we do. Whether you need a large or small personal loan, we are here to help you with our national service that offers quick online processing for all personal loans.')
INSERT INTO Loan VALUES ('L002', 'Car Loan', 10.25, 150,
	'If you are looking for flexible schemes, quick processing of your loans, attractive interest rates at the click of a mouse, then your search ends here. Our car loan interest charges differ according to the car model, the tenure of the loan, the customer and his location.')
INSERT INTO Loan VALUES ('L003', 'Home Loan', 13.00, 200,
	'A new home brings with it new hopes, joys and emotions. At Earnest Bank, we have shared new hopes, joys and emotions with over 6000 customers. Having earned an experience of 30 years in home loans, our home loan product is customised to provide you solutions for your unique concern.')
INSERT INTO Loan VALUES ('L004', 'Business Loan', 8.94, 150,
	'Business loans are an important part of a company''s survival. Money is essential to making companies grow and in making investments. The challange that companies face is in actually acquiring the money, and paying off the debt that they may owe.')

CREATE TABLE Customer
(
	AccountNumber varchar(10) PRIMARY KEY,
	Username varchar(100) NOT NULL,
	Password varchar(100) NOT NULL,
	CustomerName varchar(100) NOT NULL,
	AccountTypeID varchar(10) NOT NULL REFERENCES AccountType(AccountTypeID),
	LoanID varchar(4),
	LoanStatus varchar(100),
	Address varchar(100) NOT NULL,
	Email varchar(50),
	Phone varchar(20)
)
GO

INSERT INTO Customer VALUES ('1024231312', 'user1', '123',
	'John Benson', 'AT001', '', '',
	'29 Spadina Avenue', 'johnbenson@gmail.com', '0944125763')
INSERT INTO Customer VALUES ('1142579531', 'user2', '123',
	'Maryanne Berger', 'AT003', '', '',
	'12 Spadina Avenue', 'mberger@yahoo.com', '0903124663')
INSERT INTO Customer VALUES ('3325463210', 'user3', '123',
	'Bob Bingham', 'AT002', 'L001', 'Application in Review',
	'16 Spadina Avenue', 'bobbh@gmail.com', '0905552316')
INSERT INTO Customer VALUES ('2255331203', 'user4', '123',
	'Mike Boltz', 'AT005', 'L002', 'Approved for Disbursement',
	'48 Spadina Avenue', 'mikeb@yahoo.com', '0850139027')
INSERT INTO Customer VALUES ('6612354692', 'user5', '123',
	'Jonathan Bredenkamp', 'AT004', 'L004', 'Paid',
	'57 Spadina Avenue', 'jonabre@hotmail.com', '0557893260')

CREATE TABLE TransactionDetails
(
	TransactionID varchar(10) PRIMARY KEY,
	AccountNumber varchar(10) REFERENCES Customer(AccountNumber),
	TransactionDate datetime NOT NULL,
	Type varchar(50) NOT NULL,
	Amount float NOT NULL,
	Balance float NOT NULL
)

INSERT INTO TransactionDetails VALUES('T000001', '1024231312',
	'01-01-2007', 'Bank Payments', 1000, 32000)
INSERT INTO TransactionDetails VALUES('T000002', '1024231312',
	'01-20-2007', 'Bank Deposits', 5000, 37000)
INSERT INTO TransactionDetails VALUES('T000003', '1024231312',
	'01-31-2007', 'Bank Transfers', 10000, 27000)
INSERT INTO TransactionDetails VALUES('T000004', '1024231312',
	'02-10-2007', 'Bank Deposits', 20000, 47000)
INSERT INTO TransactionDetails VALUES('T000005', '1024231312',
	'05-30-2007', 'Bank Withdraws', 7000, 40000)
INSERT INTO TransactionDetails VALUES('T000006', '1142579531',
	'11-21-2007', 'Bank Deposits', 500, 1000)
INSERT INTO TransactionDetails VALUES('T000007', '1142579531',
	'12-23-2007', 'Bank Deposits', 2000, 3000)
INSERT INTO TransactionDetails VALUES('T000008', '1142579531',
	'01-15-2008', 'Bank Deposits', 5000, 8000)
INSERT INTO TransactionDetails VALUES('T000009', '1142579531',
	'02-06-2008', 'Bank Deposits', 2000, 10000)
INSERT INTO TransactionDetails VALUES('T000010', '1142579531',
	'02-28-2008', 'Bank Withdraws', 5000, 5000)
INSERT INTO TransactionDetails VALUES('T000011', '3325463210',
	'10-28-2007', 'Bank Withdraws', 5000, 30000)
INSERT INTO TransactionDetails VALUES('T000012', '3325463210',
	'10-30-2007', 'Bank Withdraws', 5000, 25000)
INSERT INTO TransactionDetails VALUES('T000013', '3325463210',
	'11-02-2007', 'Bank Transfers', 20000, 5000)
INSERT INTO TransactionDetails VALUES('T000014', '3325463210',
	'01-25-2008', 'Bank Deposits', 50000, 55000)
INSERT INTO TransactionDetails VALUES('T000015', '3325463210',
	'02-12-2008', 'Bank Withdraws', 5000, 50000)
INSERT INTO TransactionDetails VALUES('T000016', '2255331203',
	'03-13-2008', 'Bank Deposits', 7000, 20000)
INSERT INTO TransactionDetails VALUES('T000017', '2255331203',
	'03-17-2008', 'Bank Deposits', 10000, 30000)
INSERT INTO TransactionDetails VALUES('T000018', '2255331203',
	'03-29-2008', 'Bank Deposits', 10000, 40000)
INSERT INTO TransactionDetails VALUES('T000019', '2255331203',
	'04-06-2008', 'Bank Deposits', 10000, 50000)
INSERT INTO TransactionDetails VALUES('T000020', '2255331203',
	'04-15-2008', 'Bank Deposits', 10000, 60000)
INSERT INTO TransactionDetails VALUES('T000021', '6612354692',
	'01-08-2008', 'Bank Withdraws', 1000, 3000)
INSERT INTO TransactionDetails VALUES('T000022', '6612354692',
	'01-18-2008', 'Bank Withdraws', 500, 2500)
INSERT INTO TransactionDetails VALUES('T000023', '6612354692',
	'01-28-2008', 'Bank Transfers', 100, 2400)
INSERT INTO TransactionDetails VALUES('T000024', '6612354692',
	'02-07-2008', 'Bank Withdraws', 400, 2000)
INSERT INTO TransactionDetails VALUES('T000025', '6612354692',
	'02-27-2008', 'Bank Transfers', 1000, 1000)

CREATE TABLE Currency
(
	Code varchar(5) PRIMARY KEY,
	ExchangeRate float NOT NULL
)
GO

INSERT INTO Currency VALUES ('AUD', 1.01)
INSERT INTO Currency VALUES ('CAD', 0.95)
INSERT INTO Currency VALUES ('CHF', 0.99)
INSERT INTO Currency VALUES ('EUR', 0.61)
INSERT INTO Currency VALUES ('HKD', 7.47)
INSERT INTO Currency VALUES ('JPY', 101.58)
INSERT INTO Currency VALUES ('SGD', 1.31)
INSERT INTO Currency VALUES ('USD', 1.00)
INSERT INTO Currency VALUES ('VND', 16253.00)