CREATE TABLE [dbo].[tblUsers]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [UserName] NCHAR(12) NULL, 
    [Password] NCHAR(25) NULL, 
    [Email] NCHAR(50) NULL, 
    [FirstName] NCHAR(16) NULL, 
    [LastName] NCHAR(25) NULL, 
    [UserSecurity] INT NULL
)
