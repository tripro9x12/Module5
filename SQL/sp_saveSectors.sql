USE [PizzaDb]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Trí Huỳnh
-- Create date: 23/11/2020
-- Description:	Create or update Sectors
-- =============================================
ALTER PROCEDURE [dbo].[sp_SaveSectors] 
	@SectorsId		INT,
	@SectorsName	NVARCHAR(100)
AS
BEGIN
	DECLARE @Message NVARCHAR(100) = 'Something went wrong, please try again later!'
	BEGIN TRY
		-- Create
		--IF(@SectorsId IS NULL OR @SectorsId = 0)
		IF(ISNULL(@SectorsId,0) = 0)
		BEGIN
			IF(NOT EXISTS(SELECT * FROM Sectors WHERE LOWER(RTRIM(LTRIM(SectorsName))) = LOWER(RTRIM(LTRIM(@SectorsName)))))
			BEGIN
				INSERT INTO [dbo].[Sectors](SectorsName)
				VALUES(@SectorsName)
					
				SET @Message = 'Sectors has been created success'
				SET @SectorsId = SCOPE_IDENTITY()
			END
			ELSE
			BEGIN
				SET @Message = 'Sectors Name is used'
			END
		END
		ELSE --Update
		BEGIN
			IF(NOT EXISTS(SELECT * FROM [dbo].[Sectors] WHERE SectorsId = @SectorsId))
			BEGIN
				SET @Message = 'Sectors Id not found'
			END
			ELSE
				IF(NOT EXISTS (SELECT TOP(1) * FROM [dbo].[Sectors] 
							   WHERE SectorsId != @SectorsId AND
							   LOWER(RTRIM(LTRIM(SectorsName))) = LOWER(RTRIM(LTRIM(@SectorsName)))))
				BEGIN

					UPDATE [dbo].[Sectors]
					SET [SectorsName] = @SectorsName
					WHERE SectorsId = @SectorsId

						SET @Message = 'SectorsId has been updated success'
				
				END
				ELSE
				BEGIN
					SET @Message = 'Sectors Name is used'
				END
		END
		SELECT @Message AS [Message], @SectorsId AS SectorsId
	END TRY
	BEGIN CATCH
		SELECT @Message AS [Message], @SectorsId AS SectorsId
	END CATCH
END
GO

