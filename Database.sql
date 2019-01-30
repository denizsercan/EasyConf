

CREATE TABLE [dbo].[Interests] (
    [Id]            INT            IDENTITY (1, 1) NOT NULL,
    [interestTopic] NVARCHAR (MAX) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[Rewivers] (
    [Id]       INT            IDENTITY (1, 1) NOT NULL,
    [email]    NVARCHAR (MAX) NOT NULL,
    [password] NVARCHAR (MAX) NOT NULL,
    [name]     NVARCHAR (MAX) NULL,
    [surname]  NVARCHAR (MAX) NULL,
    [degree]   NVARCHAR (MAX) NULL,
    [status]   INT            NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[Users] (
    [Id]       INT            IDENTITY (1, 1) NOT NULL,
    [name]     NVARCHAR (MAX) NOT NULL,
    [surname]  NVARCHAR (MAX) NOT NULL,
    [password] NVARCHAR (MAX) NOT NULL,
    [email]    NVARCHAR (MAX) NOT NULL,
    [degree]   NVARCHAR (MAX) NULL,
    [role]     INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


CREATE TABLE [dbo].[Roles] (
    [Id]          INT IDENTITY (1, 1) NOT NULL,
    [role]        INT NOT NULL,
    [fk_Users]    INT NOT NULL,
    [fk_Rewivers] INT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [fk_Users] FOREIGN KEY ([fk_Users]) REFERENCES [dbo].[Users] ([Id]),
    CONSTRAINT [fk_Rewivers] FOREIGN KEY ([fk_Rewivers]) REFERENCES [dbo].[Rewivers] ([Id])
);


CREATE TABLE [dbo].[Rewivers_Interests] (
    [Id]           INT IDENTITY (1, 1) NOT NULL,
    [fk_Interests] INT NULL,
    [fk_Rewivers]  INT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([fk_Interests]) REFERENCES [dbo].[Interests] ([Id]),
    FOREIGN KEY ([fk_Rewivers]) REFERENCES [dbo].[Rewivers] ([Id])
);

CREATE TABLE [dbo].[Conferences] (
    [Id]                    INT            IDENTITY (1, 1) NOT NULL,
    [conferenceName]        NVARCHAR (MAX) NOT NULL,
    [conferenceDate]        DATETIME       NOT NULL,
    [conferencePlace]       NVARCHAR (MAX) NOT NULL,
    [submissionDueDate]     DATETIME       NOT NULL,
    [category]              NVARCHAR (MAX) NOT NULL,
    [status]                INT            NOT NULL,
    [conferenceDescription] NVARCHAR (MAX) NOT NULL,
    [fk_Users]              INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([fk_Users]) REFERENCES [dbo].[Users] ([Id])
);

CREATE TABLE [dbo].[Conferences_Rewivers] (
    [Id]             INT IDENTITY (1, 1) NOT NULL,
    [fk_Conferences] INT NULL,
    [fk_Rewivers]    INT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([fk_Conferences]) REFERENCES [dbo].[Conferences] ([Id]),
    FOREIGN KEY ([fk_Rewivers]) REFERENCES [dbo].[Rewivers] ([Id])
);


CREATE TABLE [dbo].[Topics] (
    [Id]             INT            IDENTITY (1, 1) NOT NULL,
    [topic]          NVARCHAR (MAX) NOT NULL,
    [fk_Conferences] INT            NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([fk_Conferences]) REFERENCES [dbo].[Conferences] ([Id])
);

CREATE TABLE [dbo].[Papers] (
    [Id]             INT             IDENTITY (1, 1) NOT NULL,
    [paper]          VARBINARY (MAX) NOT NULL,
    [filename]       NVARCHAR (MAX)  NULL,
    [contentType]    NVARCHAR (MAX)  NULL,
    [submissionDate] DATETIME        NOT NULL,
    [status]         INT             NOT NULL,
    [authors]        NVARCHAR (MAX)  NULL,
    [fk_Users]       INT             NOT NULL,
    [fk_Topics]      INT             NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([fk_Users]) REFERENCES [dbo].[Users] ([Id]),
    FOREIGN KEY ([fk_Topics]) REFERENCES [dbo].[Topics] ([Id])
);



CREATE PROC SP_BindCheckBox (
@reviwerEmail nvarchar(MAX))
AS
Select * from Topics Where fk_Conferences = (Select Id From Conferences Where Id = (Select top 1 fk_Conferences from Conferences_Rewivers where fk_Rewivers = (select Id from Rewivers where email = @reviwerEmail)order by Id desc))
CREATE PROC SP_CheckRewiverActivated
(
@reviwerEmail nvarchar(MAX)
)
AS
Select status from Rewivers Where email = @reviwerEmail
CREATE PROC SP_InterestEkle
(
@reviwerEmail nvarchar(MAX),
@interestTopic nvarchar(MAX) 
)
AS
IF EXISTS(SELECT * FROM dbo.Interests WHERE  Interests.interestTopic = @interestTopic)
BEGIN
INSERT INTO dbo.Rewivers_Interests (fk_Rewivers, fk_Interests) Values ((Select Id From dbo.Rewivers Where email = @reviwerEmail), (Select Id From Interests Where interestTopic = @interestTopic))
END
ELSE
BEGIN

INSERT INTO dbo.Interests(interestTopic) Values (@interestTopic)
EXEC SP_InterestEkle @reviwerEmail, @interestTopic
    
END
CREATE PROC SP_RewiverEkle
(
@reviwerEmail nvarchar(MAX), 
@reviwerPassword nvarchar(MAX),
@conferenceName nvarchar(MAX)
)
AS
IF EXISTS(SELECT * FROM dbo.Rewivers WHERE  email = @reviwerEmail)
BEGIN
INSERT INTO dbo.Conferences_Rewivers (fk_Rewivers, fk_Conferences) Values ((Select Id From dbo.Rewivers Where email = @reviwerEmail), (Select Id From Conferences Where conferenceName = @conferenceName))
END
ELSE
BEGIN

INSERT INTO dbo.Rewivers(email, dbo.Rewivers.password) Values (@reviwerEmail, @reviwerPassword)
EXEC SP_RewiverEkle @reviwerEmail, @reviwerPassword, @conferenceName
    
END


