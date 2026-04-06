SELECT Job.Title, Job.Address, Client.Name AS ClientName
FROM Job
INNER JOIN Client
    ON Job.ClientId = Client.ClientId
ORDER BY Job.Title ASC;