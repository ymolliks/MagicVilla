CREATE PROCEDURE CreateVillaNumber
(
    @VillaNo INT,
    @VillaId INT,
    @SpecialDetails NVARCHAR(MAX),
    @CreatedDate DATETIME,
    @UpdatedDate DATETIME
)
AS
BEGIN
    INSERT INTO VillaNumbers (VillaNo, VillaId, SpecialDetails, CreatedDate, UpdatedDate)
    VALUES (@VillaNo, @VillaId, @SpecialDetails, @CreatedDate, @UpdatedDate);
END;