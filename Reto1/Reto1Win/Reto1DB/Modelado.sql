﻿CREATE TABLE [dbo].[Modelado]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Codigo] NVARCHAR(50) NOT NULL, 
    [Titulo] NVARCHAR(50) NOT NULL, 
    [Query] NVARCHAR(MAX) NOT NULL
)
