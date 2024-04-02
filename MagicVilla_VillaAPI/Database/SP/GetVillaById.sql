CREATE PROCEDURE GetVillaById
(
    @id INT
)
AS
BEGIN
    SELECT * FROM Villas WHERE Id = @id;
END;