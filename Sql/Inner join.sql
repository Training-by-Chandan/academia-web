select s.Id as StudentId, s.Name as StudentName, s.Email as StudentEmail, sd.Father as FatherName, sd.Mother as MotherName
from Student s 
inner join 
(Select sf.StudentId, sf.GuardianName as Father, sm.GuardianName as Mother from StudentGuardian sf
join StudentGuardian sm
on sf.StudentId=sm.StudentId where sf.Type=0 and sm.Type=1) sd
 on s.Id=sd.StudentId


 Select * from StudentDetail
