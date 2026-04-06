SELECT Title, Status, StartDatePlanned
FROM Job
WHERE Status = 'Active'
ORDER BY StartDatePlanned ASC;