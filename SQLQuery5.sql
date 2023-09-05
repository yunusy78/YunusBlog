CREATE TRIGGER trg_UpdateCityCountWithCountry
ON Products
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;

    -- Yeni eklenen şehirleri ve country bilgisini al
    INSERT INTO Addresses (City, Country, CreatedAt, Status, CityCount)
    SELECT DISTINCT
        i.City,
        p.Country,     -- Product tablosundan gelen ülke bilgisi
        GETDATE(),     -- Oluşturulma tarihi
        1,       -- Varsayılan durum (örneğin, Active)
        0
    FROM inserted i
    INNER JOIN Products p ON i.City = p.City
    WHERE i.City NOT IN (SELECT City FROM Addresses);
    
    -- Şehir sayacını 1 artır
    UPDATE Addresses
    SET CityCount = CityCount + 1
    WHERE City IN (SELECT City FROM inserted);
END;

DROP TRIGGER [trg_UpdateCityCountWithCountry];
