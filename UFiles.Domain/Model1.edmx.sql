
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 09/09/2011 08:54:47
-- Generated from EDMX file: C:\Users\bwood\Desktop\inb302\UFiles.Domain\Model1.edmx
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

IF OBJECT_ID(N'[dbo].[Files]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Files];
GO
IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Files'
CREATE TABLE [dbo].[Files] (
    [FileId] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [CreatedDateTime] datetime  NOT NULL,
    [Owner_Id] int  NOT NULL,
    [FileData_FileDataId] int  NOT NULL
);
GO

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [DisplayName] nvarchar(max)  NOT NULL,
    [Email] nvarchar(max)  NOT NULL,
    [PasswordHash] nvarchar(max)  NOT NULL,
    [VerificationString] nvarchar(max)  NOT NULL,
    [Verified] bit  NOT NULL
);
GO

-- Creating table 'Groups'
CREATE TABLE [dbo].[Groups] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Restrictions'
CREATE TABLE [dbo].[Restrictions] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [File_FileId] int  NOT NULL
);
GO

-- Creating table 'FileDatas'
CREATE TABLE [dbo].[FileDatas] (
    [FileDataId] int IDENTITY(1,1) NOT NULL,
    [Size] int  NOT NULL,
    [Extension] nvarchar(max)  NOT NULL,
    [Hash] nchar(40)  NOT NULL
);
GO

-- Creating table 'Events'
CREATE TABLE [dbo].[Events] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [EventDateTime] datetime  NOT NULL
);
GO

-- Creating table 'TimeRanges'
CREATE TABLE [dbo].[TimeRanges] (
    [TimeRangeId] int IDENTITY(1,1) NOT NULL,
    [StartDateTime] datetime  NOT NULL,
    [EndDateTime] datetime  NOT NULL
);
GO

