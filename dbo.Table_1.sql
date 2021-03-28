CREATE TABLE Product
(
	[ProductNumber] SMALLINT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[ProductName] NVARCHAR(30) NOT NULL,
	[ProductImage] IMAGE,
	[ProductPrice] INT NOT NULL,
	[ProductComment] NVARCHAR(200),
	[CategoryNumber] TINYINT NOT NULL
)
