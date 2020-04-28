CREATE PROCEDURE [dbo].[spUserLookup]
	@Id int
AS
BEGIN
	SET NOCOUNT ON;

	SELECT Id, FirstName, LastName
	FROM [dbo].[User]
	WHERE Id = @Id;
END
