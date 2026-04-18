Use GoldwallAppDb;

-- This query counts how many work events belong to each event type.

Use GoldwallAppDb;

SELECT EventType.Name, COUNT(WorkEvent.WorkEventId) AS WorkEventCount
FROM EventType
INNER JOIN WorkEvent
    ON EventType.EventTypeId = WorkEvent.EventTypeId
GROUP BY EventType.Name
HAVING COUNT(WorkEvent.WorkEventId) > 1 -- HAVING is used after GROUP BY to filter groups based on the count of work events. In this case, it only includes event types that have more than 1 work event.

ORDER BY WorkEventCount DESC;