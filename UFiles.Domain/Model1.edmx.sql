
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 08/29/2011 21:51:29
-- Generated from EDMX file: C:\Users\Bryan\Desktop\inb302\UFiles.Domain\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Test];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Files'
CREATE TABLE [dbo].[Files] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Size] nvarchar(max)  NOT NULL,
    [Created] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Transmittals'
CREATE TABLE [dbo].[Transmittals] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Sender_Id] int  NOT NULL
);
GO

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [DisplayName] nvarchar(max)  NOT NULL,
    [Email] nvarchar(max)  NOT NULL,
    [PasswordHash] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'FileTransmittal'
CREATE TABLE [dbo].[FileTransmittal] (
    [Files_Id] int  NOT NULL,
    [Transmittals_Id] int  NOT NULL
);
GO

-- Creating table 'TransmittalUser'
CREATE TABLE [dbo].[TransmittalUser] (
    [RecievedTransmittals_Id] int  NOT NULL,
    [Recipients_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Files'
ALTER TABLE [dbo].[Files]
ADD CONSTRAINT [PK_Files]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Transmittals'
ALTER TABLE [dbo].[Transmittals]
ADD CONSTRAINT [PK_Transmittals]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Files_Id], [Transmittals_Id] in table 'FileTransmittal'
ALTER TABLE [dbo].[FileTransmittal]
ADD CONSTRAINT [PK_FileTransmittal]
    PRIMARY KEY NONCLUSTERED ([Files_Id], [Transmittals_Id] ASC);
GO

-- Creating primary key on [RecievedTransmittals_Id], [Recipients_Id] in table 'TransmittalUser'
ALTER TABLE [dbo].[TransmittalUser]
ADD CONSTRAINT [PK_TransmittalUser]
    PRIMARY KEY NONCLUSTERED ([RecievedTransmittals_Id], [Recipients_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Files_Id] in table 'FileTransmittal'
ALTER TABLE [dbo].[FileTransmittal]
ADD CONSTRAINT [FK_FileTransmittal_File]
    FOREIGN KEY ([Files_Id])
    REFERENCES [dbo].[Files]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Transmittals_Id] in table 'FileTransmittal'
ALTER TABLE [dbo].[FileTransmittal]
ADD CONSTRAINT [FK_FileTransmittal_Transmittal]
    FOREIGN KEY ([Transmittals_Id])
    REFERENCES [dbo].[Transmittals]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_FileTransmittal_Transmittal'
CREATE INDEX [IX_FK_FileTransmittal_Transmittal]
ON [dbo].[FileTransmittal]
    ([Transmittals_Id]);
GO

-- Creating foreign key on [Sender_Id] in table 'Transmittals'
ALTER TABLE [dbo].[Transmittals]
ADD CONSTRAINT [FK_UserTransmittal]
    FOREIGN KEY ([Sender_Id])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UserTransmittal'
CREATE INDEX [IX_FK_UserTransmittal]
ON [dbo].[Transmittals]
    ([Sender_Id]);
GO

-- Creating foreign key on [RecievedTransmittals_Id] in table 'TransmittalUser'
ALTER TABLE [dbo].[TransmittalUser]
ADD CONSTRAINT [FK_TransmittalUser_Transmittal]
    FOREIGN KEY ([RecievedTransmittals_Id])
    REFERENCES [dbo].[Transmittals]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Recipients_Id] in table 'TransmittalUser'
ALTER TABLE [dbo].[TransmittalUser]
ADD CONSTRAINT [FK_TransmittalUser_User]
    FOREIGN KEY ([Recipients_Id])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_TransmittalUser_User'
CREATE INDEX [IX_FK_TransmittalUser_User]
ON [dbo].[TransmittalUser]
    ([Recipients_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------