USE [PizzaDb]
GO

/****** Object:  StoredProcedure [dbo].[sp_DeleteSizeById]    Script Date: 25/11/2020 9:55:15 SA ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



ALTER PROCEDURE [dbo].[sp_DeleteSizeById]
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
		SELECT @SizeId AS SizeId, @Message AS [Message]
	END CATCH
END
GO


