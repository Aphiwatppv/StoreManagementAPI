CREATE PROCEDURE [dbo].[spAddNewProduct]
   @ProductName NVARCHAR(255),
    @ProductID INT,
    @StockQuantity INT,
    @StockUnit NVARCHAR(50),
    @AlertingLimit INT,
    @Price DECIMAL(19, 4),
    @PriceUnit NVARCHAR(50),
    @Description NVARCHAR(MAX)
AS
BEGIN
    INSERT INTO MainStoreTb (ProductName, ProductID, StockQuantity, StockUnit, AlertingLimit, Price, PriceUnit, Description)
    VALUES (@ProductName, @ProductID, @StockQuantity, @StockUnit, @AlertingLimit, @Price, @PriceUnit, @Description)
END
