use bdjCorporate
/*
select * from dbo_Company_Profiles where cp_id = 27601

select * from dbo_Company_Profiles where Name = 'Divine Group Limited'

select * from dbo_JobPostings where cp_id = 40166 And jp_ID in (772607,772614,772618)

select * from JobBillInfo where jp_ID in (772607,772614,772618)

--update JobBillInfo set PayStatus = 1 where jp_id in (772607,772614,772618)


select * from bdjActiveJobs..dbo_JobPostings_AJ where cp_id = 40166

--usp_Acc_Download_Jobs '6/9/2018', '6/11/2018'
*/
DECLARE @dtFromDate smalldatetime = '6/9/2018',
	@dtToDate smalldatetime = '6/11/2018'

Select c.cp_id,c.name,c.acc_id,j.jp_id--,j.JobTitle
	, CASE WHEN J.JobLang =2 THEN BJ.Title ELSE J.JobTitle END As JobTitle
	--, CASE WHEN j.PublishDate IS NULL THEN CONVERT(varchar(10), j.ProceedToPublishDate, 101) ELSE CONVERT(varchar(10), j.PublishDate, 101) END as P,j.Deadline,
	, CASE WHEN j.PublishDate IS NULL THEN CONVERT(varchar(10), j.ProceedToPublishDate, 101) ELSE CONVERT(varchar(10), (CASE WHEN j.PublishDate>j.ProceedToPublishDate THEN j.PublishDate ELSE j.ProceedToPublishDate END), 101) END as P,j.Deadline,
	(case when cp.ContactName is null then '...' else cp.ContactName end) as [BillingContact],
	(case when cp.designation is null then '...' else cp.designation end) as [Designation]
	, Count_jp_id=(select count(jp_id)
		from dbo_jobpostings where cp_id=c.cp_id)
	, b.OPID, (case when j.AdType is null then 0 else j.AdType end) as AdType
	, j.RegionalJob
	--, CASE WHEN (JC.CAT_ID >= 60 OR JC.CAT_ID = -11) THEN 1 ELSE 0 END As BlueCollar
	, BlueCollar = (SELECT CASE WHEN COUNT(1)>0 THEN 1 ELSE 0 END FROM DBO_JOB_CATEGORY WHERE jp_id=j.jp_id And (CAT_ID >= 60 OR CAT_ID = -11))
from (((dbo_company_profiles c 
	inner join dbo_jobpostings j on c.cp_id=j.cp_id) 
	--inner join DBO_JOB_CATEGORY JC ON J.JP_ID = JC.JP_ID)
	left join dbo_bng_jobpostings bj on j.jp_id = bj.jp_id) 
	left join JobBillInfo b on j.jp_id=b.jp_id) 
	Left Join ContactPersons cp on b.ContactId=cp.ContactId
where ((j.ProceedToPublishDate BETWEEN @dtFromDate And @dtToDate) OR (j.PublishDate BETWEEN @dtFromDate And @dtToDate))
	And j.jp_id>=400000 And b.PayStatus=1 
	And (b.invoiceID=0 or b.invoiceID is null) 
	And c.cp_id not in(
		select s.cp_id 
			from CompanyServices s 
				inner join Service_List l on s.ServiceId=l.serviceid 
		where l.serviceType in(2,3,6,10) And dateadd(day, s.Duration, s.Startingdate)>=getdate()
			And s.Complete=0 And s.Blocked=0 And j.ServiceId>0)
	And b.JType<>'H' And Drafted=0 And j.Deleted=0 And j.ServiceId=0 And j.RegionalJob <> 2
	--And c.cp_id = 26379
order by j.ProceedToPublishDate, c.name