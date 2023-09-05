

    -- Legg til 7 eksempler på ansattregistreringer
INSERT INTO [dbo].[Employee] ([EmployeeName], [EmployeeTitle], [EmployeeEmail], [EmployeePhoneNumber], [EmployeeStatus], [EmployeeImageUrl])
VALUES
    ('Einar Hansen', 'Salgsrepresentant', 'einar.hansen@example.com', '+47 123 456 789', 1, '/bilder/ansatt1.jpg'),
    ('Ingrid Olsen', 'Eiendomskonsulent', 'ingrid.olsen@example.com', '+47 987 654 321', 1, '/bilder/ansatt2.jpg'),
    ('Andreas Pedersen', 'Investeringskonsulent', 'andreas.pedersen@example.com', '+47 567 890 123', 1, '/bilder/ansatt3.jpg'),
    ('Mia Larsen', 'Kundebehandler', 'mia.larsen@example.com', '+47 234 567 890', 1, '/bilder/ansatt4.jpg'),
    ('Oscar Kristensen', 'Markedsføringssjef', 'oscar.kristensen@example.com', '+47 345 678 901', 1, '/bilder/ansatt5.jpg'),
    ('Hannah Berg', 'Teknisk støtteekspert', 'hannah.berg@example.com', '+47 456 789 012', 1, '/bilder/ansatt6.jpg'),
    ('Liam Nilsen', 'Finansanalytiker', 'liam.nilsen@example.com', '+47 678 901 234', 1, '/bilder/ansatt7.jpg');


    -- Legg til 10 eksempler på produktregistreringer med tilfeldig tildelte EmployeeId-er
INSERT INTO [dbo].[Products] ([Title], [Description], [ImageUrl], [Price], [Type], [Street], [City], [PostalCode], [Country], [CoverImageUrl], [CreatedAt], [Status], [EmployeeId], [CategoryId])
VALUES
    ('Flott hybel i sentrum', 'Moderne hybel i hjertet av byen.', '/bilder/hybel1.jpg', 1200.00, 'Hybel', 'Karl Johans gate 15', 'Oslo', '0123', 'Norge', '/bilder/hybel1-cover.jpg', GETDATE(), 1, '236e6c78-d0e4-422f-82c9-076a26cba7b5', '1c8e4489-2fa5-40a5-960f-01c5b48da22f'),
    ('Fritidsbolig ved sjøen', 'Koselig fritidsbolig med sjøutsikt.', '/bilder/fritidsbolig1.jpg', 2500.00, 'Fritidsbolig', 'Strandveien 123', 'Bergen', '4001', 'Norge', '/bilder/fritidsbolig1-cover.jpg', GETDATE(), 1, '89ca850d-4bf1-49ee-98a4-2f45c577f97b', '8a6696e5-2989-40df-b06d-34d14402f2a8'),
    ('Skogeiendom med jaktrettigheter', 'Eksklusiv skogeiendom med egen jakt.', '/bilder/skogeiendom1.jpg', 4500.00, 'Skogeiendom', 'Skogveien 56', 'Trondheim', '7010', 'Norge', '/bilder/skogeiendom1-cover.jpg', GETDATE(), 1, '65321206-d914-419b-a795-58cfd54612f5', 'b8d2953e-a62f-4c4e-9602-3f8388b72a23'),
    ('Moderne leilighet i Nydalen', 'Lys og romslig leilighet med parkering.', '/bilder/leilighet1.jpg', 3500.00, 'Leilighet', 'Nydalsveien 78B', 'Oslo', '0483', 'Norge', '/bilder/leilighet1-cover.jpg', GETDATE(), 1, 'b08153e5-9b77-473d-8d5f-58ede98465a5', 'efdebeb8-fb4a-46c4-bb06-5eb250e59e35'),
    ('Enebolig med sjøutsikt', 'Flott enebolig med utsikt over fjorden.', '/bilder/enebolig1.jpg', 5800.00, 'Enebolig', 'Sjøveien 10', 'Stavanger', '4006', 'Norge', '/bilder/enebolig1-cover.jpg', GETDATE(), 1, '0bdd904e-89da-4467-948f-8f2e8bdec655', '9b750dd7-5eb8-4d6d-95f0-731b0ebe535b'),
    ('Næringslokale i sentrum', 'Sentral beliggenhet for din bedrift.', '/bilder/naringslokale1.jpg', 3000.00, 'Næringslokale', 'Karl Johans gate 33', 'Oslo', '0123', 'Norge', '/bilder/naringslokale1-cover.jpg', GETDATE(), 1, '27334904-5112-4307-be02-c018ead60fe2', '38be17cc-5d94-40b9-a571-ac3a22ce7677'),
    ('Moderne kontorlokale', 'Fleksible kontorlokaler for din bedrift.', '/bilder/kontorlokale1.jpg', 4000.00, 'Kontorlokale', 'Fridtjof Nansens plass 5', 'Bergen', '4001', 'Norge', '/bilder/kontorlokale1-cover.jpg', GETDATE(), 1, '08f8c6c8-4100-403f-8a66-e0842b2ae5a3', '246cc0df-0221-49f5-aaa6-d2d54d0c17bf');

    -- Legg til produktinformasjon i ProductDetails-tabellen
INSERT INTO [dbo].[ProductDetails] ([ProductId], [Size], [BadromCount], [BathCount], [RomCount], [GarageSize], [BuildYear], [Location], [VideoUrl])
VALUES
    ('2b8b35ec-4be6-4493-8950-11aea5f0bb40', 80, 1, 1, 2, 0, '2005', 'Oslo', 'https://www.example.com/video1'),
    ('c21c12fd-e040-4990-9afa-19096fcd3278', 120, 2, 2, 3, 1, '2010', 'Oslo', 'https://www.example.com/video2'),
    ('7eb8e176-ed34-4b69-944c-2500bc85e8ec', 200, 3, 2, 4, 2, '1998', 'Bergen', 'https://www.example.com/video3'),
    ('ffcc88e1-989e-45d8-833c-28428f99a530', 100, 2, 1, 2, 1, '2015', 'Oslo', 'https://www.example.com/video4'),
    ('fe2d958f-e051-4606-bdc2-4bf5d678ef91', 150, 3, 2, 4, 2, '2012', 'Trondheim', 'https://www.example.com/video5'),
    ('9cd4094e-fce5-4632-b5bf-abce4875e359', 180, 3, 2, 4, 2, '2008', 'Stavanger', 'https://www.example.com/video6'),
    ('323bd61f-40bf-49a3-8025-d56ceaca63af', 90, 1, 1, 3, 0, '2019', 'Bergen', 'https://www.example.com/video7');
