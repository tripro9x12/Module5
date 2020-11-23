USE [PizzaDb]
GO

/****** Object:  StoredProcedure [dbo].[sp_DeleteSectorsById]    Script Date: 23/11/2020 10:39:16 SA ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO





ALTER PROCEDURE [dbo].[sp_DeleteSectorsById]
@SectorsId INT 
As
BEGIN
	DECLARE @Message NVARCHAR(200) = 'Something went wrong, please try again'
	BEGIN TRY
		Update [dbo].[Sectors]
		Set IsDelete = 1 WHERE SectorsId = @SectorsId
		SET @Message = 'Sectors has been deleted successfully!'
		SELECT @SectorsId AS SectorsId, @Message AS [Message]

	END TRY
	BEGIN CATCH
		SELECT @SectorsId AS SectorsId, @Message AS [Message]
	END CATCH
END
GO


