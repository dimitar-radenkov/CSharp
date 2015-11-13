--1.What is SQL ?
--SQL is a standard language for accessing databases.

--What is DML?
--A data manipulation language (DML) is a family of syntax elements similar to a computer
-- programming language used for selecting, inserting, deleting and updating data in a database.

--Most important commands
--SELECT, UPDATE, INSERT, DELETE

--2.What is Transact-SQL (T-SQL)?
--Transact-SQL (T-SQL) is Microsoft's and Sybase's proprietary extension to SQL. SQL,
-- the acronym for Structured Query Language, is a standardized computer language that--
-- was originally developed by IBM for querying, altering and defining relational databases,
-- using declarative statements. 
--T-SQL expands on the SQL standard to include procedural programming, local variables,
-- various support functions for string processing, date processing, mathematics,
-- etc. and changes to the DELETE and UPDATE statements. These additional features make Transact-SQL Turing complete.

--3.ALREADY DONE

--4.Write a SQL query to find all information about all departments (use "TelerikAcademy" database).
--SELECT * FROM [TelerikAcademy].[dbo].[Departments];


--5.Write a SQL query to find all department names.
--SELECT Name FROM [TelerikAcademy].[dbo].[Departments];


--6.Write a SQL query to find the salary of each employee.
--SELECT Salary FROM [TelerikAcademy].[dbo].[Employees];


--7.Write a SQL to find the full name of each employee.
--SELECT FirstName + ' ' + MiddleName + ' ' + LastName AS [Full Name]
--	FROM [TelerikAcademy].[dbo].[Employees];


--8.Write a SQL query to find the email addresses of each employee (by his first and last name).
--Consider that the mail domain is telerik.com. Emails should look like “John.Doe@telerik.com". 
--The produced column should be named "Full Email Addresses".
--SELECT FirstName + '.' + LastName + '@telerik.com' AS [Full Email Address]
--	FROM [TelerikAcademy].[dbo].[Employees];


--9.Write a SQL query to find all different employee salaries.
--SELECT DISTINCT Salary from [TelerikAcademy].[dbo].[Employees] ;

--10.Write a SQL query to find all information about the employees whose job title is “Sales Representative“.
--SELECT Salary from [TelerikAcademy].[dbo].[Employees]
--	WHERE JobTitle = 'Sales Representative';


--11.Write a SQL query to find the names of all employees whose first name starts with "SA".
--SELECT FirstName + ' ' + MiddleName + ' ' + LastName AS [Full Name]
--	FROM [TelerikAcademy].[dbo].[Employees]
--	WHERE FirstName LIKE 'SA%';


--12.Write a SQL query to find the names of all employees whose last name contains "ei".
--SELECT FirstName + ' ' + MiddleName + ' ' + LastName AS [Full Name]
--	FROM [TelerikAcademy].[dbo].[Employees]
--	WHERE LastName LIKE '%ei%';


--13.Write a SQL query to find the salary of all employees whose salary is in the range [20000…30000].
--SELECT FirstName + ' ' + MiddleName + ' ' + LastName AS [Full Name],
--	   Salary
--	FROM [TelerikAcademy].[dbo].[Employees]
--	WHERE Salary BETWEEN 20000 AND 30000;


--14.Write a SQL query to find the names of all employees whose salary 
--is 25000, 14000, 12500 or 23600.
--SELECT FirstName + ' ' + MiddleName + ' ' + LastName AS [Full name],
--	   Salary
--	   FROM [TelerikAcademy].[dbo].[Employees]
--	   WHERE Salary = 25000 OR Salary = 14000 OR Salary = 12500  OR Salary = 23600;


--15.Write a SQL query to find all employees that do not have manager.
--SELECT * FROM [TelerikAcademy].[dbo].[Employees] 
--	WHERE ManagerID IS NULL;


