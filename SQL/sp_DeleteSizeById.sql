USE [PizzaDb]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO






CREATE PROCEDURE [dbo].[sp_DeleteSizeById]
@SizeId INT 
As
BEGIN
	DECLARE @Message NVARCHAR(200) = 'Something went wrong, please try again'
	BEGIN TRY
		Update [dbo].[Size]
		Set IsDelete = 1 WHERE SizeId = @SizeId
		SET @Message = 'Size has been deleted successfully!'
		SELECT @SizeId AS SizeId, @Message AS [Message]

	END TRY
	BEGIN CATCH
		SELECT @SizeId AS SectorsId, @Message AS [Message]
	END CATCH
END
GO


