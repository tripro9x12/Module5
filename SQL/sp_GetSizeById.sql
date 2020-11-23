USE [PizzaDb]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		 Trí Huỳnh
-- Create date: 23/11/2020
-- Description:	Get size by sizeId
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetSizeById] 
	@SizeId	INT
AS
BEGIN

	SELECT SizeId,
		  SizeName
	  FROM [dbo].[Size]
	WHERE @SizeId = SizeId
END
GO


