CREATE TABLE [dbo].[Country]
(
	[CountryId] INT NOT NULL PRIMARY KEY, 
    [CountryName] VARCHAR(50) NOT NULL, 
    [RegionCode] VARCHAR(5) NOT NULL,
	CONSTRAINT UNQ_COUNTRYNAME UNIQUE(CountryName)
	
)
