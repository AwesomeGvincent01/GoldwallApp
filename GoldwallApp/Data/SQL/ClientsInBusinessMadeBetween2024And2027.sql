
Use GoldwallAppDb;


--this query shows clients whose BusinessId matches the BusinessId of businesses created between 2024 and 2027, ordered alphabetically by client name from A to Z.
Use GoldwallAppDb;

Select *
From Client

Where BusinessId IN (Select BusinessId From Business Where CreatedAt >= '2024-01-01' and CreatedAt <= '2027-12-31') --this subquery inside IN first finds the matching business IDs for businesses created between 2024 and 2027, and then the main query retrieves all clients associated with those business IDs.

Order By Name ASC;
