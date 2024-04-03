CREATE PROCEDURE DeleteVilla
(
    @id INT
)
AS
BEGIN
    DELETE
    FROM Villas
    WHERE Id = @id;
END;