
select * from Student
declare @delete as bit
set @delete='True'
begin transaction
delete from Student where Password like 'g'
if @delete='True'
begin
	commit
end
else
begin
	rollback
end

select * from Student