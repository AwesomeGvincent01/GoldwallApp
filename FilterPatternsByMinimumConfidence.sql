DECLARE @MinConfidence DECIMAL(5,2);
SET @MinConfidence = 0.75;
SELECT Title, Confidence
FROM Pattern
WHERE Confidence >= @MinConfidence
ORDER BY Confidence DESC;