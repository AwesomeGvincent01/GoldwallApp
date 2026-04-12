DECLARE @MinSeverity INT;
SET @MinSeverity = 2;
SELECT Description, Severity, Status
FROM DefectReport
WHERE Severity >= @MinSeverity
ORDER BY Severity DESC;