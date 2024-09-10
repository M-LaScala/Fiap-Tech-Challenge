
USE [master]
GO

/****** Object:  Database [techchanllengedbs]    Script Date: 23/07/2024 16:14:02 ******/
CREATE DATABASE [techchanllengedbs]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'techchanllengedbs', FILENAME = N'/var/opt/mssql/data/techchanllengedbs.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'techchanllengedbs_log', FILENAME = N'/var/opt/mssql/data/techchanllengedbs_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [techchanllengedbs].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

USE [techchanllengedbs]

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

IF SCHEMA_ID(N'techchanllenge') IS NULL EXEC(N'CREATE SCHEMA [techchanllenge];');
GO

CREATE TABLE [techchanllenge].[Tb_Contato] (
    [Id] uniqueidentifier NOT NULL,
    [Nome] Varchar(80) NOT NULL,
    [Email] Varchar(40) NOT NULL,
    [Telefone] Varchar(10) NOT NULL,
    [Ddd] Varchar(2) NOT NULL,
    [DataDeCriacao] DateTime NOT NULL,
    [DataDeAlteracao] DateTime NULL,
    CONSTRAINT [PK_Tb_Contato] PRIMARY KEY ([Id])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240418030720_BaseInicial', N'8.0.4');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [techchanllenge].[Tb_RegiaoDdd] (
    [Id] uniqueidentifier NOT NULL,
    [Codigo] int NOT NULL,
    [Estado] Varchar(2) NOT NULL,
    [Descricao] Varchar(50) NOT NULL,
    [DataDeCriacao] datetime2 NOT NULL DEFAULT '2024-05-01T00:44:52.5059049Z',
    [DataDeAlteracao] datetime2 NULL,
    CONSTRAINT [PK_Tb_RegiaoDdd] PRIMARY KEY ([Id])
);
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Codigo', N'DataDeAlteracao', N'DataDeCriacao', N'Descricao', N'Estado') AND [object_id] = OBJECT_ID(N'[techchanllenge].[Tb_RegiaoDdd]'))
    SET IDENTITY_INSERT [techchanllenge].[Tb_RegiaoDdd] ON;
