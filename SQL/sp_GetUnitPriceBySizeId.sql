USE [PizzaDb]
GO

/****** Object:  StoredProcedure [dbo].[sp_GetUniPriceBySizeId]    Script Date: 25/11/2020 2:54:40 CH ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		 Trí Huỳnh
-- Create date: 25/11/2020
-- Description:	Get UnitPrice by SizeId
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetUnitPriceBySizeId] 
	@SizeId	INT
AS
BEGIN

	SELECT up.[PriceId]
		  ,i.[ItemName]
		  ,s.[SizeName]
		  ,up.[Price]
		  ,i.[Ingredient]
		  ,i.[Discount]
		  ,i.[ImageItem]
	  FROM [dbo].[UnitPrice] AS up INNER JOIN [dbo].[Item] AS i ON up.ItemId = i.ItemId
									INNER JOIN [dbo].[Size] AS s ON up.SizeId = s.SizeId
	WHERE up.SizeId = @SizeId AND up.isDelete = 0 AND i.IsDelete = 0 AND s.IsDelete = 0

END
GO



