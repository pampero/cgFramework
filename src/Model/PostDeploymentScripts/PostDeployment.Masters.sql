USE [GUIDE]

SET IDENTITY_INSERT [dbo].[Customer] ON
INSERT [dbo].[Customer] ([ID], [Name], [DefaultContractType], [Created], [CreatedBy], [Deleted], [DeletedBy], [Updated], [UpdatedBy], [IsDeleted]) VALUES (1, N'Carlos', 1, CAST(0x0000A0E600000000 AS DateTime), N'Carlos', NULL, NULL, NULL, NULL, 0)
SET IDENTITY_INSERT [dbo].[Customer] OFF

SET IDENTITY_INSERT [dbo].[Route] ON
INSERT [dbo].[Route] ([ID], [Name], [Distance], [Comments], [Created], [CreatedBy], [Deleted], [DeletedBy], [Updated], [UpdatedBy], [IsDeleted], [Customer_ID]) VALUES (3, N'Ruta 1', 10, N'Sin Comentarios', CAST(0x00009E0B00000000 AS DateTime), N'Carlos', CAST(0x00009E0B00000000 AS DateTime), N'Carlos', CAST(0x00009E0B00000000 AS DateTime), N'Carlos', 0, 1)
INSERT [dbo].[Route] ([ID], [Name], [Distance], [Comments], [Created], [CreatedBy], [Deleted], [DeletedBy], [Updated], [UpdatedBy], [IsDeleted], [Customer_ID]) VALUES (4, N'Ruta 2', 20, N'Sin Comentarios', CAST(0x00009E0B00000000 AS DateTime), N'Carlos', CAST(0x00009E0B00000000 AS DateTime), N'Carlos', CAST(0x00009E0B00000000 AS DateTime), N'Carlos', 0, 1)
SET IDENTITY_INSERT [dbo].[Route] OFF