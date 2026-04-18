Use GoldwallAppDb;

-- This query shows surface types where the area is between 8.20 and 12.00 square metres.


SELECT SurfaceType
From Surface
Where AreaM2 >= 8.20 and AreaM2 <= 12.00
Order by SurfaceType Asc -- ORDER BY SurfaceType ASC sorts the results alphabetically by the SurfaceType column in ascending order (A to Z).