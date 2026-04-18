Use GoldwallAppDb;

-- This query combines Job and Client so each job can be shown with its client name.


SELECT Job.Title, Job.Address, Client.Name AS ClientName
FROM Job
INNER JOIN Client -- INNER JOIN is used to combine rows from two or more tables based on a common  column between them. In this case, we are joining the Job table's foreign clientId with the Client table's primary clientId.

    ON Job.ClientId = Client.ClientId
ORDER BY Job.Title ASC;