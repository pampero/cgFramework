﻿USE [GUIDE]
SET IDENTITY_INSERT [dbo].[Route] ON
INSERT [dbo].[Route] ([ID], [Name], [Distance], [Comments], [Created], [CreatedBy], [Deleted], [DeletedBy], [Updated], [UpdatedBy], [IsDeleted], [Customer_ID]) VALUES (3, N'Ruta 1', 10, N'Sin Comentarios', CAST(0x00009E0B00000000 AS DateTime), N'Carlos', CAST(0x00009E0B00000000 AS DateTime), N'Carlos', CAST(0x00009E0B00000000 AS DateTime), N'Carlos', 0, 3)
INSERT [dbo].[Route] ([ID], [Name], [Distance], [Comments], [Created], [CreatedBy], [Deleted], [DeletedBy], [Updated], [UpdatedBy], [IsDeleted], [Customer_ID]) VALUES (4, N'Ruta 2', 20, N'Sin Comentarios', CAST(0x00009E0B00000000 AS DateTime), N'Carlos', CAST(0x00009E0B00000000 AS DateTime), N'Carlos', CAST(0x00009E0B00000000 AS DateTime), N'Carlos', 0, 3)
SET IDENTITY_INSERT [dbo].[Route] OFF