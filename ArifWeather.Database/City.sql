CREATE TABLE [dbo].[City]
(
	[CityId] INT NOT NULL PRIMARY KEY, 
    [CountryId] INT NOT NULL, 
    [CityName] NCHAR(10) NULL,
    [LocationCode] VARCHAR(10) NOT NULL,
	CONSTRAINT FK_Country_CountryId FOREIGN KEY (CountryId) REFERENCES dbo.Country(CountryId),
	CONSTRAINT UNQ_LocationCode UNIQUE (LocationCode)
)
