/*
   zondag 30 september 201222:12:05
   User: 
   Server: localhost
   Database: tdd
   Application: 
*/

/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
CREATE TABLE dbo.Account
	(
	Id int NOT NULL IDENTITY (1, 1),
	AccountNumber varchar(50) NOT NULL,
	Created datetime2(7) NOT NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Account ADD CONSTRAINT
	DF_Account_Created DEFAULT ((SYSDATETIME())) FOR Created
GO
ALTER TABLE dbo.Account ADD CONSTRAINT
	PK_Account PRIMARY KEY CLUSTERED 
	(
	Id
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.Account ADD CONSTRAINT
	IX_AccountNumber UNIQUE NONCLUSTERED 
	(
	AccountNumber
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.Account SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.Account', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Account', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Account', 'Object', 'CONTROL') as Contr_Per 