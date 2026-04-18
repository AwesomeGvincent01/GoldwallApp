Use GoldwallAppDb;

-- This query shows active jobs and orders them by their planned start date.


SELECT Title, Status, StartDatePlanned
FROM Job
WHERE Status = 'Active'
ORDER BY StartDatePlanned ASC;