CREATE TABLE [dbo].[Weather]
(
	[WeatherId] INT NOT NULL PRIMARY KEY, 
	[CityId] INT NOT NULL,
    [LocalObservationDateTime] DATETIME NOT NULL, 
    [WeatherText] NVARCHAR(50) NULL, 
    [WeatherIcon] NUMERIC NULL, 
    [IsDayTime] BIT NULL, 
    [Temperature] DECIMAL NULL,
   	CONSTRAINT FK_City_CityId FOREIGN KEY (CityId) REFERENCES dbo.City(CityId)
)
