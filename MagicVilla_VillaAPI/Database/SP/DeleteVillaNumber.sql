CREATE PROCEDURE DeleteVillaNumber
(
    @VillaNo INT
)
AS
BEGIN
    DELETE
    FROM VillaNumbers
    WHERE VillaNo = @VillaNo;
END;