-- Practice A
CREATE TABLE IF NOT EXISTS Teachers (
    TeacherID INTEGER PRIMARY KEY,
    FirstName TEXT,
    LastName TEXT,
    SubjectID INTEGER,
    FOREIGN KEY (SubjectID) REFERENCES Subjects(SubjectID)
);

CREATE TABLE IF NOT EXISTS Students (
    StudentID INTEGER PRIMARY KEY,
    FirstName TEXT,
    LastName TEXT,
    ClassID INTEGER,
    FOREIGN KEY (ClassID) REFERENCES Classes(ClassID)
);

CREATE TABLE IF NOT EXISTS Classes (
    ClassID INTEGER PRIMARY KEY,
    ClassName TEXT
);

CREATE TABLE IF NOT EXISTS Subjects (
    SubjectID INTEGER PRIMARY KEY,
    SubjectName TEXT
);

CREATE TABLE IF NOT EXISTS Schedule (
    ScheduleID INTEGER PRIMARY KEY,
    ClassID INTEGER,
    SubjectID INTEGER,
    TeacherID INTEGER,
    DayOfWeek TEXT,
    LessonTime TEXT,
    FOREIGN KEY (ClassID) REFERENCES Classes(ClassID),
    FOREIGN KEY (SubjectID) REFERENCES Subjects(SubjectID),
    FOREIGN KEY (TeacherID) REFERENCES Teachers(TeacherID)
);


-- Practice B
INSERT INTO Teachers (FirstName, LastName, SubjectID) VALUES
('Иван', 'Иванов', 1),
('Петр', 'Петров', 2),
('Анна', 'Сидорова', 3),
('Елена', 'Кузнецова', 4),
('Михаил', 'Смирнов', 5);

INSERT INTO Students (FirstName, LastName, ClassID) VALUES
('Алексей', 'Смирнов', 1),
('Ольга', 'Иванова', 2),
('Дмитрий', 'Петров', 3),
('Екатерина', 'Сидорова', 4),
('Николай', 'Кузнецов', 5);

INSERT INTO Classes (ClassName) VALUES
('1А'),
('2Б'),
('3В'),
('4Г'),
('5Д');

INSERT INTO Subjects (SubjectName) VALUES
('Математика'),
('Физика'),
('Химия'),
('История'),
('Литература');

INSERT INTO Schedule (ClassID, SubjectID, TeacherID, DayOfWeek, LessonTime) VALUES
(1, 1, 1, 'Понедельник', '08:00'),
(2, 2, 2, 'Вторник', '09:00'),
(3, 3, 3, 'Среда', '10:00'),
(4, 4, 4, 'Четверг', '11:00'),
(5, 5, 5, 'Пятница', '12:00');

SELECT * FROM Students;

UPDATE Teachers
SET FirstName = 'Александр', LastName = 'Александров'
WHERE TeacherID = 2;

SELECT * FROM Teachers;

UPDATE Schedule
SET DayOfWeek = 'Пятница', LessonTime = '14:00'
WHERE ClassID = 4 AND SubjectID = (SELECT SubjectID FROM Subjects WHERE SubjectName = 'Математика');

SELECT * FROM Schedule;

DELETE FROM Students
WHERE StudentID = 3;

DELETE FROM Schedule
WHERE ClassID = 2 AND SubjectID = 2;

UPDATE Students
SET ClassID = 2
WHERE StudentID = 5;



-- Pratice write
SELECT Students.FirstName, Students.LastName, Classes.ClassName
FROM Students
JOIN Classes ON Students.ClassID = Classes.ClassID;

SELECT Schedule.DayOfWeek, Schedule.LessonTime, Subjects.SubjectName, Teachers.FirstName, Teachers.LastName
FROM Schedule
JOIN Subjects ON Schedule.SubjectID = Subjects.SubjectID
JOIN Teachers ON Schedule.TeacherID = Teachers.TeacherID
WHERE Schedule.ClassID = 4;

SELECT Students.FirstName, Students.LastName, COUNT(Students.ClassID) AS NumberOfClasses
FROM Students
GROUP BY Students.StudentID;
