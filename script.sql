IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210111170251_InitialCreate')
BEGIN
    CREATE TABLE [Categories] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NULL,
        [Description] nvarchar(max) NULL,
        CONSTRAINT [PK_Categories] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210111170251_InitialCreate')
BEGIN
    CREATE TABLE [Products] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NULL,
        [Description] nvarchar(max) NULL,
        [ItemId] int NOT NULL,
        [Item_Price] Money NULL,
        [Item_QuantityInStock] int NULL,
        CONSTRAINT [PK_Products] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210111170251_InitialCreate')
BEGIN
    CREATE TABLE [CategoriesToProducts] (
        [CategoryId] int NOT NULL,
        [ProductId] int NOT NULL,
        CONSTRAINT [PK_CategoriesToProducts] PRIMARY KEY ([ProductId], [CategoryId]),
        CONSTRAINT [FK_CategoriesToProducts_Categories_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [Categories] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_CategoriesToProducts_Products_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [Products] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210111170251_InitialCreate')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Description', N'Name') AND [object_id] = OBJECT_ID(N'[Categories]'))
        SET IDENTITY_INSERT [Categories] ON;
    INSERT INTO [Categories] ([Id], [Description], [Name])
    VALUES (1, N'Used to compute a speed based on time.', N'Tachymeter'),
    (2, N'A stopwatch combined with a display watch.', N'Chronograph'),
    (3, N'A small second hand', N'Small Seconds'),
    (4, N'Manual winding of the timepiece', N'Manual Winding'),
    (5, N'Automatic winding of the timepiece', N'Automatic Winding');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Description', N'Name') AND [object_id] = OBJECT_ID(N'[Categories]'))
        SET IDENTITY_INSERT [Categories] OFF;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210111170251_InitialCreate')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Description', N'ItemId', N'Name', N'Item_Price', N'Item_QuantityInStock') AND [object_id] = OBJECT_ID(N'[Products]'))
        SET IDENTITY_INSERT [Products] ON;
    INSERT INTO [Products] ([Id], [Description], [ItemId], [Name], [Item_Price], [Item_QuantityInStock])
    VALUES (1, N'Dark Side of the Moon', 1, N'Omega Speedmaster', 8895.0, 5),
    (2, N'Carrera Calibre 16', 2, N'TAG Heuer', 3360.0, 8),
    (3, N'Unico Titanium 42mm', 3, N'Hublot Big Bang', 17800.0, 1),
    (4, N'BR V2-94 Garde-Cotes', 4, N'Bell & Ross', 4300.0, 3);
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Description', N'ItemId', N'Name', N'Item_Price', N'Item_QuantityInStock') AND [object_id] = OBJECT_ID(N'[Products]'))
        SET IDENTITY_INSERT [Products] OFF;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210111170251_InitialCreate')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ProductId', N'CategoryId') AND [object_id] = OBJECT_ID(N'[CategoriesToProducts]'))
        SET IDENTITY_INSERT [CategoriesToProducts] ON;
    INSERT INTO [CategoriesToProducts] ([ProductId], [CategoryId])
    VALUES (1, 1),
    (1, 2),
    (1, 3),
    (1, 4),
    (2, 1),
    (2, 2),
    (2, 3),
    (2, 5),
    (3, 2),
    (3, 5),
    (4, 2),
    (4, 5);
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ProductId', N'CategoryId') AND [object_id] = OBJECT_ID(N'[CategoriesToProducts]'))
        SET IDENTITY_INSERT [CategoriesToProducts] OFF;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210111170251_InitialCreate')
BEGIN
    CREATE INDEX [IX_CategoriesToProducts_CategoryId] ON [CategoriesToProducts] ([CategoryId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210111170251_InitialCreate')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210111170251_InitialCreate', N'3.0.0');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210111170731_CategorySeedData')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210111170731_CategorySeedData', N'3.0.0');
END;

GO

