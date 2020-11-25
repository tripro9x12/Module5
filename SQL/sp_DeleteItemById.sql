USE [PizzaDb]
GO


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[sp_DeleteItemById]
@ItemId INT 
As
BEGIN
	DECLARE @Message NVARCHAR(200) = 'Something went wrong, please try again'
	BEGIN TRY
		Update [dbo].[Item]
		Set IsDelete = 1 WHERE ItemId = @ItemId
		SET @Message = 'Item has been deleted successfully!'
		SELECT @ItemId AS ItemId, @Message AS [Message]

	END TRY
	BEGIN CATCH
		SELECT @ItemId AS ItemId, @Message AS [Message]
	END CATCH
END
GO