-- Creating table 'Locations'
CREATE TABLE [dbo].[Locations] (
    [LocationId] int IDENTITY(1,1) NOT NULL,
    [Place] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'IPAddresses'
CREATE TABLE [dbo].[IPAddresses] (
    [IPAddressId] int IDENTITY(1,1) NOT NULL,
    [IP] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Transmittals'
CREATE TABLE [dbo].[Transmittals] (
    [TransmittalId] int IDENTITY(1,1) NOT NULL,
    [Sender_Id] int  NOT NULL
);
GO

-- Creating table 'Restrictions_GroupRestriction'
CREATE TABLE [dbo].[Restrictions_GroupRestriction] (
    [Id] int  NOT NULL
);
GO

-- Creating table 'Events_FileAccessEvent'
CREATE TABLE [dbo].[Events_FileAccessEvent] (
    [Id] int  NOT NULL,
    [File_FileId] int  NOT NULL,
    [User_Id] int  NOT NULL
);
GO

-- Creating table 'Events_UserEvent'
CREATE TABLE [dbo].[Events_UserEvent] (
    [Id] int  NOT NULL,
    [User_Id] int  NOT NULL
);
GO

-- Creating table 'Restrictions_UserRestriction'
CREATE TABLE [dbo].[Restrictions_UserRestriction] (
    [Id] int  NOT NULL
);
GO

-- Creating table 'Restrictions_TimeRangeRestriction'
CREATE TABLE [dbo].[Restrictions_TimeRangeRestriction] (
    [Id] int  NOT NULL
);
GO

-- Creating table 'Restrictions_LocationRestriction'
CREATE TABLE [dbo].[Restrictions_LocationRestriction] (
    [Id] int  NOT NULL
);
GO

-- Creating table 'Restrictions_IPRestriction'
CREATE TABLE [dbo].[Restrictions_IPRestriction] (
    [Id] int  NOT NULL
);
GO

-- Creating table 'Events_TransmittalEvent'
CREATE TABLE [dbo].[Events_TransmittalEvent] (
    [Id] int  NOT NULL,
    [Transmittal_TransmittalId] int  NOT NULL
);
GO

-- Creating table 'GroupUser'
CREATE TABLE [dbo].[GroupUser] (
    [Groups_Id] int  NOT NULL,
    [Users_Id] int  NOT NULL
);
GO

-- Creating table 'GroupRestrictionGroup'
CREATE TABLE [dbo].[GroupRestrictionGroup] (
    [GroupRestrictions_Id] int  NOT NULL,
    [Groups_Id] int  NOT NULL
);
GO

-- Creating table 'UserUserRestriction'
CREATE TABLE [dbo].[UserUserRestriction] (
    [Users_Id] int  NOT NULL,
    [UserRestrictions_Id] int  NOT NULL
);
GO

-- Creating table 'TimeRangeRestrictionTimeRange'
CREATE TABLE [dbo].[TimeRangeRestrictionTimeRange] (
    [TimeRangeRestriction_Id] int  NOT NULL,
    [TimeRanges_TimeRangeId] int  NOT NULL
);
GO

-- Creating table 'LocationRestrictionLocation'
CREATE TABLE [dbo].[LocationRestrictionLocation] (
    [LocationRestriction_Id] int  NOT NULL,
    [Locations_LocationId] int  NOT NULL
);
GO

-- Creating table 'IPRestrictionIPAddress'
CREATE TABLE [dbo].[IPRestrictionIPAddress] (
    [IPRestriction_Id] int  NOT NULL,
    [IPAddresses_IPAddressId] int  NOT NULL
);
GO

-- Creating table 'UserTransmittal'
CREATE TABLE [dbo].[UserTransmittal] (
    [Recipients_Id] int  NOT NULL,
    [ReceivedTransmittals_TransmittalId] int  NOT NULL
);
GO

-- Creating table 'FileTransmittal'
CREATE TABLE [dbo].[FileTransmittal] (
    [Files_FileId] int  NOT NULL,
    [Transmittals_TransmittalId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [FileId] in table 'Files'
ALTER TABLE [dbo].[Files]
ADD CONSTRAINT [PK_Files]
    PRIMARY KEY CLUSTERED ([FileId] ASC);
GO

-- Creating primary key on [Id] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Groups'
ALTER TABLE [dbo].[Groups]
ADD CONSTRAINT [PK_Groups]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Restrictions'
ALTER TABLE [dbo].[Restrictions]
ADD CONSTRAINT [PK_Restrictions]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [FileDataId] in table 'FileDatas'
ALTER TABLE [dbo].[FileDatas]
ADD CONSTRAINT [PK_FileDatas]
    PRIMARY KEY CLUSTERED ([FileDataId] ASC);
GO

-- Creating primary key on [Id] in table 'Events'
ALTER TABLE [dbo].[Events]
ADD CONSTRAINT [PK_Events]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [TimeRangeId] in table 'TimeRanges'
ALTER TABLE [dbo].[TimeRanges]
ADD CONSTRAINT [PK_TimeRanges]
    PRIMARY KEY CLUSTERED ([TimeRangeId] ASC);
GO

-- Creating primary key on [LocationId] in table 'Locations'
ALTER TABLE [dbo].[Locations]
ADD CONSTRAINT [PK_Locations]
    PRIMARY KEY CLUSTERED ([LocationId] ASC);
GO

-- Creating primary key on [IPAddressId] in table 'IPAddresses'
ALTER TABLE [dbo].[IPAddresses]
ADD CONSTRAINT [PK_IPAddresses]
    PRIMARY KEY CLUSTERED ([IPAddressId] ASC);
GO

-- Creating primary key on [TransmittalId] in table 'Transmittals'
ALTER TABLE [dbo].[Transmittals]
ADD CONSTRAINT [PK_Transmittals]
    PRIMARY KEY CLUSTERED ([TransmittalId] ASC);
GO

-- Creating primary key on [Id] in table 'Restrictions_GroupRestriction'
ALTER TABLE [dbo].[Restrictions_GroupRestriction]
ADD CONSTRAINT [PK_Restrictions_GroupRestriction]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Events_FileAccessEvent'
ALTER TABLE [dbo].[Events_FileAccessEvent]
ADD CONSTRAINT [PK_Events_FileAccessEvent]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Events_UserEvent'
ALTER TABLE [dbo].[Events_UserEvent]
ADD CONSTRAINT [PK_Events_UserEvent]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Restrictions_UserRestriction'
ALTER TABLE [dbo].[Restrictions_UserRestriction]
ADD CONSTRAINT [PK_Restrictions_UserRestriction]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Restrictions_TimeRangeRestriction'
ALTER TABLE [dbo].[Restrictions_TimeRangeRestriction]
ADD CONSTRAINT [PK_Restrictions_TimeRangeRestriction]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Restrictions_LocationRestriction'
ALTER TABLE [dbo].[Restrictions_LocationRestriction]
ADD CONSTRAINT [PK_Restrictions_LocationRestriction]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Restrictions_IPRestriction'
ALTER TABLE [dbo].[Restrictions_IPRestriction]
ADD CONSTRAINT [PK_Restrictions_IPRestriction]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Events_TransmittalEvent'
ALTER TABLE [dbo].[Events_TransmittalEvent]
ADD CONSTRAINT [PK_Events_TransmittalEvent]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Groups_Id], [Users_Id] in table 'GroupUser'
ALTER TABLE [dbo].[GroupUser]
ADD CONSTRAINT [PK_GroupUser]
    PRIMARY KEY NONCLUSTERED ([Groups_Id], [Users_Id] ASC);
GO

-- Creating primary key on [GroupRestrictions_Id], [Groups_Id] in table 'GroupRestrictionGroup'
ALTER TABLE [dbo].[GroupRestrictionGroup]
ADD CONSTRAINT [PK_GroupRestrictionGroup]
    PRIMARY KEY NONCLUSTERED ([GroupRestrictions_Id], [Groups_Id] ASC);
GO

-- Creating primary key on [Users_Id], [UserRestrictions_Id] in table 'UserUserRestriction'
ALTER TABLE [dbo].[UserUserRestriction]
ADD CONSTRAINT [PK_UserUserRestriction]
    PRIMARY KEY NONCLUSTERED ([Users_Id], [UserRestrictions_Id] ASC);
GO

-- Creating primary key on [TimeRangeRestriction_Id], [TimeRanges_TimeRangeId] in table 'TimeRangeRestrictionTimeRange'
ALTER TABLE [dbo].[TimeRangeRestrictionTimeRange]
ADD CONSTRAINT [PK_TimeRangeRestrictionTimeRange]
    PRIMARY KEY NONCLUSTERED ([TimeRangeRestriction_Id], [TimeRanges_TimeRangeId] ASC);
GO

-- Creating primary key on [LocationRestriction_Id], [Locations_LocationId] in table 'LocationRestrictionLocation'
ALTER TABLE [dbo].[LocationRestrictionLocation]
ADD CONSTRAINT [PK_LocationRestrictionLocation]
    PRIMARY KEY NONCLUSTERED ([LocationRestriction_Id], [Locations_LocationId] ASC);
GO

-- Creating primary key on [IPRestriction_Id], [IPAddresses_IPAddressId] in table 'IPRestrictionIPAddress'
ALTER TABLE [dbo].[IPRestrictionIPAddress]
ADD CONSTRAINT [PK_IPRestrictionIPAddress]
    PRIMARY KEY NONCLUSTERED ([IPRestriction_Id], [IPAddresses_IPAddressId] ASC);
GO

-- Creating primary key on [Recipients_Id], [ReceivedTransmittals_TransmittalId] in table 'UserTransmittal'
ALTER TABLE [dbo].[UserTransmittal]
ADD CONSTRAINT [PK_UserTransmittal]
    PRIMARY KEY NONCLUSTERED ([Recipients_Id], [ReceivedTransmittals_TransmittalId] ASC);
GO

-- Creating primary key on [Files_FileId], [Transmittals_TransmittalId] in table 'FileTransmittal'
ALTER TABLE [dbo].[FileTransmittal]
ADD CONSTRAINT [PK_FileTransmittal]
    PRIMARY KEY NONCLUSTERED ([Files_FileId], [Transmittals_TransmittalId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Groups_Id] in table 'GroupUser'
ALTER TABLE [dbo].[GroupUser]
ADD CONSTRAINT [FK_GroupUser_Group]
    FOREIGN KEY ([Groups_Id])
    REFERENCES [dbo].[Groups]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Users_Id] in table 'GroupUser'
ALTER TABLE [dbo].[GroupUser]
ADD CONSTRAINT [FK_GroupUser_User]
    FOREIGN KEY ([Users_Id])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_GroupUser_User'
CREATE INDEX [IX_FK_GroupUser_User]
ON [dbo].[GroupUser]
    ([Users_Id]);
GO

-- Creating foreign key on [Owner_Id] in table 'Files'
ALTER TABLE [dbo].[Files]
ADD CONSTRAINT [FK_UserFile]
    FOREIGN KEY ([Owner_Id])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UserFile'
CREATE INDEX [IX_FK_UserFile]
ON [dbo].[Files]
    ([Owner_Id]);
GO

-- Creating foreign key on [File_FileId] in table 'Restrictions'
ALTER TABLE [dbo].[Restrictions]
ADD CONSTRAINT [FK_FileRestriction]
    FOREIGN KEY ([File_FileId])
    REFERENCES [dbo].[Files]
        ([FileId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_FileRestriction'
CREATE INDEX [IX_FK_FileRestriction]
ON [dbo].[Restrictions]
    ([File_FileId]);
GO

-- Creating foreign key on [FileData_FileDataId] in table 'Files'
ALTER TABLE [dbo].[Files]
ADD CONSTRAINT [FK_FileDataFile]
    FOREIGN KEY ([FileData_FileDataId])
    REFERENCES [dbo].[FileDatas]
        ([FileDataId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_FileDataFile'
CREATE INDEX [IX_FK_FileDataFile]
ON [dbo].[Files]
    ([FileData_FileDataId]);
GO

-- Creating foreign key on [GroupRestrictions_Id] in table 'GroupRestrictionGroup'
ALTER TABLE [dbo].[GroupRestrictionGroup]
ADD CONSTRAINT [FK_GroupRestrictionGroup_GroupRestriction]
    FOREIGN KEY ([GroupRestrictions_Id])
    REFERENCES [dbo].[Restrictions_GroupRestriction]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Groups_Id] in table 'GroupRestrictionGroup'
ALTER TABLE [dbo].[GroupRestrictionGroup]
ADD CONSTRAINT [FK_GroupRestrictionGroup_Group]
    FOREIGN KEY ([Groups_Id])
    REFERENCES [dbo].[Groups]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_GroupRestrictionGroup_Group'
CREATE INDEX [IX_FK_GroupRestrictionGroup_Group]
ON [dbo].[GroupRestrictionGroup]
    ([Groups_Id]);
GO

-- Creating foreign key on [File_FileId] in table 'Events_FileAccessEvent'
ALTER TABLE [dbo].[Events_FileAccessEvent]
ADD CONSTRAINT [FK_FileFileAccessEvent]
    FOREIGN KEY ([File_FileId])
    REFERENCES [dbo].[Files]
        ([FileId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_FileFileAccessEvent'
CREATE INDEX [IX_FK_FileFileAccessEvent]
ON [dbo].[Events_FileAccessEvent]
    ([File_FileId]);
GO

-- Creating foreign key on [User_Id] in table 'Events_FileAccessEvent'
ALTER TABLE [dbo].[Events_FileAccessEvent]
ADD CONSTRAINT [FK_UserFileAccessEvent]
    FOREIGN KEY ([User_Id])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UserFileAccessEvent'
CREATE INDEX [IX_FK_UserFileAccessEvent]
ON [dbo].[Events_FileAccessEvent]
    ([User_Id]);
GO

-- Creating foreign key on [User_Id] in table 'Events_UserEvent'
ALTER TABLE [dbo].[Events_UserEvent]
ADD CONSTRAINT [FK_UserUserEvent]
    FOREIGN KEY ([User_Id])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UserUserEvent'
CREATE INDEX [IX_FK_UserUserEvent]
ON [dbo].[Events_UserEvent]
    ([User_Id]);
GO

-- Creating foreign key on [Users_Id] in table 'UserUserRestriction'
ALTER TABLE [dbo].[UserUserRestriction]
ADD CONSTRAINT [FK_UserUserRestriction_User]
    FOREIGN KEY ([Users_Id])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [UserRestrictions_Id] in table 'UserUserRestriction'
ALTER TABLE [dbo].[UserUserRestriction]
ADD CONSTRAINT [FK_UserUserRestriction_UserRestriction]
    FOREIGN KEY ([UserRestrictions_Id])
    REFERENCES [dbo].[Restrictions_UserRestriction]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UserUserRestriction_UserRestriction'
CREATE INDEX [IX_FK_UserUserRestriction_UserRestriction]
ON [dbo].[UserUserRestriction]
    ([UserRestrictions_Id]);
GO

-- Creating foreign key on [TimeRangeRestriction_Id] in table 'TimeRangeRestrictionTimeRange'
ALTER TABLE [dbo].[TimeRangeRestrictionTimeRange]
ADD CONSTRAINT [FK_TimeRangeRestrictionTimeRange_TimeRangeRestriction]
    FOREIGN KEY ([TimeRangeRestriction_Id])
    REFERENCES [dbo].[Restrictions_TimeRangeRestriction]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [TimeRanges_TimeRangeId] in table 'TimeRangeRestrictionTimeRange'
ALTER TABLE [dbo].[TimeRangeRestrictionTimeRange]
ADD CONSTRAINT [FK_TimeRangeRestrictionTimeRange_TimeRange]
    FOREIGN KEY ([TimeRanges_TimeRangeId])
    REFERENCES [dbo].[TimeRanges]
        ([TimeRangeId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_TimeRangeRestrictionTimeRange_TimeRange'
CREATE INDEX [IX_FK_TimeRangeRestrictionTimeRange_TimeRange]
ON [dbo].[TimeRangeRestrictionTimeRange]
    ([TimeRanges_TimeRangeId]);
GO

-- Creating foreign key on [LocationRestriction_Id] in table 'LocationRestrictionLocation'
ALTER TABLE [dbo].[LocationRestrictionLocation]
ADD CONSTRAINT [FK_LocationRestrictionLocation_LocationRestriction]
    FOREIGN KEY ([LocationRestriction_Id])
    REFERENCES [dbo].[Restrictions_LocationRestriction]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Locations_LocationId] in table 'LocationRestrictionLocation'
ALTER TABLE [dbo].[LocationRestrictionLocation]
ADD CONSTRAINT [FK_LocationRestrictionLocation_Location]
    FOREIGN KEY ([Locations_LocationId])
    REFERENCES [dbo].[Locations]
        ([LocationId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_LocationRestrictionLocation_Location'
CREATE INDEX [IX_FK_LocationRestrictionLocation_Location]
ON [dbo].[LocationRestrictionLocation]
    ([Locations_LocationId]);
GO

-- Creating foreign key on [IPRestriction_Id] in table 'IPRestrictionIPAddress'
ALTER TABLE [dbo].[IPRestrictionIPAddress]
ADD CONSTRAINT [FK_IPRestrictionIPAddress_IPRestriction]
    FOREIGN KEY ([IPRestriction_Id])
    REFERENCES [dbo].[Restrictions_IPRestriction]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [IPAddresses_IPAddressId] in table 'IPRestrictionIPAddress'
ALTER TABLE [dbo].[IPRestrictionIPAddress]
ADD CONSTRAINT [FK_IPRestrictionIPAddress_IPAddress]
    FOREIGN KEY ([IPAddresses_IPAddressId])
    REFERENCES [dbo].[IPAddresses]
        ([IPAddressId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_IPRestrictionIPAddress_IPAddress'
CREATE INDEX [IX_FK_IPRestrictionIPAddress_IPAddress]
ON [dbo].[IPRestrictionIPAddress]
    ([IPAddresses_IPAddressId]);
GO

-- Creating foreign key on [Recipients_Id] in table 'UserTransmittal'
ALTER TABLE [dbo].[UserTransmittal]
ADD CONSTRAINT [FK_UserTransmittal_User]
    FOREIGN KEY ([Recipients_Id])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [ReceivedTransmittals_TransmittalId] in table 'UserTransmittal'
ALTER TABLE [dbo].[UserTransmittal]
ADD CONSTRAINT [FK_UserTransmittal_Transmittal]
    FOREIGN KEY ([ReceivedTransmittals_TransmittalId])
    REFERENCES [dbo].[Transmittals]
        ([TransmittalId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UserTransmittal_Transmittal'
CREATE INDEX [IX_FK_UserTransmittal_Transmittal]
ON [dbo].[UserTransmittal]
    ([ReceivedTransmittals_TransmittalId]);
GO

-- Creating foreign key on [Sender_Id] in table 'Transmittals'
ALTER TABLE [dbo].[Transmittals]
ADD CONSTRAINT [FK_UserTransmittal1]
    FOREIGN KEY ([Sender_Id])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UserTransmittal1'
CREATE INDEX [IX_FK_UserTransmittal1]
ON [dbo].[Transmittals]
    ([Sender_Id]);
GO

-- Creating foreign key on [Files_FileId] in table 'FileTransmittal'
ALTER TABLE [dbo].[FileTransmittal]
ADD CONSTRAINT [FK_FileTransmittal_File]
    FOREIGN KEY ([Files_FileId])
    REFERENCES [dbo].[Files]
        ([FileId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Transmittals_TransmittalId] in table 'FileTransmittal'
ALTER TABLE [dbo].[FileTransmittal]
ADD CONSTRAINT [FK_FileTransmittal_Transmittal]
    FOREIGN KEY ([Transmittals_TransmittalId])
    REFERENCES [dbo].[Transmittals]
        ([TransmittalId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_FileTransmittal_Transmittal'
CREATE INDEX [IX_FK_FileTransmittal_Transmittal]
ON [dbo].[FileTransmittal]
    ([Transmittals_TransmittalId]);
GO

-- Creating foreign key on [Transmittal_TransmittalId] in table 'Events_TransmittalEvent'
ALTER TABLE [dbo].[Events_TransmittalEvent]
ADD CONSTRAINT [FK_TransmittalTransmittalEvent]
    FOREIGN KEY ([Transmittal_TransmittalId])
    REFERENCES [dbo].[Transmittals]
        ([TransmittalId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_TransmittalTransmittalEvent'
CREATE INDEX [IX_FK_TransmittalTransmittalEvent]
ON [dbo].[Events_TransmittalEvent]
    ([Transmittal_TransmittalId]);
GO

-- Creating foreign key on [Id] in table 'Restrictions_GroupRestriction'
ALTER TABLE [dbo].[Restrictions_GroupRestriction]
ADD CONSTRAINT [FK_GroupRestriction_inherits_Restriction]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Restrictions]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'Events_FileAccessEvent'
ALTER TABLE [dbo].[Events_FileAccessEvent]
ADD CONSTRAINT [FK_FileAccessEvent_inherits_Event]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Events]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'Events_UserEvent'
ALTER TABLE [dbo].[Events_UserEvent]
ADD CONSTRAINT [FK_UserEvent_inherits_Event]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Events]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'Restrictions_UserRestriction'
ALTER TABLE [dbo].[Restrictions_UserRestriction]
ADD CONSTRAINT [FK_UserRestriction_inherits_Restriction]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Restrictions]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'Restrictions_TimeRangeRestriction'
ALTER TABLE [dbo].[Restrictions_TimeRangeRestriction]
ADD CONSTRAINT [FK_TimeRangeRestriction_inherits_Restriction]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Restrictions]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'Restrictions_LocationRestriction'
ALTER TABLE [dbo].[Restrictions_LocationRestriction]
ADD CONSTRAINT [FK_LocationRestriction_inherits_Restriction]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Restrictions]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'Restrictions_IPRestriction'
ALTER TABLE [dbo].[Restrictions_IPRestriction]
ADD CONSTRAINT [FK_IPRestriction_inherits_Restriction]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Restrictions]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'Events_TransmittalEvent'
ALTER TABLE [dbo].[Events_TransmittalEvent]
ADD CONSTRAINT [FK_TransmittalEvent_inherits_Event]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Events]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------