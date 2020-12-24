USE master
DROP DATABASE ordersDB
CREATE DATABASE ordersDB
USE ordersDB

CREATE TABLE [dbo].[Customers]
(
	[Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY, 
    [Name] NCHAR(50) NOT NULL
)

CREATE TABLE [dbo].[Items]
(
	[Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY, 
    [Name] NCHAR(50) NOT NULL
)

CREATE TABLE [dbo].[Orders] (
	[Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY, 
    [CustomerId] INT NOT NULL,
    [ItemId]     INT NOT NULL,
    CONSTRAINT [FK_Orders_ToItems] FOREIGN KEY ([ItemId]) REFERENCES [Items]([Id]),
    CONSTRAINT [FK_Orders_ToCustomers] FOREIGN KEY ([CustomerId]) REFERENCES [Customers]([Id])
)

INSERT INTO Customers (Name) VALUES ('Alexander Pushkin');
INSERT INTO Items (Name) VALUES ('Milk');
INSERT INTO Items (Name) VALUES ('Beer');
INSERT INTO Items (Name) VALUES ('Bread');
INSERT INTO Orders (CustomerId, ItemId) VALUES (1,1);
INSERT INTO Orders (CustomerId, ItemId) VALUES (1,2);
INSERT INTO Orders (CustomerId, ItemId) VALUES (1,3);

selecT * from Orders

SELECT Orders.Id, Customers.Name AS 'Customer.Name', Items.Name AS 'Item.Name' FROM
Orders LEFT JOIN Customers ON CustomerId = Customers.Id
       LEFT JOIN Items ON ItemId = Items.Id

       Select 100 union select 0