CREATE TABLE Cars(
	Id int PRIMARY KEY IDENTITY(1,1),
	BrandId int,
	ColorId int,
	ModelYear nvarchar(25),
	DailyPrice decimal,
	Descriptions nvarchar(25),
	FOREIGN KEY (ColorID) REFERENCES Colors(ColorID),
	FOREIGN KEY (BrandID) REFERENCES Brands(BrandID)
)

CREATE TABLE Colors(
	Id int PRIMARY KEY IDENTITY(1,1),
	ColorName nvarchar(25),
)

CREATE TABLE Brands(
	Id int PRIMARY KEY IDENTITY(1,1),
	BrandName nvarchar(25),
)


INSERT INTO Cars(BrandID,ColorID,ModelYear,DailyPrice,Descriptions)
VALUES
	('1','1','2018','200','Manuel Benzin'),
	('3','5','2020','350','Otomatik Dizel'),
	('5','2','2019','200','Otomatik Hybrid'),
	('5','6','2020','250','Manuel Dizel');

INSERT INTO Colors(ColorName)
VALUES
	('Siyah'),
	('Beyaz'),
	('Kırmızı'),
	('Mavi'),
	('Yeşil'),
	('Sarı');


INSERT INTO Brands(BrandName)
VALUES
	('Mercedes'),
	('Audi'),
	('BMW'),
	('Jaguar'),
	('Tesla');