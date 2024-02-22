CREATE PROCEDURE [dbo].[spGetProductsCloseToAlertLimit]
AS
BEGIN
    SELECT *
    FROM MainStoreTb
    WHERE StockQuantity <= AlertingLimit * 1.10
    AND StockQuantity >= AlertingLimit
END