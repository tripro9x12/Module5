USE [PizzaDb]
GO


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		 Trí Huỳnh
-- Create date: 24/11/2020
-- Description:	Get all UnitPrice with ItemId And isDelete is False
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetUnitPriceByItemId] 
	@ItemId	INT
AS
BEGIN
	SELECT up.[PriceId]
      ,s.[SizeName]
      ,up.[Price]
  FROM [dbo].[UnitPrice] as up INNER JOIN [dbo].[Size] as s ON up.SizeId = s.SizeId
  WHERE up.ItemId = @ItemId AND up.isDelete = 0
END
GO


