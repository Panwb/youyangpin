IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_Escape]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
	PRINT 'Dropping Function  [dbo].[fn_Escape]'
	DROP FUNCTION  [dbo].[fn_Escape]
END 
GO

PRINT 'Create Function  [dbo].[fn_Escape]'   
GO
                        
CREATE FUNCTION [dbo].[fn_Escape]
(
	@Str NVARCHAR(MAX)
)
RETURNS NVARCHAR(MAX)
BEGIN
	IF(@Str IS NULL) RETURN @Str
	
	SET @Str = REPLACE(@Str,'[','[[]')
	SET @Str = REPLACE(@Str,'%','[%]')
	SET @Str = REPLACE(@Str,'_','[_]')
	
	RETURN @Str
END