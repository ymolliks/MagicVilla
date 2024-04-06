CREATE PROCEDURE GetVillaNumber
(
    @VillaNo INT
)
AS
BEGIN
    SELECT VillaNo, SpecialDetails, CreatedDate, UpdatedDate
    FROM VillaNumbers
    WHERE VillaNo = @VillaNo;
END;