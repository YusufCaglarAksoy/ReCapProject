SET IDENTITY_INSERT [dbo].[Cars] ON
INSERT INTO [dbo].[Cars] ([Id], [BrandId], [ColorId], [ModelYear], [DailyPrice], [Description]) VALUES (1, 1, 1, 2018, CAST(200 AS Decimal(18, 0)), N'Manuel Benzin')
INSERT INTO [dbo].[Cars] ([Id], [BrandId], [ColorId], [ModelYear], [DailyPrice], [Description]) VALUES (2, 3, 5, 2020, CAST(350 AS Decimal(18, 0)), N'Otomatik dizel')
INSERT INTO [dbo].[Cars] ([Id], [BrandId], [ColorId], [ModelYear], [DailyPrice], [Description]) VALUES (3, 5, 2, 2019, CAST(200 AS Decimal(18, 0)), N'Otomatik Hybrid')
INSERT INTO [dbo].[Cars] ([Id], [BrandId], [ColorId], [ModelYear], [DailyPrice], [Description]) VALUES (4, 5, 6, 2020, CAST(350 AS Decimal(18, 0)), N'Manuel Dizel')
SET IDENTITY_INSERT [dbo].[Cars] OFF
