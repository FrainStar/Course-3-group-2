-- Создание таблицы категорий
CREATE TABLE categories (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    category_name TEXT NOT NULL
);

-- Создание таблицы продуктов
CREATE TABLE products (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    product_name TEXT NOT NULL,
    price REAL NOT NULL,
    category_id INTEGER,
    FOREIGN KEY (category_id) REFERENCES categories(id)
);

-- Создание таблицы клиентов
CREATE TABLE customers (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    customer_name TEXT NOT NULL,
    email TEXT NOT NULL UNIQUE
);

-- Создание таблицы заказов
CREATE TABLE orders (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    order_date TEXT NOT NULL,
    customer_id INTEGER,
    FOREIGN KEY (customer_id) REFERENCES customers(id)
);

-- Создание таблицы деталей заказов
CREATE TABLE order_details (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    order_id INTEGER,
    product_id INTEGER,
    quantity INTEGER NOT NULL,
    FOREIGN KEY (order_id) REFERENCES orders(id),
    FOREIGN KEY (product_id) REFERENCES products(id)
);

-- Вставка данных в таблицу категорий
INSERT INTO categories (category_name) VALUES 
('Электроника'),
('Одежда'),
('Книги');

-- Вставка данных в таблицу продуктов
INSERT INTO products (product_name, price, category_id) VALUES 
('Смартфон', 700.00, 1),
('Наушники', 50.00, 1),
('Футболка', 20.00, 2),
('Джинсы', 40.00, 2),
('Роман', 15.00, 3),
('Учебник', 30.00, 3);

-- Вставка данных в таблицу клиентов
INSERT INTO customers (customer_name, email) VALUES 
('Иван Иванов', 'ivanov@example.com'),
('Мария Смирнова', 'smirnova@example.com'),
('Петр Петров', 'petrov@example.com');

-- Вставка данных в таблицу заказов
INSERT INTO orders (order_date, customer_id) VALUES 
('2024-08-01', 1),
('2024-08-02', 2),
('2024-08-03', 3);

-- Вставка данных в таблицу деталей заказов
INSERT INTO order_details (order_id, product_id, quantity) VALUES 
(1, 1, 2),  -- Иван Иванов купил 2 смартфона
(1, 3, 1),  -- Иван Иванов купил 1 футболку
(2, 2, 3),  -- Мария Смирнова купила 3 пары наушников
(3, 4, 1),  -- Петр Петров купил 1 пару джинсов
(3, 5, 2);  -- Петр Петров купил 2 романа


/*1. Выполните sql запрос из файла "SQL скрипт".
Напишите следующие запросы:
- запрос для выборки всех заказов с подробной информацией о клиентах и продуктах
- запрос для выборки всех клиентов и их заказов, включая клиентов без заказов
- запрос для выборки всех продуктов и заказов, включая продукты, которые не были заказаныэ
- запрос для выборки всех клиентов и продуктов

2. Напишите следующие запросы:
- запрос для выборки пар продуктов одной категории с разными ценами
- запрос, который вернет список клиентов и общую сумму, которую каждый клиент потратил на все свои заказы. Отобразите только тех клиентов, которые потратили более 100 единиц валюты
- запрос, который выведет всех клиентов, которые еще не сделали ни одного заказа и найдите тех клиентов, у которых нет связанных записей в таблице orders

3. Напишите следующие запросы:
- запрос, который выведет все продукты, которые не были куплены ни в одном заказе и отфильтруйте результаты, чтобы показать только те продукты, которые не имеют связанных записей в order_details
- запрос, который вернет полный список всех клиентов и продуктов, независимо от того, сделали ли клиенты заказы или были ли проданы продукты. Поскольку SQLite не поддерживает FULL OUTER JOIN, эмулируйте его с помощью UNION ALL для комбинации результатов LEFT JOIN и RIGHT JOIN
- запрос, который найдет все возможные комбинации продуктов для заказа, исключая продукты из категории "Электроника". Используйте CROSS JOIN, чтобы создать полное декартово произведение всех продуктов.*/


-- Task1
SELECT o.id,
o.order_date,
c.customer_name,
c.email,
p.product_name,
p.price,
od.quantity
FROM orders o
INNER JOIN customers c ON o.customer_id = c.id
INNER JOIN order_details od ON o.id = od.order_id
INNER JOIN products p ON od.product_id = p.id;

-- Task2
SELECT c.customer_name,
c.email,
o.id,
o.order_date
FROM customers c
LEFT JOIN orders o ON c.id = o.customer_id;

-- Task3 
SELECT p.product_name,
p.price,
od.order_id,
od.quantity
FROM products p
LEFT JOIN order_details od ON p.id = od.product_id;

-- Task4
SELECT c.customer_name, 
p.product_name
FROM customers c
INNER JOIN products p;

-- Task5
SELECT p1.product_name AS product1,
p2.product_name AS product2,
p1.category_id,
p1.price AS price1,
p2.price AS price2
FROM products p1
INNER JOIN products p2 ON p1.category_id = p2.category_id
WHERE p1.id < p2.id AND p1.price != p2.price;

-- Task6 
SELECT c.customer_name,
SUM(p.price * od.quantity) AS total_spent
FROM customers c
INNER JOIN orders o ON c.id = o.customer_id
INNER JOIN order_details od ON o.id = od.order_id
INNER JOIN products p ON od.product_id = p.id
GROUP BY c.id
HAVING total_spent > 100;

-- Task7
SELECT c.customer_name,
c.email
FROM customers c
LEFT JOIN orders o ON c.id = o.customer_id
WHERE o.id IS NULL;

-- Task8
SELECT p.product_name,
p.price
FROM products p
LEFT JOIN order_details od ON p.id = od.product_id
WHERE od.id IS NULL;

-- Task9 
SELECT c.customer_name, p.product_name
FROM customers c
LEFT JOIN orders o ON c.id = o.customer_id
LEFT JOIN order_details od ON o.id = od.order_id
LEFT JOIN products p ON od.product_id = p.id

UNION ALL

SELECT c.customer_name, p.product_name
FROM products p
LEFT JOIN order_details od ON p.id = od.product_id
LEFT JOIN orders o ON od.order_id = o.id
LEFT JOIN customers c ON o.customer_id = c.id
WHERE c.id IS NULL;

-- Task10
SELECT  p1.product_name AS product1, 
p2.product_name AS product2
FROM products p1
CROSS JOIN products p2
WHERE p1.category_id != (SELECT id FROM categories WHERE category_name = 'Электроника')
AND p2.category_id != (SELECT id FROM categories WHERE category_name = 'Электроника')
AND p1.id < p2.id;



