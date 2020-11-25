USE [PizzaDb]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




CREATE PROCEDURE [dbo].[sp_DeleteUnitPriceById]
@PriceId INT 
As
BEGIN
	DECLARE @Message NVARCHAR(200) = 'Something went wrong, please try again'
	BEGIN TRY
		Update [dbo].[UnitPrice]
		Set IsDelete = 1 WHERE PriceId = @PriceId
		SET @Message = 'UnitPrice has been deleted successfully!'
		SELECT @PriceId AS PriceId, @Message AS [Message]

	END TRY
	BEGIN CATCH
		SELECT @PriceId AS PriceId, @Message AS [Message]
	END CATCH
END
GO


