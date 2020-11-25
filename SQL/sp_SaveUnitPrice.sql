USE [PizzaDb]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		Trí Huỳnh
-- Create date: 25/11/2020
-- Description:	Create or update UnitPrice
-- =============================================
CREATE PROCEDURE [dbo].[sp_SaveUnitPrice] 
	@PriceId		INT,
	@ItemId			INT,
	@SizeId			INT,
	@Price			INT
AS
BEGIN
	DECLARE @Message NVARCHAR(100) = 'Something went wrong, please try again later!'
	BEGIN TRY
		-- Create
		--IF(@PriceId IS NULL OR @PriceId = 0)
		IF(ISNULL(@PriceId,0) = 0)
		BEGIN
			IF(NOT EXISTS(SELECT * FROM UnitPrice WHERE ItemId = @ItemId AND SizeId = @SizeId))
			BEGIN
				INSERT INTO [dbo].[UnitPrice]
						([ItemId]
						,[SizeId]
						,[Price])
				VALUES
						(@ItemId
						,@SizeId
						,@Price)
					
				SET @Message = 'UnitPrice has been created success'
				SET @PriceId = SCOPE_IDENTITY()
			END
			ELSE
			BEGIN
				SET @Message = 'ItemName and SizeName is used'
			END
		END
		ELSE --Update
		BEGIN
			IF(NOT EXISTS(SELECT * FROM [dbo].[UnitPrice] WHERE PriceId = @PriceId))
			BEGIN
				SET @Message = 'Size Id not found'
			END
			ELSE
				IF(NOT EXISTS (SELECT TOP(1) * FROM [dbo].[UnitPrice] 
							   WHERE PriceId != @PriceId AND
							   ItemId = @ItemId AND SizeId = @SizeId))
				BEGIN

					UPDATE [dbo].[UnitPrice]
						   SET [ItemId] = @ItemId
							  ,[SizeId] = @SizeId
							  ,[Price] = @Price
						   WHERE PriceId = @PriceId

					SET @Message = 'PriceId has been updated success'
				
				END
				ELSE
				BEGIN
					SET @Message = 'Item Name and Size Name is used'
				END
		END
		SELECT @Message AS [Message], @PriceId AS PriceId
	END TRY
	BEGIN CATCH
		SELECT @Message AS [Message], @PriceId AS PriceId
	END CATCH
END
GO


