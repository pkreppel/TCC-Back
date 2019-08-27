CREATE TABLE [dbo].[Users] (
    [Id]           INT             IDENTITY (1, 1) NOT NULL,
    [FirstName]    VARCHAR (255)   NULL,
    [LastName]     VARCHAR (255)   NULL,
    [Username]     VARCHAR (255)   NULL,
    [PasswordHash] VARBINARY (MAX) NULL,
    [PasswordSalt] VARBINARY (MAX) NULL,
    CONSTRAINT [pk_Users] PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[TipoRisco] (
    [TipoRiscoID]    INT           IDENTITY (1, 1) NOT NULL,
    [NomeTipoRisco]  VARCHAR (MAX) NOT NULL,
    [Criticidade]    INT           NOT NULL,
    [LocalTipoRisco] VARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_TIPORISCO] PRIMARY KEY CLUSTERED ([TipoRiscoID] ASC)
);

CREATE TABLE [dbo].[SensoresBarragem] (
    [SensorID]          INT        IDENTITY (1, 1) NOT NULL,
    [TipoSensor]        INT        NOT NULL,
    [ValorSensor]       FLOAT (53) NOT NULL,
    [HoraMonitoramento] DATETIME   DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_SENSORES] PRIMARY KEY CLUSTERED ([SensorID] ASC)
);

CREATE TABLE [dbo].[Risco] (
    [RiscoID]        INT           IDENTITY (1, 1) NOT NULL,
    [TipoRiscoID]    INT           NOT NULL,
    [DescricaoRisco] VARCHAR (MAX) NOT NULL,
    [DataCadastro]   DATETIME      CONSTRAINT [DF_RISCO] DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_RISCO] PRIMARY KEY CLUSTERED ([RiscoID] ASC),
    CONSTRAINT [FK_RISCO_TIPORISCO] FOREIGN KEY ([TipoRiscoID]) REFERENCES [dbo].[TipoRisco] ([TipoRiscoID])
);

