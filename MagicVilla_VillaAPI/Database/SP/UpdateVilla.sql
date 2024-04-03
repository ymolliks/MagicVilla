CREATE PROCEDURE UpdateVilla
(
    @id INT,
    @name NVARCHAR(255),
    @sqft INT,
    @occupancy INT,
    @details NVARCHAR(MAX),
    @rate FLOAT,
    @imageURL NVARCHAR(MAX),
    @amenity NVARCHAR(MAX),
    @updatedDate DATETIME
)
AS
BEGIN
    UPDATE Villas
    SET
        Name = @name,
        Sqft = @sqft,
        Occupancy = @occupancy,
        Details = @details,
        Rate = @rate,
        ImageURL = @imageURL,
        Amenity = @amenity,
        UpdatedDate = @updatedDate
    WHERE Id = @id;
END;