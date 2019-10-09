SELECT P.Name, LR.LeaveType, LD.LeaveDate FROM Personal P, LeaveReason LR, LeaveDetails LD
WHERE P.pId = LR.EID And LR.LeaveID = LD.LEaveID --And Pid = 39 
And Month(LD.LeaveDate) = 9 And Year(LD.LeaveDate) = 2013


--select * from Department

--Select * From Personal 
--where deptid = 2