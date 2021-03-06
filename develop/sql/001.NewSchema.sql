

BEGIN TRANSACTION
/****** Object:  Table [dbo].[Account]    Script Date: 10/08/2012 22:19:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Account](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AccountNumber] [varchar](50) NOT NULL,
	[Balance] [bigint] NOT NULL,
	[Created] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [IX_AccountNumber] UNIQUE NONCLUSTERED 
(
	[AccountNumber] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Transaction]    Script Date: 10/08/2012 22:19:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transaction](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SenderAccountId] [int] NOT NULL,
	[RecipientAccountId] [int] NOT NULL,
	[Amount] [bigint] NOT NULL,
	[Created] [datetime2](7) NOT NULL,
	[Committed] [datetime2](7) NULL,
 CONSTRAINT [PK_Transaction] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Default [DF_Account_Balance]    Script Date: 10/08/2012 22:19:27 ******/
ALTER TABLE [dbo].[Account] ADD  CONSTRAINT [DF_Account_Balance]  DEFAULT ((0)) FOR [Balance]
GO
/****** Object:  Default [DF_Account_Created]    Script Date: 10/08/2012 22:19:27 ******/
ALTER TABLE [dbo].[Account] ADD  CONSTRAINT [DF_Account_Created]  DEFAULT (sysdatetime()) FOR [Created]
GO
/****** Object:  Default [DF_Transaction_Created]    Script Date: 10/08/2012 22:19:27 ******/
ALTER TABLE [dbo].[Transaction] ADD  CONSTRAINT [DF_Transaction_Created]  DEFAULT (sysdatetime()) FOR [Created]
GO
/****** Object:  ForeignKey [FK_Transaction_RecipientAccount]    Script Date: 10/08/2012 22:19:27 ******/
ALTER TABLE [dbo].[Transaction]  WITH CHECK ADD  CONSTRAINT [FK_Transaction_RecipientAccount] FOREIGN KEY([SenderAccountId])
REFERENCES [dbo].[Account] ([Id])
GO
ALTER TABLE [dbo].[Transaction] CHECK CONSTRAINT [FK_Transaction_RecipientAccount]
GO
/****** Object:  ForeignKey [FK_Transaction_SenderAccount]    Script Date: 10/08/2012 22:19:27 ******/
ALTER TABLE [dbo].[Transaction]  WITH CHECK ADD  CONSTRAINT [FK_Transaction_SenderAccount] FOREIGN KEY([SenderAccountId])
REFERENCES [dbo].[Account] ([Id])
GO
ALTER TABLE [dbo].[Transaction] CHECK CONSTRAINT [FK_Transaction_SenderAccount]
GO

COMMIT