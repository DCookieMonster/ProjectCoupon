
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 04/26/2015 12:56:26
-- Generated from EDMX file: Z:\Dropbox (BGU)\Projects\WebProjects\ProjectCoupon\DataAccess\C_Model.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Z:\DROPBOX (BGU)\PROJECTS\WEBPROJECTS\PROJECTCOUPON\DATAACCESS\APP_DATA\C_DB.MDF];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_SystemAdminFirmOwner]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Users_FirmOwner] DROP CONSTRAINT [FK_SystemAdminFirmOwner];
GO
IF OBJECT_ID(N'[dbo].[FK_CostumerSocialCoupon]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Coupons_SocialCoupon] DROP CONSTRAINT [FK_CostumerSocialCoupon];
GO
IF OBJECT_ID(N'[dbo].[FK_UserCoupon]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Coupons] DROP CONSTRAINT [FK_UserCoupon];
GO
IF OBJECT_ID(N'[dbo].[FK_FirmOwnerFirm]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Firms] DROP CONSTRAINT [FK_FirmOwnerFirm];
GO
IF OBJECT_ID(N'[dbo].[FK_SystemAdminFirm]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Firms] DROP CONSTRAINT [FK_SystemAdminFirm];
GO
IF OBJECT_ID(N'[dbo].[FK_CouponCouponAlert]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CouponAlerts] DROP CONSTRAINT [FK_CouponCouponAlert];
GO
IF OBJECT_ID(N'[dbo].[FK_CouponOrderCoupon]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CouponOrders] DROP CONSTRAINT [FK_CouponOrderCoupon];
GO
IF OBJECT_ID(N'[dbo].[FK_CostumerCouponOrder]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CouponOrders] DROP CONSTRAINT [FK_CostumerCouponOrder];
GO
IF OBJECT_ID(N'[dbo].[FK_CostumerCouponAlert_Costumer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CostumerCouponAlert] DROP CONSTRAINT [FK_CostumerCouponAlert_Costumer];
GO
IF OBJECT_ID(N'[dbo].[FK_CostumerCouponAlert_CouponAlert]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CostumerCouponAlert] DROP CONSTRAINT [FK_CostumerCouponAlert_CouponAlert];
GO
IF OBJECT_ID(N'[dbo].[FK_CostumerSocialNetworkProfile]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SocialNetworkProfiles1] DROP CONSTRAINT [FK_CostumerSocialNetworkProfile];
GO
IF OBJECT_ID(N'[dbo].[FK_CostumerCategories_Costumer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CostumerCategories] DROP CONSTRAINT [FK_CostumerCategories_Costumer];
GO
IF OBJECT_ID(N'[dbo].[FK_CostumerCategories_Categories]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CostumerCategories] DROP CONSTRAINT [FK_CostumerCategories_Categories];
GO
IF OBJECT_ID(N'[dbo].[FK_CouponCategories_Categories]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CouponCategories] DROP CONSTRAINT [FK_CouponCategories_Categories];
GO
IF OBJECT_ID(N'[dbo].[FK_CouponCategories_Coupon]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CouponCategories] DROP CONSTRAINT [FK_CouponCategories_Coupon];
GO
IF OBJECT_ID(N'[dbo].[FK_SystemAdmin_inherits_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Users_SystemAdmin] DROP CONSTRAINT [FK_SystemAdmin_inherits_User];
GO
IF OBJECT_ID(N'[dbo].[FK_FirmOwner_inherits_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Users_FirmOwner] DROP CONSTRAINT [FK_FirmOwner_inherits_User];
GO
IF OBJECT_ID(N'[dbo].[FK_Costumer_inherits_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Users_Costumer] DROP CONSTRAINT [FK_Costumer_inherits_User];
GO
IF OBJECT_ID(N'[dbo].[FK_SocialCoupon_inherits_Coupon]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Coupons_SocialCoupon] DROP CONSTRAINT [FK_SocialCoupon_inherits_Coupon];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Coupons]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Coupons];
GO
IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
GO
IF OBJECT_ID(N'[dbo].[Firms]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Firms];
GO
IF OBJECT_ID(N'[dbo].[CouponAlerts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CouponAlerts];
GO
IF OBJECT_ID(N'[dbo].[CouponOrders]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CouponOrders];
GO
IF OBJECT_ID(N'[dbo].[SocialNetworkProfiles1]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SocialNetworkProfiles1];
GO
IF OBJECT_ID(N'[dbo].[Categories]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Categories];
GO
IF OBJECT_ID(N'[dbo].[Users_SystemAdmin]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users_SystemAdmin];
GO
IF OBJECT_ID(N'[dbo].[Users_FirmOwner]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users_FirmOwner];
GO
IF OBJECT_ID(N'[dbo].[Users_Costumer]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users_Costumer];
GO
IF OBJECT_ID(N'[dbo].[Coupons_SocialCoupon]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Coupons_SocialCoupon];
GO
IF OBJECT_ID(N'[dbo].[CostumerCouponAlert]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CostumerCouponAlert];
GO
IF OBJECT_ID(N'[dbo].[CostumerCategories]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CostumerCategories];
GO
IF OBJECT_ID(N'[dbo].[CouponCategories]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CouponCategories];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Coupons'
CREATE TABLE [dbo].[Coupons] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [name] nvarchar(max)  NOT NULL,
    [description] nvarchar(max)  NULL,
    [originalPrice] float  NULL,
    [discountPrice] float  NULL,
    [aggregatedRank] float  NULL,
    [lastDateForUse] datetime  NULL,
    [reaminingQuantity] int  NULL,
    [User_Id] int  NOT NULL
);
GO

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [username] nvarchar(max)  NOT NULL,
    [password] nvarchar(max)  NOT NULL,
    [email] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Firms'
CREATE TABLE [dbo].[Firms] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [name] nvarchar(max)  NOT NULL,
    [address] nvarchar(max)  NOT NULL,
    [longitude] float  NOT NULL,
    [latitude] float  NOT NULL,
    [description] nvarchar(max)  NOT NULL,
    [city] nvarchar(max)  NOT NULL,
    [FirmOwner_Id] int  NOT NULL,
    [SystemAdmin_Id] int  NOT NULL
);
GO

-- Creating table 'CouponAlerts'
CREATE TABLE [dbo].[CouponAlerts] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [alerType] int  NOT NULL,
    [text] nvarchar(max)  NOT NULL,
    [Coupon_Id] int  NULL
);
GO

-- Creating table 'CouponOrders'
CREATE TABLE [dbo].[CouponOrders] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [serialKey] nvarchar(max)  NOT NULL,
    [date] datetime  NOT NULL,
    [recipt] nvarchar(max)  NOT NULL,
    [isUsed] bit  NOT NULL,
    [creditApproval] nvarchar(max)  NOT NULL,
    [rank] int  NOT NULL,
    [QR] nvarchar(max)  NOT NULL,
    [quantity] int  NOT NULL,
    [Coupons_Id] int  NOT NULL,
    [Costumer_Id] int  NOT NULL
);
GO

-- Creating table 'SocialNetworkProfiles1'
CREATE TABLE [dbo].[SocialNetworkProfiles1] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [username] nvarchar(max)  NOT NULL,
    [email] nvarchar(max)  NOT NULL,
    [password] nvarchar(max)  NOT NULL,
    [sendData] nvarchar(max)  NOT NULL,
    [recivedDData] nvarchar(max)  NOT NULL,
    [authToken] nvarchar(max)  NOT NULL,
    [Costumer_Id] int  NOT NULL
);
GO

-- Creating table 'Categories'
CREATE TABLE [dbo].[Categories] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [category] int  NOT NULL
);
GO

-- Creating table 'Users_SystemAdmin'
CREATE TABLE [dbo].[Users_SystemAdmin] (
    [Id] int  NOT NULL
);
GO

-- Creating table 'Users_FirmOwner'
CREATE TABLE [dbo].[Users_FirmOwner] (
    [Id] int  NOT NULL,
    [SystemAdmin_Id] int  NOT NULL
);
GO

-- Creating table 'Users_Costumer'
CREATE TABLE [dbo].[Users_Costumer] (
    [age] float  NOT NULL,
    [gender] int  NOT NULL,
    [longitude] float  NOT NULL,
    [latitude] float  NOT NULL,
    [Id] int  NOT NULL
);
GO

-- Creating table 'Coupons_SocialCoupon'
CREATE TABLE [dbo].[Coupons_SocialCoupon] (
    [Id] int  NOT NULL,
    [Costumer_Id] int  NOT NULL
);
GO

-- Creating table 'CostumerCouponAlert'
CREATE TABLE [dbo].[CostumerCouponAlert] (
    [Costumer_Id] int  NOT NULL,
    [CouponAlerts_Id] int  NOT NULL
);
GO

-- Creating table 'CostumerCategories'
CREATE TABLE [dbo].[CostumerCategories] (
    [Costumer_Id] int  NOT NULL,
    [Categories_Id] int  NOT NULL
);
GO

-- Creating table 'CouponCategories'
CREATE TABLE [dbo].[CouponCategories] (
    [Categories_Id] int  NOT NULL,
    [Coupons1_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Coupons'
ALTER TABLE [dbo].[Coupons]
ADD CONSTRAINT [PK_Coupons]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Firms'
ALTER TABLE [dbo].[Firms]
ADD CONSTRAINT [PK_Firms]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CouponAlerts'
ALTER TABLE [dbo].[CouponAlerts]
ADD CONSTRAINT [PK_CouponAlerts]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CouponOrders'
ALTER TABLE [dbo].[CouponOrders]
ADD CONSTRAINT [PK_CouponOrders]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'SocialNetworkProfiles1'
ALTER TABLE [dbo].[SocialNetworkProfiles1]
ADD CONSTRAINT [PK_SocialNetworkProfiles1]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Categories'
ALTER TABLE [dbo].[Categories]
ADD CONSTRAINT [PK_Categories]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Users_SystemAdmin'
ALTER TABLE [dbo].[Users_SystemAdmin]
ADD CONSTRAINT [PK_Users_SystemAdmin]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Users_FirmOwner'
ALTER TABLE [dbo].[Users_FirmOwner]
ADD CONSTRAINT [PK_Users_FirmOwner]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Users_Costumer'
ALTER TABLE [dbo].[Users_Costumer]
ADD CONSTRAINT [PK_Users_Costumer]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Coupons_SocialCoupon'
ALTER TABLE [dbo].[Coupons_SocialCoupon]
ADD CONSTRAINT [PK_Coupons_SocialCoupon]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Costumer_Id], [CouponAlerts_Id] in table 'CostumerCouponAlert'
ALTER TABLE [dbo].[CostumerCouponAlert]
ADD CONSTRAINT [PK_CostumerCouponAlert]
    PRIMARY KEY CLUSTERED ([Costumer_Id], [CouponAlerts_Id] ASC);
GO

-- Creating primary key on [Costumer_Id], [Categories_Id] in table 'CostumerCategories'
ALTER TABLE [dbo].[CostumerCategories]
ADD CONSTRAINT [PK_CostumerCategories]
    PRIMARY KEY CLUSTERED ([Costumer_Id], [Categories_Id] ASC);
GO

-- Creating primary key on [Categories_Id], [Coupons1_Id] in table 'CouponCategories'
ALTER TABLE [dbo].[CouponCategories]
ADD CONSTRAINT [PK_CouponCategories]
    PRIMARY KEY CLUSTERED ([Categories_Id], [Coupons1_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [SystemAdmin_Id] in table 'Users_FirmOwner'
ALTER TABLE [dbo].[Users_FirmOwner]
ADD CONSTRAINT [FK_SystemAdminFirmOwner]
    FOREIGN KEY ([SystemAdmin_Id])
    REFERENCES [dbo].[Users_SystemAdmin]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_SystemAdminFirmOwner'
CREATE INDEX [IX_FK_SystemAdminFirmOwner]
ON [dbo].[Users_FirmOwner]
    ([SystemAdmin_Id]);
GO

-- Creating foreign key on [Costumer_Id] in table 'Coupons_SocialCoupon'
ALTER TABLE [dbo].[Coupons_SocialCoupon]
ADD CONSTRAINT [FK_CostumerSocialCoupon]
    FOREIGN KEY ([Costumer_Id])
    REFERENCES [dbo].[Users_Costumer]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CostumerSocialCoupon'
CREATE INDEX [IX_FK_CostumerSocialCoupon]
ON [dbo].[Coupons_SocialCoupon]
    ([Costumer_Id]);
GO

-- Creating foreign key on [User_Id] in table 'Coupons'
ALTER TABLE [dbo].[Coupons]
ADD CONSTRAINT [FK_UserCoupon]
    FOREIGN KEY ([User_Id])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UserCoupon'
CREATE INDEX [IX_FK_UserCoupon]
ON [dbo].[Coupons]
    ([User_Id]);
GO

-- Creating foreign key on [FirmOwner_Id] in table 'Firms'
ALTER TABLE [dbo].[Firms]
ADD CONSTRAINT [FK_FirmOwnerFirm]
    FOREIGN KEY ([FirmOwner_Id])
    REFERENCES [dbo].[Users_FirmOwner]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_FirmOwnerFirm'
CREATE INDEX [IX_FK_FirmOwnerFirm]
ON [dbo].[Firms]
    ([FirmOwner_Id]);
GO

-- Creating foreign key on [SystemAdmin_Id] in table 'Firms'
ALTER TABLE [dbo].[Firms]
ADD CONSTRAINT [FK_SystemAdminFirm]
    FOREIGN KEY ([SystemAdmin_Id])
    REFERENCES [dbo].[Users_SystemAdmin]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_SystemAdminFirm'
CREATE INDEX [IX_FK_SystemAdminFirm]
ON [dbo].[Firms]
    ([SystemAdmin_Id]);
GO

-- Creating foreign key on [Coupon_Id] in table 'CouponAlerts'
ALTER TABLE [dbo].[CouponAlerts]
ADD CONSTRAINT [FK_CouponCouponAlert]
    FOREIGN KEY ([Coupon_Id])
    REFERENCES [dbo].[Coupons]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CouponCouponAlert'
CREATE INDEX [IX_FK_CouponCouponAlert]
ON [dbo].[CouponAlerts]
    ([Coupon_Id]);
GO

-- Creating foreign key on [Coupons_Id] in table 'CouponOrders'
ALTER TABLE [dbo].[CouponOrders]
ADD CONSTRAINT [FK_CouponOrderCoupon]
    FOREIGN KEY ([Coupons_Id])
    REFERENCES [dbo].[Coupons]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CouponOrderCoupon'
CREATE INDEX [IX_FK_CouponOrderCoupon]
ON [dbo].[CouponOrders]
    ([Coupons_Id]);
GO

-- Creating foreign key on [Costumer_Id] in table 'CouponOrders'
ALTER TABLE [dbo].[CouponOrders]
ADD CONSTRAINT [FK_CostumerCouponOrder]
    FOREIGN KEY ([Costumer_Id])
    REFERENCES [dbo].[Users_Costumer]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CostumerCouponOrder'
CREATE INDEX [IX_FK_CostumerCouponOrder]
ON [dbo].[CouponOrders]
    ([Costumer_Id]);
GO

-- Creating foreign key on [Costumer_Id] in table 'CostumerCouponAlert'
ALTER TABLE [dbo].[CostumerCouponAlert]
ADD CONSTRAINT [FK_CostumerCouponAlert_Costumer]
    FOREIGN KEY ([Costumer_Id])
    REFERENCES [dbo].[Users_Costumer]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [CouponAlerts_Id] in table 'CostumerCouponAlert'
ALTER TABLE [dbo].[CostumerCouponAlert]
ADD CONSTRAINT [FK_CostumerCouponAlert_CouponAlert]
    FOREIGN KEY ([CouponAlerts_Id])
    REFERENCES [dbo].[CouponAlerts]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CostumerCouponAlert_CouponAlert'
CREATE INDEX [IX_FK_CostumerCouponAlert_CouponAlert]
ON [dbo].[CostumerCouponAlert]
    ([CouponAlerts_Id]);
GO

-- Creating foreign key on [Costumer_Id] in table 'SocialNetworkProfiles1'
ALTER TABLE [dbo].[SocialNetworkProfiles1]
ADD CONSTRAINT [FK_CostumerSocialNetworkProfile]
    FOREIGN KEY ([Costumer_Id])
    REFERENCES [dbo].[Users_Costumer]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CostumerSocialNetworkProfile'
CREATE INDEX [IX_FK_CostumerSocialNetworkProfile]
ON [dbo].[SocialNetworkProfiles1]
    ([Costumer_Id]);
GO

-- Creating foreign key on [Costumer_Id] in table 'CostumerCategories'
ALTER TABLE [dbo].[CostumerCategories]
ADD CONSTRAINT [FK_CostumerCategories_Costumer]
    FOREIGN KEY ([Costumer_Id])
    REFERENCES [dbo].[Users_Costumer]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Categories_Id] in table 'CostumerCategories'
ALTER TABLE [dbo].[CostumerCategories]
ADD CONSTRAINT [FK_CostumerCategories_Categories]
    FOREIGN KEY ([Categories_Id])
    REFERENCES [dbo].[Categories]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CostumerCategories_Categories'
CREATE INDEX [IX_FK_CostumerCategories_Categories]
ON [dbo].[CostumerCategories]
    ([Categories_Id]);
GO

-- Creating foreign key on [Categories_Id] in table 'CouponCategories'
ALTER TABLE [dbo].[CouponCategories]
ADD CONSTRAINT [FK_CouponCategories_Categories]
    FOREIGN KEY ([Categories_Id])
    REFERENCES [dbo].[Categories]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Coupons1_Id] in table 'CouponCategories'
ALTER TABLE [dbo].[CouponCategories]
ADD CONSTRAINT [FK_CouponCategories_Coupon]
    FOREIGN KEY ([Coupons1_Id])
    REFERENCES [dbo].[Coupons]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CouponCategories_Coupon'
CREATE INDEX [IX_FK_CouponCategories_Coupon]
ON [dbo].[CouponCategories]
    ([Coupons1_Id]);
GO

-- Creating foreign key on [Id] in table 'Users_SystemAdmin'
ALTER TABLE [dbo].[Users_SystemAdmin]
ADD CONSTRAINT [FK_SystemAdmin_inherits_User]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'Users_FirmOwner'
ALTER TABLE [dbo].[Users_FirmOwner]
ADD CONSTRAINT [FK_FirmOwner_inherits_User]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'Users_Costumer'
ALTER TABLE [dbo].[Users_Costumer]
ADD CONSTRAINT [FK_Costumer_inherits_User]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'Coupons_SocialCoupon'
ALTER TABLE [dbo].[Coupons_SocialCoupon]
ADD CONSTRAINT [FK_SocialCoupon_inherits_Coupon]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Coupons]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------