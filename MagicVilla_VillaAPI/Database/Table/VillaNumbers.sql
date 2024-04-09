CREATE TABLE VillaNumbers (
    VillaNo INT PRIMARY KEY,
    VillaId INT,
    SpecialDetails NVARCHAR(MAX) NOT NULL,
    CreatedDate DATETIME,
    UpdatedDate DATETIME NULL
);


INSERT INTO VillaNumbers (VillaNo, VillaId, SpecialDetails, CreatedDate, UpdatedDate)
VALUES
    (101, 1, 'Private pool and garden', '2023-01-01', '2023-01-02'),
    (102, 2, 'Beachfront with sunset view', '2023-02-01', '2023-02-02'),
    (103, 3, 'Mountain view with hiking access', '2023-03-01', '2023-03-02'),
    (104, 4, 'Lakefront with fishing gear', '2023-04-01', '2023-04-02'),
    (105, 5, 'Orchard access and fresh fruits', '2023-05-01', '2023-05-02'),
    (106, 6, 'Desert landscape with star gazing deck', '2023-06-01', '2023-06-02'),
    (107, 7, 'Urban villa with rooftop terrace', '2023-07-01', '2023-07-02');