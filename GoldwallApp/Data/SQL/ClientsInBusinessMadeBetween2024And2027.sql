Select *
From Client
Where BusinessId IN (Select BusinessId From Business Where CreatedAt >= '2024-01-01' and CreatedAt <= '2027-12-31')
Order By Name ASC;
