CREATE PROCEDURE GetVillaByName
(
    @name NVARCHAR(255)
)
AS
BEGIN
    SELECT * 
    FROM Villas 
    WHERE Name = @name;
END;