SELECT Room.Name, SUM(Surface.AreaM2) AS TotalSurfaceArea
FROM Room
INNER JOIN Surface
    ON Room.RoomId = Surface.RoomId
GROUP BY Room.Name
ORDER BY TotalSurfaceArea DESC;