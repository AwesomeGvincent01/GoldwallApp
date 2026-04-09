SELECT DefectType.Name, COUNT(DefectReport.DefectReportId) AS DefectCount
FROM DefectType
INNER JOIN DefectReport
    ON DefectType.DefectTypeId = DefectReport.DefectTypeId
GROUP BY DefectType.Name
ORDER BY DefectCount DESC;