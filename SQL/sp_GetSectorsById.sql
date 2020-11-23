USE [PizzaDb]
GO

/****** Object:  StoredProcedure [dbo].[sp_GetSectors]    Script Date: 23/11/2020 10:26:11 SA ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		 Trí Huỳnh
-- Create date: 23/11/2020
-- Description:	Get all sectors with isDelete is False
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetSectorsById] 
	@SectorsId	INT
AS
BEGIN

	SELECT SectorsId,
		  SectorsName
	  FROM [dbo].[Sectors]
	WHERE @SectorsId = SectorsId
END
GO


