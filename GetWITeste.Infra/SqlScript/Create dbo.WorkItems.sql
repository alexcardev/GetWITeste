USE master;
GO
IF DB_ID (N'WorkItemsTeste') IS NOT NULL
DROP DATABASE WorkItemsTeste;
GO
CREATE DATABASE WorkItemsTeste;
GO

USE [WorkItemsTeste]
GO

/****** Object: Table [dbo].[WorkItems] Script Date: 10/09/2019 14:33:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[WorkItems] (
    [Id]     INT           NOT NULL,
    [Tipo]   VARCHAR (50)  NOT NULL,
    [Titulo] VARCHAR (255) NOT NULL,
    [Data]   DATETIME      NOT NULL
);

GO

CREATE PROCEDURE [dbo].[IncluirWorkItem]
	@Id int,
	@Tipo varchar(50),
	@Titulo varchar(255),
	@Data DateTime
AS

BEGIN

	INSERT INTO dbo.WorkItems(Id, Tipo, Titulo, [Data]) VALUES (@Id, @Tipo, @Titulo, @Data);

END
GO

CREATE PROCEDURE [dbo].[ListarWorkItems]
AS
BEGIN

SELECT 
	Id,
	Tipo,
	Titulo,
	[Data]
FROM
	dbo.WorkItems;
END
GO

CREATE PROCEDURE [dbo].[ObterUltimoIdWorkItem]

AS

BEGIN

SELECT TOP 1 Id FROM dbo.WorkItems order by Id desc;

END
GO
