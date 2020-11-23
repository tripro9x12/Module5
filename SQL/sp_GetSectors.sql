USE [PizzaDb]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		 Trí Huỳnh
-- Create date: 23/11/2020
-- Description:	Get all sectors with isDelete is False
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetSectors] 
AS
BEGIN

	SELECT SectorsId,
		  SectorsName
	  FROM [dbo].[Sectors]
	WHERE [IsDelete] = 0
END
GO



