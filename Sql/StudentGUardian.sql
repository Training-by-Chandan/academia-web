CREATE TABLE [dbo].[StudentGuardian]
(
	[Id] INT NOT NULL PRIMARY KEY Identity(1,1), 
    [StudentId] INT NOT NULL, 
    [GuardianName] NVARCHAR(50) NOT NULL, 
    [Type] INT NOT NULL
)

declare @param1 as int 
declare @param2 as int

set @param1=1
set @param2=2

SELECT @param1, @param2

	Select * from Student where id=@param1

	Select * from Student where id=@param2


--CRUD Operation
	--Insert Query
	Insert into Student (Name, Email)
	values
	('Student 1','test1@test.com'),
	('Student 2','test2@test.com'),
	('Student 3','test3@test.com')
	
	