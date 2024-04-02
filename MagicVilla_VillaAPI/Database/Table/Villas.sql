CREATE TABLE Villas (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(255) NOT NULL,
    Sqft INT,
    Occupancy INT,
    Details NVARCHAR(MAX),
    Rate FLOAT,
    ImageURL NVARCHAR(MAX),
    Amenity NVARCHAR(MAX),
    CreatedDate DATETIME,
    UpdatedDate DATETIME
);