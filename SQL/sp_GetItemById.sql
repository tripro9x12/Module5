USE [PizzaDb]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		 Trí Huỳnh
-- Create date: 25/11/2020
-- Description:	Get Item By ItemId
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetItemById] 
	@ItemId	INT
AS
BEGIN

	SELECT i.ItemId,
		   i.ItemName,
		   i.Ingredient,
		   i.Discount,
		   i.ImageItem,
		   s.SectorsName
	  FROM [dbo].[Item] as i INNER JOIN [dbo].[Sectors] as s ON i.SectorsId = s.SectorsId
	WHERE @ItemId = ItemId AND i.IsDelete = 0
END
GO


