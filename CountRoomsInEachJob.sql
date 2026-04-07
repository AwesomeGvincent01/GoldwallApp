SELECT Job.Title, COUNT(Room.RoomId) AS RoomCount
FROM Job
INNER JOIN Room
    ON Job.JobId = Room.JobId
GROUP BY Job.Title
ORDER BY RoomCount DESC;