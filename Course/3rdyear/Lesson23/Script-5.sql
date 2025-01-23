CREATE TABLE departments (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    department_name TEXT NOT NULL
);

CREATE TABLE employees (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    name TEXT NOT NULL,
    department_id INTEGER,
    position TEXT,
    salary REAL,
    FOREIGN KEY (department_id) REFERENCES departments(id)
);

INSERT INTO departments (department_name) VALUES 
('Маркетинг'),
('Разработка'),
('Продажи'),
('HR');

INSERT INTO employees (name, department_id, position, salary) VALUES 
('Иван Иванов', 2, 'Разработчик', 80000),
('Анна Смирнова', 1, 'Маркетолог', 60000),
('Петр Петров', 3, 'Менеджер по продажам', 70000),
('Мария Кузнецова', 4, 'HR-специалист', 50000),
('Ольга Сидорова', 2, 'Тестировщик', 55000),
('Алексей Федоров', 2, 'Разработчик', 85000),
('Елена Захарова', 1, 'Маркетолог', 62000),
('Дмитрий Орлов', 3, 'Менеджер по продажам', 72000);

/***Практика А**
Выполните скрипт из файла **SQL скрипт**. 
Напишите следующие запросы:
- запрос для выборки всех сотрудников, у которых зарплата выше 70,000
- запрос для выборки всех сотрудников, которые занимают должность "Разработчик"
- запрос для выборки всех сотрудников из отдела "Разработка", отсортированных по имени

**Практика В**
Напишите следующие запросы:
- запрос для выборки всех сотрудников с зарплатой 72,000, отсортированных по имени в обратном алфавитном порядке
- запрос для выборки всех сотрудников, у которых зарплата находится в диапазоне от 60,000 до 80,000
- запрос для выборки всех сотрудников определенного отдела, отсортированных по зарплате

**Практика С**
Напишите следующие запросы:
- запрос для группировки сотрудников по должности в отделе "HR" и подсчет количества сотрудников на каждой должности
- запрос для подсчета общей зарплаты по каждой должности в определенном отделе
- запрос для выборки должностей с максимальной и минимальной зарплатой в определенном отделе
- запрос для выборки всех сотрудников из отделов "Разработка" и "Маркетинг", отсортированных сначала по зарплате (по убыванию), затем по должности (по возрастанию) */


-- Task1
SELECT * FROM employees WHERE salary > 70000;

-- Task2
SELECT * FROM employees WHERE position = 'Разработчик';

-- Task3
SELECT e.* 
FROM employees e
JOIN departments d ON e.department_id = d.id
WHERE d.department_name = 'Разработка'
ORDER BY e.name;

-- Task4
SELECT * FROM employees WHERE salary = 72000 ORDER BY name DESC;

-- Task5
SELECT * FROM employees WHERE salary BETWEEN 60000 AND 80000;

-- Task6
SELECT e.* 
FROM employees e
JOIN departments d ON e.department_id = d.id
WHERE d.department_name = 'Разработка'
ORDER BY e.salary;

-- Task7
SELECT position, COUNT(*) as employee_count
FROM employees e
JOIN departments d ON e.department_id = d.id
WHERE d.department_name = 'HR'
GROUP BY position;

-- Task8
SELECT position, SUM(salary) as total_salary
FROM employees e
JOIN departments d ON e.department_id = d.id
WHERE d.department_name = 'Разработка'
GROUP BY position;

-- Task9
SELECT position, MAX(salary) as max_salary, MIN(salary) as min_salary
FROM employees e
JOIN departments d ON e.department_id = d.id
WHERE d.department_name = 'Разработка'
GROUP BY position;

-- Task10
SELECT e.* 
FROM employees e
JOIN departments d ON e.department_id = d.id
WHERE d.department_name IN ('Разработка', 'Маркетинг')
ORDER BY e.salary DESC, e.position ASC;