INSERT INTO [techchanllenge].[Tb_RegiaoDdd] ([Id], [Codigo], [DataDeAlteracao], [DataDeCriacao], [Descricao], [Estado])
VALUES ('0589f76f-cca7-4f8b-bfe6-81528fb284b0', 61, NULL, '2024-05-01T00:44:52.5061282Z', 'Centro-Oeste', 'MG'),
('0eed422d-15b6-472f-a9ef-41dce135994e', 47, NULL, '2024-05-01T00:44:52.5061274Z', 'Sul', 'SC'),
('138b7ed3-e4a5-47bc-89fa-7116eded119f', 65, NULL, '2024-05-01T00:44:52.5061285Z', 'Centro-Oeste', 'MT'),
('157329da-793c-4be1-94e8-995df5155938', 18, NULL, '2024-05-01T00:44:52.5061216Z', 'Sudeste', 'SP'),
('1707bf2c-eb82-4428-b11a-ef3541e50222', 37, NULL, '2024-05-01T00:44:52.5061265Z', 'Sudeste', 'MG'),
('2479c04d-ccb8-4e41-8fda-17cf33bd3e75', 73, NULL, '2024-05-01T00:44:52.5061301Z', 'Nordeste', 'BA'),
('249cc8ca-0b77-47f6-a8a5-f23758854907', 22, NULL, '2024-05-01T00:44:52.5061219Z', 'Sudeste', 'RJ'),
('27065733-0912-4d1d-aa13-43de66180b06', 89, NULL, '2024-05-01T00:44:52.5061315Z', 'Nordeste', 'PI'),
('2e1a6526-2840-4e48-916c-ad63962dd702', 96, NULL, '2024-05-01T00:44:52.5061292Z', 'Norte', 'AP'),
('3136e301-6608-4f6a-8d51-6cd72a606aa0', 75, NULL, '2024-05-01T00:44:52.5061303Z', 'Nordeste', 'BA'),
('3307e912-fa12-4600-9970-c055f3f5a058', 51, NULL, '2024-05-01T00:44:52.5061276Z', 'Sul', 'RS'),
('35a7e32c-1f28-4e6d-955c-631acf59fb75', 44, NULL, '2024-05-01T00:44:52.5061271Z', 'Sul', 'PR'),
('35b68b80-6311-449d-8cc5-9b707d55bc5d', 24, NULL, '2024-05-01T00:44:52.5061220Z', 'Sudeste', 'RJ'),
('363b50c0-46a8-4290-af2d-21d2b1c3232c', 48, NULL, '2024-05-01T00:44:52.5061275Z', 'Sul', 'SC'),
('3641630e-86a3-451d-affa-23965228c9c4', 13, NULL, '2024-05-01T00:44:52.5061201Z', 'Sudeste', 'SP'),
('3905cc59-a07c-41c4-a38b-7104e52fcc1f', 92, NULL, '2024-05-01T00:44:52.5061293Z', 'Norte', 'AM'),
('391e1a45-0c3e-462f-8390-51711129847f', 79, NULL, '2024-05-01T00:44:52.5061318Z', 'Nordeste', 'SE'),
('3df42706-728d-498c-8567-8f5891e8dfe1', 53, NULL, '2024-05-01T00:44:52.5061280Z', 'Sul', 'RS'),
('4d4bc72f-fd26-4fb1-8e72-2161d58c1a15', 85, NULL, '2024-05-01T00:44:52.5061306Z', 'Nordeste', 'CE'),
('50410a0e-d7f0-40db-8207-d72ef5fd8740', 97, NULL, '2024-05-01T00:44:52.5061294Z', 'Norte', 'AM'),
('5490b2c3-7f99-4c44-8a07-41b0ac6bec6f', 46, NULL, '2024-05-01T00:44:52.5061273Z', 'Sul', 'PR'),
('56c2c878-d4b4-401e-b8cd-aec150b046a8', 19, NULL, '2024-05-01T00:44:52.5061217Z', 'Sudeste', 'SP'),
('59949c4a-046b-4aef-bd42-56040862d827', 12, NULL, '2024-05-01T00:44:52.5061200Z', 'Sudeste', 'SP'),
('62abcc16-660f-4dc1-8756-48adc3418c66', 21, NULL, '2024-05-01T00:44:52.5061218Z', 'Sudeste', 'RJ'),
('64680cc5-908f-47c5-8da4-4f1af348cdcf', 11, NULL, '2024-05-01T00:44:52.5061197Z', 'Sudeste', 'SP'),
('6a6ba9ed-ca1d-4ff7-835e-f5d87b7e1a11', 33, NULL, '2024-05-01T00:44:52.5061262Z', 'Sudeste', 'MG'),
('6a986fe4-573c-497b-996f-959e81eed721', 84, NULL, '2024-05-01T00:44:52.5061316Z', 'Nordeste', 'RN'),
('6bf8ae60-cf2f-41ed-9b80-d5aa726effc7', 55, NULL, '2024-05-01T00:44:52.5061281Z', 'Sul', 'RS'),
('6faae7be-0399-4aef-a683-f75088234e2c', 49, NULL, '2024-05-01T00:44:52.5061275Z', 'Sul', 'SC'),
('704a2903-c63b-4edd-9460-45739c1fa958', 17, NULL, '2024-05-01T00:44:52.5061206Z', 'Sudeste', 'SP'),
('721e10fd-fa65-4363-9075-5fab8bbf9216', 98, NULL, '2024-05-01T00:44:52.5061308Z', 'Nordeste', 'MA'),
('7d3f2ef0-9717-4799-b138-1937afecc90a', 91, NULL, '2024-05-01T00:44:52.5061295Z', 'Norte', 'PA'),
('82473912-6cfa-4f6d-ac6a-e8aa112d8268', 83, NULL, '2024-05-01T00:44:52.5061310Z', 'Nordeste', 'PB'),
('846aa5cb-c149-41b2-9279-d03b4dd4e607', 99, NULL, '2024-05-01T00:44:52.5061309Z', 'Nordeste', 'MA'),
('86e527e3-e71b-4659-b8c8-42d2380b8f76', 86, NULL, '2024-05-01T00:44:52.5061313Z', 'Nordeste', 'PI'),
('8c325796-8046-4dff-b798-0d70798b9150', 67, NULL, '2024-05-01T00:44:52.5061289Z', 'Centro-Oeste', 'MS'),
('93282d5c-b803-4581-a7d8-add528d7a199', 28, NULL, '2024-05-01T00:44:52.5061222Z', 'Sudeste', 'ES'),
('96d5748b-2b80-4fbb-97f1-d7b6200457d9', 69, NULL, '2024-05-01T00:44:52.5061291Z', 'Norte', 'RO'),
('9aa8d2ef-fb90-40c0-88e2-22c9e6bd9046', 54, NULL, '2024-05-01T00:44:52.5061280Z', 'Sul', 'RS'),
('9fb12816-1d16-41cd-9e79-d929f4bda83a', 42, NULL, '2024-05-01T00:44:52.5061267Z', 'Sul', 'PR'),
('a04e03a9-371a-44d8-9666-e0fc8538bf4d', 82, NULL, '2024-05-01T00:44:52.5061317Z', 'Nordeste', 'AL'),
('a18aed3b-30a7-4d9e-bd43-fdd74b6246cd', 27, NULL, '2024-05-01T00:44:52.5061221Z', 'Sudeste', 'ES');
INSERT INTO [techchanllenge].[Tb_RegiaoDdd] ([Id], [Codigo], [DataDeAlteracao], [DataDeCriacao], [Descricao], [Estado])
VALUES ('a292cb13-e393-4279-9258-32ac278f97ed', 93, NULL, '2024-05-01T00:44:52.5061297Z', 'Norte', 'PA'),
('aa07ec60-9023-4749-9e62-dcac760f26b0', 14, NULL, '2024-05-01T00:44:52.5061202Z', 'Sudeste', 'SP'),
('ad643600-348e-4620-9817-308282f1b45f', 41, NULL, '2024-05-01T00:44:52.5061266Z', 'Sul', 'PR'),
('b3b086ea-2125-4198-ab7f-17f78f4dcbf2', 74, NULL, '2024-05-01T00:44:52.5061302Z', 'Nordeste', 'BA'),
('b41fd644-eaaa-4855-8145-e8d157ca017f', 35, NULL, '2024-05-01T00:44:52.5061264Z', 'Sudeste', 'MG'),
('b860f49b-d952-4e9f-a004-310759ed7e2d', 88, NULL, '2024-05-01T00:44:52.5061307Z', 'Nordeste', 'CE'),
('b9211ec6-1220-4e33-999e-8cf869d41dc2', 66, NULL, '2024-05-01T00:44:52.5061286Z', 'Centro-Oeste', 'MT'),
('b93cd4f2-219e-4c55-9609-12e72f010a6c', 31, NULL, '2024-05-01T00:44:52.5061223Z', 'Sudeste', 'MG'),
('ba63163f-61e7-47a5-8386-24ee269d7f9f', 71, NULL, '2024-05-01T00:44:52.5061300Z', 'Nordeste', 'BA'),
('bdcd959b-db78-4906-9315-9553e11cb601', 16, NULL, '2024-05-01T00:44:52.5061205Z', 'Sudeste', 'SP'),
('beac6cf9-ccfc-451e-8d77-4216881554e4', 15, NULL, '2024-05-01T00:44:52.5061203Z', 'Sudeste', 'SP'),
('bf2e0270-4db0-427f-ac69-3afe5610d471', 63, NULL, '2024-05-01T00:44:52.5061290Z', 'Norte', 'TO'),
('bf97db69-908e-4a69-b2e6-c14a652662e7', 62, NULL, '2024-05-01T00:44:52.5061283Z', 'Centro-Oeste', 'GO'),
('c63f095b-f0db-4f37-a476-25c4388557c0', 87, NULL, '2024-05-01T00:44:52.5061312Z', 'Nordeste', 'PE'),
('c6a4756c-e952-490a-a5bb-a069e2965053', 81, NULL, '2024-05-01T00:44:52.5061311Z', 'Nordeste', 'PE'),
('cb2a0e90-39ee-4e74-800a-1bbc0effaa44', 64, NULL, '2024-05-01T00:44:52.5061284Z', 'Centro-Oeste', 'GO'),
('cb2ce430-1d3e-4c9f-951e-4e5e86042494', 77, NULL, '2024-05-01T00:44:52.5061304Z', 'Nordeste', 'BA'),
('cd446ee0-b75a-40be-adb9-4c6c1a4d3719', 95, NULL, '2024-05-01T00:44:52.5061299Z', 'Norte', 'RR'),
('d4debec4-d8ed-4360-9b8e-92f609ce2679', 45, NULL, '2024-05-01T00:44:52.5061272Z', 'Sul', 'PR'),
('d70092d6-7fae-430e-ba02-a14b5bc42f52', 34, NULL, '2024-05-01T00:44:52.5061263Z', 'Sudeste', 'MG'),
('e2a7f7a2-0777-42df-9008-f904f6d85dc9', 38, NULL, '2024-05-01T00:44:52.5061266Z', 'Sudeste', 'MG'),
('e5e41bc0-7428-46bc-8a2a-9468202bbbeb', 43, NULL, '2024-05-01T00:44:52.5061270Z', 'Sul', 'PR'),
('f2f23922-620a-4c2d-86b9-faa5a71029ea', 94, NULL, '2024-05-01T00:44:52.5061298Z', 'Norte', 'PA'),
('f3ce76c6-c23c-4b4d-827e-04cc71479604', 68, NULL, '2024-05-01T00:44:52.5061290Z', 'Norte', 'AC'),
('fc337cca-c279-4885-baeb-48006096afcf', 32, NULL, '2024-05-01T00:44:52.5061226Z', 'Sudeste', 'MG');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Codigo', N'DataDeAlteracao', N'DataDeCriacao', N'Descricao', N'Estado') AND [object_id] = OBJECT_ID(N'[techchanllenge].[Tb_RegiaoDdd]'))
    SET IDENTITY_INSERT [techchanllenge].[Tb_RegiaoDdd] OFF;
GO

CREATE INDEX [IX_Tb_RegiaoDdd_Codigo] ON [techchanllenge].[Tb_RegiaoDdd] ([Codigo]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240501004452_CriarTabelaRegiaoDdd', N'8.0.4');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

EXEC sp_rename N'[techchanllenge].[Tb_Contato].[Telefone]', N'NumeroTelefone', N'COLUMN';
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240526165456_RenomenandoCampoTelefone', N'8.0.4');
GO

COMMIT;
GO

