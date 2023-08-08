-- Foreign key kısmından önce sütun tanımını değiştiriyoruz
ALTER TABLE [dbo].[Comments]
ALTER COLUMN [ApplicationUserId] NVARCHAR(450) NULL;

-- Daha sonra FOREIGN KEY'ı güncelliyoruz
-- Burada dikkat edilmesi gereken, FOREIGN KEY isminin doğru olması gerektiğidir.
-- Eğer varolan bir FOREIGN KEY kısıtı varsa, onun ismini doğru şekilde kullanmalısınız.
-- Varsayılan olarak "[dbo].[FK_Comments_AspNetUsers_ApplicationUserId]" olarak isim verilmiştiği için o ismi kullanıyoruz.
ALTER TABLE [dbo].[Comments]
DROP CONSTRAINT [FK_Comments_AspNetUsers_ApplicationUserId];

ALTER TABLE [dbo].[Comments]
ADD CONSTRAINT [FK_Comments_AspNetUsers_ApplicationUserId]
FOREIGN KEY ([ApplicationUserId]) REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE CASCADE;
