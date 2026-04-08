SELECT EventType.Name, COUNT(WorkEvent.WorkEventId) AS WorkEventCount
FROM EventType
INNER JOIN WorkEvent
    ON EventType.EventTypeId = WorkEvent.EventTypeId
GROUP BY EventType.Name
ORDER BY WorkEventCount DESC;