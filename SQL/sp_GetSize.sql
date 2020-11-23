USE [PizzaDb]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		 Trí Huỳnh
-- Create date: 23/11/2020
-- Description:	Get all size with isDelete is False
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetSize] 
AS
BEGIN

	SELECT SizeId,
		   SizeName
	FROM [dbo].[Size]
	WHERE [IsDelete] = 0
END
GO


