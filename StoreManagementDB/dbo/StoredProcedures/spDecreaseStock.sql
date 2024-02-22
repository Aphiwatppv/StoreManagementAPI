CREATE PROCEDURE [dbo].[spDecreaseStock]
    @ProductID INT,
    @Amount INT
AS
BEGIN
    UPDATE MainStoreTb
    SET StockQuantity = StockQuantity - @Amount
    WHERE ProductID = @ProductID
    AND StockQuantity >= @Amount
END