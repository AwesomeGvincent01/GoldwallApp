Use GoldwallAppDb;

-- This query counts how many evidence photos belong to each work event.




SELECT WorkEvent.WorkEventId, COUNT(EvidencePhoto.EvidencePhotoId) AS PhotoCount
FROM WorkEvent
INNER JOIN EvidencePhoto
    ON WorkEvent.WorkEventId = EvidencePhoto.WorkEventId
GROUP BY WorkEvent.WorkEventId -- GROUP BY groups the photos under each WorkEventId.
HAVING COUNT(EvidencePhoto.EvidencePhotoId) >= 1 --HAVING keeps only work events that have at least 1 evidence photo attached to them.
ORDER BY PhotoCount DESC;