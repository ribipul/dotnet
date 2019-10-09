declare @jid As int = 0
declare @id As int = 1890845

select @jid=max(jid)+1 from Journal

print @jid

--select * from Journal where jid in (select jid from Journal where id = @id)

update Journal
set jid = @jid
where id in (2161583,2161584)

select * from Journal
where id in (2161583,2161584)
