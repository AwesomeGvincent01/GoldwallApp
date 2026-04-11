SELECT Surface.Label, COUNT(DefectReport.DefectReportId) AS DefectCount
FROM Surface
INNER JOIN DefectReport
    ON Surface.SurfaceId = DefectReport.SurfaceId
GROUP BY Surface.Label
HAVING COUNT(DefectReport.DefectReportId) > 0
ORDER BY DefectCount DESC;