--16.Write a SQL query to find all employees that have salary more than 50000.
--Order them in decreasing order by salary.
--SELECT * FROM [TelerikAcademy].[dbo].[Employees]
--	WHERE Salary > 50000 ORDER BY Salary DESC


--17.Write a SQL query to find the top 5 best paid employees.
--SELECT TOP 5 * FROM [TelerikAcademy].[dbo].[Employees]
--	WHERE Salary > 50000 


--18.Write a SQL query to find all employees along with their address. 
--Use inner join with ON clause.
--SELECT * FROM [TelerikAcademy].[dbo].[Employees]
--	INNER JOIN [TelerikAcademy].[dbo].[Addresses]
--	ON [TelerikAcademy].[dbo].[Employees].AddressID = [TelerikAcademy].[dbo].[Addresses].AddressID;


--19.Write a SQL query to find all employees and their address. 
--Use equijoins (conditions in the WHERE clause).
--SELECT * FROM 
--	[TelerikAcademy].[dbo].[Employees], [TelerikAcademy].[dbo].Addresses
--	WHERE [TelerikAcademy].[dbo].[Employees].AddressID = [TelerikAcademy].[dbo].[Addresses].AddressID;


--20.Write a SQL query to find all employees along with their manager.
--SELECT e.FirstName + ' ' + e.LastName AS Employee, 
--	   m.FirstName + ' ' + m.LastName AS Manager
--	   FROM [TelerikAcademy].[dbo].[Employees] e JOIN [TelerikAcademy].[dbo].[Employees] m
--	   ON e.ManagerID = m.EmployeeID;


--21.Write a SQL query to find all employees, along with their manager and their address. 
--Join the 3 tables: Employees e, Employees m and Addresses a.
--SELECT e.FirstName + ' ' + e.LastName AS Employee,
--	   m.FirstName + ' ' + m.LastName AS Manager,
--	   a.AddressText
--	   FROM [TelerikAcademy].[dbo].[Employees] e
--	   JOIN [TelerikAcademy].[dbo].[Employees] m
--		ON e.ManagerID = m.EmployeeID
--	   JOIN [TelerikAcademy].[dbo].[Addresses] a
--	    ON e.AddressID = a.AddressID;


--22.Write a SQL query to find all departments and all town names as a single list. Use UNION.
--SELECT Name FROM [TelerikAcademy].[dbo].[Towns]
--	UNION 
--SELECT Name FROM [TelerikAcademy].[dbo].[Departments]

--23.Write a SQL query to find all the employees and the manager for each of 
--them along with the employees that do not have manager.
--Use right outer join. Rewrite the query to use left outer join.
--SELECT e.FirstName + ' ' + e.LastName AS [Employee Name], 
--	   m.FirstName + ' ' + m.LastName AS [Manager Name] 
--	FROM [TelerikAcademy].[dbo].[Employees] e
--	RIGHT OUTER JOIN 
--	[TelerikAcademy].[dbo].[Employees] m
--	ON e.ManagerID = m.EmployeeID;

--SELECT e.FirstName + ' ' + e.LastName AS [Employee Name], 
--	   m.FirstName + ' ' + m.LastName AS [Manager Name] 
--	FROM [TelerikAcademy].[dbo].[Employees] e
--	LEFT OUTER JOIN 
--	[TelerikAcademy].[dbo].[Employees] m
--	ON e.ManagerID = m.EmployeeID;

--24.Write a SQL query to find the names of all employees from the departments 
--"Sales" and "Finance" whose hire year is between 1995 and 2005.
SELECT FirstName + ' ' + LastName AS [Name]
	FROM [TelerikAcademy].[dbo].[Employees]
	WHERE (DepartmentID = (SELECT DepartmentID FROM [TelerikAcademy].[dbo].[Departments] 
				WHERE Name = 'Sales') 
		OR DepartmentID = (SELECT DepartmentID FROM [TelerikAcademy].[dbo].[Departments] 
				WHERE Name = 'Finance')) 
	AND HireDate BETWEEN '1995' AND '2005'
	

