SELECT p.pid, p.name,p.empGroup,p.empConDate, 
	(select count(d.LeaveId) as N 
		from LeaveReason l, LeaveDetails d  
		where l.eid=p.PId and l.LeaveId=d.LeaveId and  (d.leaveDate between '1/1/2013' and '5/26/2013') and  l.LeaveType='Casual Leave' ) AS CL,
	(select count(d.LeaveId) as N 
		from LeaveReason l, LeaveDetails d  
		where l.eid=p.PId and l.LeaveId=d.LeaveId and  (d.leaveDate between '1/1/2013' and '5/26/2013') and  l.LeaveType='Sick Leave' ) AS SL, 
	(select count(d.LeaveId) as N 
		from LeaveReason l, LeaveDetails d  
		where l.eid=p.PId and l.LeaveId=d.LeaveId  and  l.LeaveType='Compensatory Leave') AS ComL, 
	(select top 1 noofday As TCL from setLeave where  leavename='Casual Leave') AS TCL, 
	(select top 1 noofday As TCL from setLeave where  leavename='Sick Leave') AS TSL,
	(select count(o.caldate) as ED 
			from offCalender o 
				where exists(
						select i.edate 
							from Information i 
							where  (o.CalDate=i.eDate and  i.Id=p.PID) and (p.empGroup='NA'  or  ((p.empCondate is not null or o.ImplementedOn='All' ) AND i.edate >= p.empcondate )) and (p.empGroup=o.ImplementedOn or o.ImplementedOn='All'))) AS TComL--,
	 --'1/12/2006' AS caLv_activateDate, '1/12/2003' AS SkLv_activateDate, '12/31/2013' AS lastDate_ReportYear
FROM personal AS p 
Where p.pid=96 
GROUP BY p.PId, p.name, p.joindate, p.empConDate,p.empGroup


/*
select top 1 'Annual Entitlement' As LeaveRecord, noofday As TotalDays, 'Casual Leave' As LeaveType, activateDate As ActivateDay from setLeave where  leavename='Casual Leave'
--Union All
select top 1 'Annual Entitlement' As LeaveRecord, noofday As TotalDays, 'Sick Leave' As LeaveType, activateDate As ActivateDay from setLeave where  leavename='Sick Leave'


select top 1 'Annual Entitlement' As LeaveRecord, noofday As TotalDays, 'Casual Leave' As LeaveType from setLeave where  leavename='Casual Leave'
--Union All
select top 1 'Annual Entitlement' As LeaveRecord, noofday As TotalDays, 'Sick Leave' As LeaveType from setLeave where  leavename='Sick Leave'

select 'Annual Entitlement' As LeaveRecord, count(o.caldate) AS TotalDays, 'Compansatory' As LeaveType
from offCalender o, personal AS p 
where exists(
			select i.edate 
			from Information i 
						where  (o.CalDate=i.eDate and  i.Id=p.PID And p.pid=96) and (p.empGroup='NA'  or  ((p.empCondate is not null or o.ImplementedOn='All' ) AND i.edate >= p.empcondate )) and (p.empGroup=o.ImplementedOn or o.ImplementedOn='All'))



select blncEL from EarnedLeave where eId=96 and leaveYear=2012

select * from EarnedLeave

*/

