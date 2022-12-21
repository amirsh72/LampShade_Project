IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Comments] (
    [Id] bigint NOT NULL IDENTITY,
    [Name] nvarchar(500) NULL,
    [Email] nvarchar(500) NULL,
    [Website] nvarchar(500) NULL,
    [Message] nvarchar(500) NULL,
    [IsConfirmed] bit NOT NULL,
    [IsCanceled] bit NOT NULL,
    [OwnerRecordId] bigint NOT NULL,
    [Type] int NOT NULL,
    [ParentId] bigint NOT NULL,
    [CreationDate] datetime2 NOT NULL,
    CONSTRAINT [PK_Comments] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Comments_Comments_ParentId] FOREIGN KEY ([ParentId]) REFERENCES [Comments] ([Id])
);
GO

CREATE INDEX [IX_Comments_ParentId] ON [Comments] ([ParentId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20221026071153_add-comment', N'5.0.0');
GO

COMMIT;
GO

