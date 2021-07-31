CREATE OR ALTER procedure [dbo].[uspSelectContacts] (@PersonId INT)
AS
BEGIN

SELECT 
	C.Direction AS [Address],
	IIF(C.Principal = 1, 'YES','NO') AS Principal
 FROM Contacts C
WHERE C.PersonId = @PersonId

END
GO


