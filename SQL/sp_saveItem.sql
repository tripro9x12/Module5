USE [PizzaDb]
GO
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO







-- =============================================
-- Author:		Trí Huỳnh
-- Create date: 24/11/2020
-- Description:	Create or update Item
-- =============================================
CREATE PROCEDURE [dbo].[sp_SaveItem] 
	@ItemId		INT,
	@ItemName	NVARCHAR(100),
	@SectorsId	INT,
	@Ingredient NVARCHAR(200),
	@Discount	INT,
	@ImageItem	NCHAR(200)

AS
BEGIN
	DECLARE @Message NVARCHAR(100) = 'Something went wrong, please try again later!'
	BEGIN TRY
		-- Create
		--IF(@ItemId IS NULL OR @ItemId = 0)
		IF(ISNULL(@ItemId,0) = 0)
		BEGIN						
			INSERT INTO [dbo].[Item]
					   ([ItemName]
					   ,[SectorsId]
					   ,[Ingredient]
					   ,[Discount]
					   ,[ImageItem]
					   )
			VALUES(@ItemName
				  ,@SectorsId
				  ,@Ingredient
				  ,@Discount
				  ,@ImageItem
				  )
					
			SET @Message = 'Size has been created success'
			SET @ItemId = SCOPE_IDENTITY()

		END
		ELSE --Update
		BEGIN
			IF(NOT EXISTS(SELECT * FROM [dbo].[Item] WHERE ItemId = @ItemId))
			BEGIN
				SET @Message = 'Item Id not found'
			END
			ELSE
			BEGIN
				UPDATE [dbo].[Item]
				   SET [ItemName] = @ItemName
					  ,[SectorsId] = @SectorsId
					  ,[Ingredient] = @Ingredient
					  ,[Discount] = @Discount
					  ,[ImageItem] = @ImageItem
				   WHERE ItemId = @ItemId

					SET @Message = 'ItemId has been updated success'
				
			END
		END
		SELECT @Message AS [Message], @ItemId AS ItemId
	END TRY
	BEGIN CATCH
		SELECT @Message AS [Message], @ItemId AS ItemId
	END CATCH
END
GO


