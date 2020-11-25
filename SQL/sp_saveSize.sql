USE [PizzaDb]
GO

/****** Object:  StoredProcedure [dbo].[sp_SaveSize]    Script Date: 25/11/2020 8:04:28 SA ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO








-- =============================================
-- Author:		Trí Huỳnh
-- Create date: 23/11/2020
-- Description:	Create or update Sectors
-- =============================================
ALTER PROCEDURE [dbo].[sp_SaveSize] 
	@SizeId		INT,
	@SizeName	VARCHAR(10)
AS
BEGIN
	DECLARE @Message NVARCHAR(100) = 'Something went wrong, please try again later!'
	BEGIN TRY
		-- Create
		--IF(@StudentId IS NULL OR @StudentId = 0)
		IF(ISNULL(@SizeId,0) = 0)
		BEGIN
			IF(NOT EXISTS(SELECT * FROM Size WHERE LOWER(RTRIM(LTRIM(SizeName))) = LOWER(RTRIM(LTRIM(@SizeName)))))
			BEGIN
				INSERT INTO [dbo].[Size](SizeName)
				VALUES(@SizeName)
					
				SET @Message = 'Size has been created success'
				SET @SizeId = SCOPE_IDENTITY()
			END
			ELSE
			BEGIN
				SET @Message = 'Size Name is used'
			END
		END
		ELSE --Update
		BEGIN
			IF(NOT EXISTS(SELECT * FROM [dbo].[Size] WHERE SizeId = @SizeId))
			BEGIN
				SET @Message = 'Size Id not found'
			END
			ELSE
				IF(NOT EXISTS (SELECT TOP(1) * FROM [dbo].[Size] 
							   WHERE SizeId != @SizeId AND
							   LOWER(RTRIM(LTRIM(SizeName))) = LOWER(RTRIM(LTRIM(@SizeName)))))
				BEGIN

					UPDATE [dbo].[Size]
					SET [SizeName] = @SizeName
					WHERE SizeId = @SizeId

						SET @Message = 'SizeId has been updated success'
				
				END
				ELSE
				BEGIN
					SET @Message = 'Size Name is used'
				END
		END
		SELECT @Message AS [Message], @SizeId AS SizeId
	END TRY
	BEGIN CATCH
		SELECT @Message AS [Message], @SizeId AS SizeId
	END CATCH
END
GO



