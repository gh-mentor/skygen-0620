/*
This file contains a script of Transact SQL (T-SQL) command to interact with a database named 'Inventory'.
Requirements:
- SQL Server 2022 is installed and running
- database 'Inventory' already exists.
Details:
- check if the database 'Inventory' exists, if not the script will print an error message and exit.
- Sets the default database to 'Inventory'.
- Creates a 'categories' table and related 'products' table if they do not already exist.
- Remove all rows from the tables (in case they already existed).
- Populates the 'Categories' table with sample data.
- Populates the 'Products' table with sample data.
- Creates stored procedures to get all categories.
- Creates a stored procedure to get all products in a specific category.
- Creates a stored procudure to get all products in a specific price range sorted by price in ascending order.
*/

-- Check if the database 'Inventory' exists
IF NOT EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = N'Inventory')
BEGIN
    PRINT 'Error: The database Inventory does not exist. Please create the database and run this script again.'
    RETURN
END

-- Set the default database to 'Inventory'
USE Inventory

-- Create the 'Categories' table
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Categories')
BEGIN
    CREATE TABLE Categories (
        CategoryID INT PRIMARY
        IDENTITY(1,1),
        CategoryName NVARCHAR(50) NOT NULL
    )
END

-- Create the 'Products' table.
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Products')
BEGIN
    CREATE TABLE Products (
        ProductID INT PRIMARY KEY
        IDENTITY(1,1),
        ProductName NVARCHAR(50) NOT NULL,
        CategoryID INT NOT NULL,
        Price DECIMAL(10, 2) NOT NULL,
        -- Add a created date column
        CreatedDate DATETIME DEFAULT GETDATE(),
        -- Add a modified date column
        ModifiedDate DATETIME DEFAULT GETDATE(),
        CONSTRAINT FK_Products_Categories FOREIGN KEY (CategoryID) REFERENCES Categories(CategoryID)
    )
END

-- Remove all rows from the 'Products' table
DELETE FROM Products

-- Remove all rows from the 'Categories' table
DELETE FROM Categories



