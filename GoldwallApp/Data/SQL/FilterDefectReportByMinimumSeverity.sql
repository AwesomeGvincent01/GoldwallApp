Use GoldwallAppDb;

-- This query uses a variable to store the minimum severity value.


DECLARE @MinSeverity INT; --declaring variable



SET @MinSeverity = 2; --setting the value stored in the variable, which is 2 in this case.

-- The query then shows defect reports where Severity is greater than or equal to the value stored in @MinSeverity, which means it will show defect reports with severity 2 and above. The results are ordered by Severity in descending order, so the most severe defects will appear first.

SELECT Description, Severity, Status
FROM DefectReport
WHERE Severity >= @MinSeverity
ORDER BY Severity DESC;