SELECT TOP 1 p.pid, p.name, p.designation, p.joinDate, p.CardNO, d.deptName, p.empGroup, p.empActive, p.empActDate, p.empConfirm, empConDate 
FROM personal p, department d 
WHERE p.deptid = d.id And pId = 15 
ORDER BY p.pId ASC
