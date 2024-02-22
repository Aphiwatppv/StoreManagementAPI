CREATE TABLE dbo.TransactionTb (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Datetime DATETIME NOT NULL,
    ProductName NVARCHAR(255),
    ProductID INT NOT NULL,
    OldPrice DECIMAL(19, 4),
    NewPrice DECIMAL(19, 4),
    Unit NVARCHAR(50),
    Details NVARCHAR(MAX),
    Type NVARCHAR(255) CHECK (Type IN ('Adjust Detail', 'Adjust Price', 'Add new product')),
    FOREIGN KEY (ProductID) REFERENCES dbo.MainStoreTb (ProductID)
);
