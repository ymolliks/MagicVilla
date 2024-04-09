CREATE PROCEDURE UpdateVillaNumber
(
    @VillaNo INT,
    @VillaId INT,
    @SpecialDetails NVARCHAR(MAX),
    @UpdatedDate DATETIME
)
AS
BEGIN
    UPDATE VillaNumbers
    SET VillaId = @VillaId,
        SpecialDetails = @SpecialDetails,
        UpdatedDate = @UpdatedDate
    WHERE VillaNo = @VillaNo;
END;