Use GoldwallAppDb;


-- This query uses a decimal variable to store the minimum confidence value.


DECLARE @MinConfidence DECIMAL(5,2);
SET @MinConfidence = 0.75;

-- It then shows patterns where Confidence is greater than or equal to 0.75.

SELECT Title, Confidence
FROM Pattern
WHERE Confidence >= @MinConfidence
ORDER BY Confidence DESC;