CREATE TABLE [dbo].[MainStoreTb]
(
	ID INT IDENTITY(1,1) PRIMARY KEY,
    ProductName NVARCHAR(255),
    ProductID INT UNIQUE NOT NULL,
    StockQuantity INT NOT NULL,
    StockUnit NVARCHAR(50),
    AlertingLimit INT NOT NULL,
    Price DECIMAL(19, 4) NOT NULL,
    PriceUnit NVARCHAR(50),
    Description NVARCHAR(MAX)
)
