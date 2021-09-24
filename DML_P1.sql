--Project 1 DML
USE StoreApplicationDB;
GO

SELECT * FROM Customers;
SELECT * FROM Locations;
SELECT * FROM Products;
SELECT * FROM StoreInventory;
SELECT * FROM Orders;

SELECT Products.ProductName, Locations.[Location], StoreInventory.Inventory 
FROM Products 
INNER JOIN StoreInventory
ON Products.ProductId=StoreInventory.ProductId
INNER JOIN Locations
ON StoreInventory.StoreId = Locations.StoreId;

SELECT Products.*, StoreInventory.Inventory 
FROM Products 
INNER JOIN StoreInventory
ON Products.ProductId=StoreInventory.ProductId
INNER JOIN Locations
ON StoreInventory.StoreId = Locations.StoreId
WHERE Locations.StoreId = 3;

SELECT DISTINCT Products.*
FROM Products 
INNER JOIN StoreInventory
ON Products.ProductId=StoreInventory.ProductId
INNER JOIN Locations
ON StoreInventory.StoreId = Locations.StoreId
WHERE Locations.StoreId = 3;


INSERT INTO Locations([Location]) VALUES('New Orleans, USA');
INSERT INTO Locations([Location]) VALUES('Chicago, USA');
INSERT INTO Locations([Location]) VALUES('Gotham City, USA');
INSERT INTO Locations([Location]) VALUES('Caemlyn, Andor');
INSERT INTO Locations([Location]) VALUES('Riften, Province of Skyrim');
INSERT INTO Locations([Location]) VALUES('Waterdeep, Sword Coast');
INSERT INTO Locations([Location]) VALUES('Konoha, Land of Fire');
INSERT INTO Locations([Location]) VALUES('Kholinar, Alethkar');

INSERT INTO Products(ProductName, ProductDescription, ProductPrice, QuantityAvailable)
VALUES('The Eye of the World', 'Wheel of Time #1', 14.40, 10);
INSERT INTO Products(ProductName, ProductDescription, ProductPrice, QuantityAvailable)
VALUES('The Great Hunt', 'Wheel of Time #2', 16.75, 10);
INSERT INTO Products(ProductName, ProductDescription, ProductPrice, QuantityAvailable)
VALUES('The Dragon Reborn', 'Wheel of Time #3', 20.49, 10);
INSERT INTO Products(ProductName, ProductDescription, ProductPrice, QuantityAvailable)
VALUES('The Way of Kings', 'Stormlight Archive #1', 14.75, 10);
INSERT INTO Products(ProductName, ProductDescription, ProductPrice, QuantityAvailable)
VALUES('Words of Radiance', 'Stormlight Archive #2', 14.75, 10);
INSERT INTO Products(ProductName, ProductDescription, ProductPrice, QuantityAvailable)
VALUES('Oathbringer', 'Stormlight Archive #3', 18.49, 10);
INSERT INTO Products(ProductName, ProductDescription, ProductPrice, QuantityAvailable)
VALUES('Rythm of War', 'Stormlight Archive #4', 20.99, 10);
INSERT INTO Products(ProductName, ProductDescription, ProductPrice, QuantityAvailable)
VALUES('Storm Front', 'Dresden Files #1', 7.98, 10);
INSERT INTO Products(ProductName, ProductDescription, ProductPrice, QuantityAvailable)
VALUES('Fool Moon', 'Dresden Files #2', 18.00, 10);
INSERT INTO Products(ProductName, ProductDescription, ProductPrice, QuantityAvailable)
VALUES('Grave Peril', 'Dresden Files #3', 18.00, 10);
INSERT INTO Products(ProductName, ProductDescription, ProductPrice, QuantityAvailable)
VALUES('Die Erlking', 'Lore on the fae leader of the Wild Hunt', 400.00, 1);
INSERT INTO Products(ProductName, ProductDescription, ProductPrice, QuantityAvailable)
VALUES('The Black Arrow', 'Tale of Gorgic Guine, footman turned bard', 4.00, 5);
INSERT INTO Products(ProductName, ProductDescription, ProductPrice, QuantityAvailable)
VALUES('Uzumaki Naruto', 'Naruto Vol.1', 18.00, 10);
INSERT INTO Products(ProductName, ProductDescription, ProductPrice, QuantityAvailable)
VALUES('Ryomen Sukuna', 'Jujutsu Kaisen Vol.1', 6.99, 10);

INSERT INTO StoreInventory(StoreId, ProductId, Inventory)
VALUES(2,1,1),(2,2,1),(2,3,1),(2,4,1),(2,5,1),(2,6,1),(2,7,1),
(2,8,1),(2,9,1),(2,10,1),(2,13,1),(2,14,1);
INSERT INTO StoreInventory(StoreId, ProductId, Inventory)
VALUES(3,1,1),(3,2,1),(3,3,1),(3,4,1),(3,5,1),(3,6,1),(3,7,1),
(3,8,3),(3,9,3),(3,10,3),(3,11,1),(3,13,1),(3,14,1);
INSERT INTO StoreInventory(StoreId, ProductId, Inventory)
VALUES(4,1,1),(4,2,1),(4,3,1),(4,4,1),(4,5,1),(4,6,1),(4,7,1),
(4,8,1),(4,9,1),(4,10,1),(4,13,1),(4,14,2);
INSERT INTO StoreInventory(StoreId, ProductId, Inventory)
VALUES(5,1,2),(5,2,2),(5,3,2),(5,4,2),(5,5,2),(5,6,2),(5,7,2),
(5,8,1),(5,9,1),(5,10,1),(5,13,1),(5,14,1);
INSERT INTO StoreInventory(StoreId, ProductId, Inventory)
VALUES(6,1,1),(6,2,1),(6,3,1),(6,4,1),(6,5,1),(6,6,1),(6,7,1),
(6,8,1),(6,9,1),(6,10,1),(6,12,5),(2,13,1),(2,14,1);
INSERT INTO StoreInventory(StoreId, ProductId, Inventory)
VALUES(7,1,1),(7,2,1),(7,3,1),(7,4,1),(7,5,1),(7,6,1),(7,7,1),
(7,8,1),(7,9,1),(7,10,1),(7,13,1),(7,14,1);
INSERT INTO StoreInventory(StoreId, ProductId, Inventory)
VALUES(8,1,1),(8,2,1),(8,3,1),(8,4,1),(8,5,1),(8,6,1),(8,7,1),
(8,8,1),(8,9,1),(8,10,1),(8,13,3),(8,14,1);
INSERT INTO StoreInventory(StoreId, ProductId, Inventory)
VALUES(9,1,2),(9,2,2),(9,3,2),(9,4,2),(9,5,2),(9,6,2),(9,7,2),
(9,8,1),(9,9,1),(9,10,1),(9,13,1),(9,14,1);