CREATE DATABASE OnlineShop;
USE OnlineShop;
/* *****Customer Table***** */
CREATE TABLE Customer
(
	CustomerId UNIQUEIDENTIFIER PRIMARY KEY DEFAULT newsequentialid(),
	Name NVARCHAR(50) NOT NUll,
	Address NVARCHAR(MAX) NUll,
	OrderDate DATETIME NOT NULL
);
/* *****Orders Table***** */
CREATE TABLE Orders
(
	OrderId UNIQUEIDENTIFIER PRIMARY KEY DEFAULT newsequentialid(),
	ProductName NVARCHAR(150) NOT NUll,
	Quantity INT NOT NULL,
	Price DECIMAL NOT NULL,
	Amount DECIMAL NUll,
	CustomerId UNIQUEIDENTIFIER Not Null,
	FOREIGN KEY (CustomerId) REFERENCES Customer(CustomerId)
);