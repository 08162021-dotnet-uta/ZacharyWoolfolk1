--Project 1 DDL
USE MASTER
GO

USE StoreApplicationDB;
GO

CREATE TABLE Customers(
CustomerId INT PRIMARY KEY IDENTITY,
FirstName varchar(50) NOT NULL,
LastName varchar(50) NOT NULL);

CREATE TABLE Products(
ProductId INT PRIMARY KEY IDENTITY,
ProductName varchar(50) NOT NULL,
ProductDescription varchar(100) NOT NULL,
ProductPrice decimal(19,4) NOT NULL,
QuantityAvailable INT NOT NULL);

CREATE TABLE Locations(
StoreId INT PRIMARY KEY IDENTITY,
[Location] varchar(50) NOT NULL,);

CREATE TABLE StoreInventory(
ItemizedId uniqueidentifier NOT NULL DEFAULT newid() PRIMARY KEY,
StoreId INT NOT NULL FOREIGN KEY REFERENCES Locations(StoreId) ON DELETE CASCADE,
ProductId INT NOT NULL FOREIGN KEY REFERENCES Products(ProductId) ON DELETE CASCADE,
Inventory INT NOT NULL);

CREATE TABLE Orders(
ItemizedId uniqueidentifier NOT NULL DEFAULT newid() PRIMARY KEY,
OrderId uniqueidentifier NOT NULL DEFAULT newid(),
CustomerId INT NOT NULL FOREIGN KEY REFERENCES Customers(CustomerId) ON DELETE CASCADE,
ProductId INT NOT NULL FOREIGN KEY REFERENCES Products(ProductId) ON DELETE CASCADE,
StoreId INT NOT NULL FOREIGN KEY REFERENCES Locations(StoreId) ON DELETE CASCADE,
OrderDate date NOT NULL,
ProductQuantity INT NOT NULL,
CompletionTime INT NOT NULL,
totalAmount decimal(19,4) NOT NULL);
