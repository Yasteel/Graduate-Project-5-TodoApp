--CREATE DATABASE Todo;

USE Todo;

--CREATE TABLE Users(
--	pkUserId INTEGER NOT NULL PRIMARY KEY IDENTITY(1,1),
--	[Name] VARCHAR(50) NOT NULL,
--	[Surname] VARCHAR(50)
--);

--CREATE TABLE Todo(
--	pkTodoId INTEGER NOT NULL PRIMARY KEY IDENTITY(1,1),
--	fkUserId INTEGER NOT NULL,
--	[Description] VARCHAR(100)

--	FOREIGN KEY (fkUserId) REFERENCES Users(pkUserId)
--);

--CREATE TABLE Tasks(
--	pkTaskId INTEGER NOT NULL PRIMARY KEY IDENTITY(1,1),
--	fkTodoId INTEGER NOT NULL,
--	TaskName VARCHAR(75),
--	[Status] VARCHAR(15),
--	[Description] VARCHAR(150),
--	CreatedDate DATETIME DEFAULT CURRENT_TIMESTAMP
--);


--INSERT INTO Users
--VALUES
--	('Yastee', 'Gungas');

--INSERT INTO Todo
--VALUES
--	(1,'TEST')

INSERT INTO Tasks
	(fkTodoId, TaskName, [Status], [Description])
VALUES
	(1,'Test Task 2', 'NEW', 'Now testing my API with more than one task')