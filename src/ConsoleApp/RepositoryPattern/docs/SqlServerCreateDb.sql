CREATE DATABASE DesignPatternsDb;
GO

USE DesignPatternsDb;

CREATE TABLE Products(
	Id UNIQUEIDENTIFIER NOT NULL,
	[Name] VARCHAR(100) NOT NULL,
	Price DECIMAL(10,2) NOT NULL,
	CONSTRAINT PK_PRODUCTS PRIMARY KEY(Id)
);

CREATE TABLE Customers(
	Id UNIQUEIDENTIFIER NOT NULL,
	[Name] VARCHAR(100) NOT NULL,
	Email VARCHAR(100) NOT NULL,
	CONSTRAINT PK_CUSTOMERS PRIMARY KEY(Id)
);
GO

INSERT INTO Products VALUES
	(NEWID(), 'TestProduct_x', 700.00),
	(NEWID(), 'TestProduct_y', 50.00),
	(NEWID(), 'TestProduct_z', 250.00);

INSERT INTO Customers VALUES
	(NEWID(), 'Customer_x', 'x@test,com'),
	(NEWID(), 'Customer_y', 'y@test,com'),
	(NEWID(), 'Customer_z', 'zy@test,com');
GO

SELECT * FROM Products;

SELECT * FROM Customers;