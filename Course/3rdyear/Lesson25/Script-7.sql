-- Создание таблицы пользователей
CREATE TABLE Users (
    UserID INT PRIMARY KEY,
    UserName VARCHAR(100),
    Email VARCHAR(255),
    CreatedAt DATETIME DEFAULT CURRENT_TIMESTAMP
);

-- Создание таблицы заказов
CREATE TABLE Orders (
    OrderID INT PRIMARY KEY,
    UserID INT,
    ProductID INT,
    Quantity INT,
    OrderDate DATETIME,
    FOREIGN KEY (UserID) REFERENCES Users(UserID)
);

-- Создание таблицы продуктов
CREATE TABLE Products (
    ProductID INT PRIMARY KEY,
    ProductName VARCHAR(255),
    Category VARCHAR(100),
    Price DECIMAL(10, 2)
);

-- Создание таблицы категорий
CREATE TABLE Categories (
    CategoryID INT PRIMARY KEY,
    CategoryName VARCHAR(100)
);


-- Заполнение таблицы пользователей
INSERT INTO Users (UserID, UserName, Email) VALUES
(1, 'John Doe', 'john@example.com'),
(2, 'Jane Smith', 'jane@example.com'),
(3, 'Alice Johnson', 'alice@example.com');

-- Заполнение таблицы продуктов
INSERT INTO Products (ProductID, ProductName, Category, Price) VALUES
(1, 'Laptop', 'Electronics', 1200.00),
(2, 'Smartphone', 'Electronics', 800.00),
(3, 'Desk Chair', 'Furniture', 150.00);

-- Заполнение таблицы заказов
INSERT INTO Orders (OrderID, UserID, ProductID, Quantity, OrderDate) VALUES
(1, 1, 1, 1, '2023-08-01'),
(2, 2, 2, 2, '2023-08-02'),
(3, 3, 3, 1, '2023-08-03');



-- Practice 1
-- EXPLAIN ANALYZE почему то не работает
EXPLAIN
SELECT * FROM Users WHERE Email = 'john@example.com';

EXPLAIN
SELECT * FROM Orders WHERE UserID = 1;

EXPLAIN
SELECT * FROM Products WHERE Category = 'Electronics';


-- Practice 2
CREATE INDEX idx_users_email ON Users(Email);

CREATE INDEX idx_orders_userid ON Orders(UserID);

CREATE INDEX idx_products_category ON Products(Category);


-- Practice 3
CREATE INDEX idx_orders_userid_productid ON Orders(UserID, ProductID);

CREATE INDEX idx_products_category_price ON Products(Category, Price);


