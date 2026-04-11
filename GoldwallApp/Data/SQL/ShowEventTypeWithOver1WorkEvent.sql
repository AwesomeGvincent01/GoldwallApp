SELECT EventType.Name, COUNT(WorkEvent.WorkEventId) AS WorkEventCount
FROM EventType
INNER JOIN WorkEvent
    ON EventType.EventTypeId = WorkEvent.EventTypeId
GROUP BY EventType.Name
HAVING COUNT(WorkEvent.WorkEventId) > 1
ORDER BY WorkEventCount DESC;