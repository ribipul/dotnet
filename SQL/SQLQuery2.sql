select * from SERVICE_LIST

select * from Ledger where SBName like 'Online%'

--update Ledger set SBName = 'Online Job Posting - Premium'
--where ID = 1202

--where ID in (select ledgerId from SERVICE_LIST)

--insert into Ledger(SBName, Under, MGroup, LevelNo, OpeningBalance, LedgerAcc)
--		values('Online Job Posting (Premium)', '5,9', 'Revenue', 2, 0, 1)


--insert into SERVICE_LIST(ServiceID, ServiceName, ServicePrice, LedgerId)
--		values(11, 'Online Job Posting (Premium)', 1500, 1202)

select * from tmpJobs
where CP_ID=35450

Select cp_id,acc_id,cname,count(cp_id) as TJ,tjobs, OPID from tmpJobs group by cp_id,acc_id,cname,tjobs,invoice_no, OPID order by acc_id,cname


Select jp_id, cname, Title, PostingDate, ValidDate, (CASE WHEN AddType = 1 THEN 'Advanced' WHEN AddType = 2 THEN 'Premium' ELSE '' END) As AddType from tmpJobs where TNO=0


select jp_id,acc_id,cname from tmpJobs where jp_id=517151

Select id,name from contactPersons where cid=12117

Select LedgerId, ServiceName, ServiceId from Service_List order by ServiceName




Select jp_id,cname,Title,PostingDate,ValidDate from tmpJobs where TNO=0 and cp_id=39513

select jp_id,acc_id,cname from tmpJobs

Select jp_id,cname,Title,PostingDate,ValidDate, (CASE WHEN AddType = 1 THEN 'Advanced' WHEN AddType = 2 THEN 'Premium' ELSE '' END) As Type, AddType from tmpJobs where TNO=0 and cp_id=31625

