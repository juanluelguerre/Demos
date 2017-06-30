CREATE TABLE [dbo].[Usuarios]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [UserName] NVARCHAR(50) NOT NULL, 
    [Nombre] NVARCHAR(100) NOT NULL, 
    [Apellidos] NVARCHAR(100) NOT NULL
)
