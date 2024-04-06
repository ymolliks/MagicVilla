CREATE PROCEDURE GetAllVillaNumbers
AS
BEGIN
    SELECT VillaNo, SpecialDetails, CreatedDate, UpdatedDate
    FROM VillaNumbers;
END;