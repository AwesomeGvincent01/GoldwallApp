Use GoldwallAppDb;

--this query shows job titles for jobs planned within the within the 2024 year, ordered alphabetically from A to Z.



Select Title
From Job
Where StartDatePlanned >= '2024-01-01' and EndDatePlanned <= '2024-12-31'
Order By Title Asc --This sorts the title ALPHABETICALLY from A to Z. To do it in reverse order, I'd use DESC instead of ASC.