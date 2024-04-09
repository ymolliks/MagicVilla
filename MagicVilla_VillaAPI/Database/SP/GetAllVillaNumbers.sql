CREATE PROCEDURE GetAllVillaNumbers
AS
BEGIN
    SELECT VillaNo, VillaId, SpecialDetails, CreatedDate, UpdatedDate
    FROM VillaNumbers;
END;