CREATE PROCEDURE CreateVillaNumber
(
    @VillaNo INT,
    @SpecialDetails NVARCHAR(MAX),
    @CreatedDate DATETIME,
    @UpdatedDate DATETIME
)
AS
BEGIN
    INSERT INTO VillaNumbers (VillaNo, SpecialDetails, CreatedDate, UpdatedDate)
    VALUES (@VillaNo, @SpecialDetails, @CreatedDate, @UpdatedDate);
END;