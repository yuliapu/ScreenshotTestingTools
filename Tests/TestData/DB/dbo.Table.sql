CREATE TABLE [dbo].[TestsResults]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [FeatureName] NVARCHAR(50) NOT NULL, 
    [ScenarioName] NVARCHAR(50) NOT NULL, 
    [Result] NVARCHAR(50) NOT NULL, 
    [ErrorMessage] NVARCHAR(50) NULL, 
    [StartTime] DATETIME NOT NULL, 
    [EndTime] DATETIME NOT NULL
)
