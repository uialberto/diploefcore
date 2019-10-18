﻿IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Categories] (
    [CategoryID] int NOT NULL IDENTITY,
    [CategoryName] nvarchar(max) NULL,
    CONSTRAINT [PK_Categories] PRIMARY KEY ([CategoryID])
);

GO

CREATE TABLE [Products] (
    [ProductID] int NOT NULL IDENTITY,
    [ProductName] nvarchar(max) NULL,
    [UnitPrice] decimal(18,2) NOT NULL,
    [UnitsInStock] int NOT NULL,
    [CategoryID] int NOT NULL,
    CONSTRAINT [PK_Products] PRIMARY KEY ([ProductID]),
    CONSTRAINT [FK_Products_Categories_CategoryID] FOREIGN KEY ([CategoryID]) REFERENCES [Categories] ([CategoryID]) ON DELETE CASCADE
);

GO

CREATE INDEX [IX_Products_CategoryID] ON [Products] ([CategoryID]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20191018005017_InitialCreate', N'2.2.4-servicing-10062');

GO

CREATE TABLE [Employees] (
    [EmployeeID] int NOT NULL IDENTITY,
    [FirstName] nvarchar(max) NULL,
    [LastName] nvarchar(max) NULL,
    CONSTRAINT [PK_Employees] PRIMARY KEY ([EmployeeID])
);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20191018005827_Feact-Employee', N'2.2.4-servicing-10062');

GO

ALTER TABLE [Employees] ADD [Name] nvarchar(max) NULL;

GO

update Employees set Name= FirstName + ' ' + LastName

GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Employees]') AND [c].[name] = N'FirstName');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Employees] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [Employees] DROP COLUMN [FirstName];

GO

DECLARE @var1 sysname;
SELECT @var1 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Employees]') AND [c].[name] = N'LastName');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Employees] DROP CONSTRAINT [' + @var1 + '];');
ALTER TABLE [Employees] DROP COLUMN [LastName];

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20191018010234_Colum-Employee-Update', N'2.2.4-servicing-10062');

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20191018011330_EmtyMigration', N'2.2.4-servicing-10062');

GO

