CREATE TABLE Orders (
    OrderID INT PRIMARY KEY IDENTITY(1,1), 
    CustomerID INT NOT NULL,                
    ProductID INT NOT NULL,                 
    Quantity INT NOT NULL,                  
    OrderDate DATETIME NOT NULL,
    OrderStatus NVARCHAR(50) NOT NULL,
    TotalPrice DECIMAL(18, 2) NOT NULL,     
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID),
    FOREIGN KEY (CustomerID) REFERENCES register(user_id)
    
);