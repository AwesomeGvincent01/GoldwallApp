Use GoldwallAppDb;
-- This query counts how many rooms belong to each job.


SELECT Job.Title, COUNT(Room.RoomId) AS RoomCount -- COUNT counts the RoomId values inside each group.
FROM Job
INNER JOIN Room
    ON Job.JobId = Room.JobId
GROUP BY Job.Title -- GROUP BY groups the results by job title so each job gets its own count.
ORDER BY RoomCount DESC;