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
    UpdatedDate DATETIME NULL
);

-- INSERT INTO Villas (Name, Sqft, Occupancy, Details, Rate, ImageURL, Amenity, CreatedDate, UpdatedDate)
-- VALUES
--     ('Villa Sunshine', 2000, 4, 'A beautiful sunny villa with 4 bedrooms.', 300.00, 'http://example.com/villa1.jpg', 'Pool, WiFi', '2023-01-01', '2023-01-01'),
--     ('Villa Sea Breeze', 1500, 3, 'Sea facing villa with stunning views.', 350.00, 'http://example.com/villa2.jpg', 'Beachfront, WiFi', '2023-02-01', '2023-02-01'),
--     ('Villa Mountain View', 2500, 5, 'Located in the mountains, perfect for hiking enthusiasts.', 400.00, 'http://example.com/villa3.jpg', 'Mountain View, Hiking Trails', '2023-03-01', '2023-03-01'),
--     ('Villa Lakefront', 1800, 4, 'A serene lakefront property.', 320.00, 'http://example.com/villa4.jpg', 'Lake Access, Boat Dock', '2023-04-01', '2023-04-01'),
--     ('Villa Orchard', 2200, 6, 'Surrounded by an orchard, offers a peaceful retreat.', 280.00, 'http://example.com/villa5.jpg', 'Orchard, Farm Experience', '2023-05-01', '2023-05-01'),
--     ('Villa Desert Mirage', 1200, 2, 'A minimalist villa in the desert.', 250.00, 'http://example.com/villa6.jpg', 'Desert View, Privacy', '2023-06-01', '2023-06-01'),
--     ('Villa Urban Escape', 1600, 3, 'A modern villa in the city.', 330.00, 'http://example.com/villa7.jpg', 'City View, Easy Access to Public Transport', '2023-07-01', '2023-07-01'),
--     ('Villa Country Charm', 2100, 5, 'A charming country villa with rustic decor.', 290.00, 'http://example.com/villa8.jpg', 'Countryside, Horse Riding', '2023-08-01', '2023-08-01'),
--     ('Villa Beach Haven', 1700, 4, 'A cozy beachfront villa.', 360.00, 'http://example.com/villa9.jpg', 'Beach Access, Surfing Lessons', '2023-09-01', '2023-09-01'),
--     ('Villa Forest Hideaway', 1900, 4, 'Hidden in the forest for maximum privacy.', 310.00, 'http://example.com/villa10.jpg', 'Forest Surrounding, Bird Watching', '2023-10-01', '2023-10-01');