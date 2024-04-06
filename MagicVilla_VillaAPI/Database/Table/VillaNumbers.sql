CREATE TABLE VillaNumbers (
    VillaNo INT PRIMARY KEY;
    SpecialDetails NVARCHAR(MAX) NOT NULL;
    CreatedDate DATETIME;
    UpdatedDate DATETIME NULL;
);


-- INSERT INTO VillaNumbers (VillaNo, SpecialDetails, CreatedDate, UpdatedDate)
-- VALUES
--     (101, 'Private pool, Ocean view', '2023-01-01', '2023-01-02'),
--     (102, 'Mountain view, Hot tub', '2023-02-01', NULL),
--     (103, 'Garden with BBQ, Game room', '2023-03-01', '2023-03-02'),
--     (104, 'Rooftop terrace, Private chef available', '2023-04-01', NULL),
--     (105, 'Infinity pool, Direct beach access', '2023-05-01', '2023-05-02');
