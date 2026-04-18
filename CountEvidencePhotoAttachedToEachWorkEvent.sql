Use GoldwallAppDb;

--this query shows job titles for jobs planned within the within the 2024 year, ordered alphabetically from A to Z.

SELECT WorkEvent.WorkEventId, COUNT(EvidencePhoto.EvidencePhotoId) AS PhotoCount
FROM WorkEvent
INNER JOIN EvidencePhoto
    ON WorkEvent.WorkEventId = EvidencePhoto.WorkEventId
GROUP BY WorkEvent.WorkEventId
HAVING COUNT(EvidencePhoto.EvidencePhotoId) >= 1
ORDER BY PhotoCount DESC;