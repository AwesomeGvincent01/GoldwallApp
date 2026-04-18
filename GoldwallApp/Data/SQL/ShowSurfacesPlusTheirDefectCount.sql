Use GoldwallAppDb;

-- This query counts how many defect reports are linked to each surface.


SELECT Surface.Label, COUNT(DefectReport.DefectReportId) AS DefectCount
FROM Surface
INNER JOIN DefectReport
    ON Surface.SurfaceId = DefectReport.SurfaceId
GROUP BY Surface.Label
HAVING COUNT(DefectReport.DefectReportId) > 0 --HAVING is used after GROUP BY to filter groups based on the count of defect reports. In this case, it only includes surfaces that have at least 1 defect report.
ORDER BY DefectCount DESC;