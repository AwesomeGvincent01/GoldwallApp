Use GoldwallAppDb;

-- This query adds together the total surface area for each room.

Use GoldwallAppDb;  

SELECT Room.Name, SUM(Surface.AreaM2) AS TotalSurfaceArea -- SUM adds the AreaM2 values inside each room group.
FROM Room
INNER JOIN Surface
    ON Room.RoomId = Surface.RoomId
GROUP BY Room.Name
