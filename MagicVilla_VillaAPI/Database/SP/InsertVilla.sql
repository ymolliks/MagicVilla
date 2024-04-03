CREATE PROCEDURE InsertVilla
(
    @name NVARCHAR(255),
    @sqft INT,
    @occupancy INT,
    @details NVARCHAR(MAX),
    @rate FLOAT,
    @imageURL NVARCHAR(MAX),
    @amenity NVARCHAR(MAX),
    @createdDate DATETIME,
    @updatedDate DATETIME
)
AS
BEGIN    
    SET NOCOUNT ON;

    INSERT INTO Villas (
        Name, 
        Sqft, 
        Occupancy, 
        Details, 
        Rate, 
        ImageURL, 
        Amenity, 
        CreatedDate, 
        UpdatedDate
    )
    VALUES (
        @name, 
        @sqft, 
        @occupancy, 
        @details, 
        @rate, 
        @imageURL, 
        @amenity, 
        @createdDate, 
        @updatedDate
    );
    SELECT SCOPE_IDENTITY() as Id;
END;