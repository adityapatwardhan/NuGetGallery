﻿CREATE PROCEDURE [dbo].[DownloadsByPackageId]
	@PackageId NVARCHAR(128)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT	P.[PackageId],
			P.[PackageVersion],
			SUM(ISNULL(F.[DownloadCount], 0)) AS [TotalDownloadCount]
	FROM	[dbo].[Fact_Download] (NOLOCK) AS F

	INNER JOIN	[dbo].[Dimension_Package] AS P (NOLOCK)
	ON		P.[Id] = F.[Dimension_Package_Id]

	WHERE		P.PackageId = @PackageId

	GROUP BY	P.[PackageId],
				P.[PackageVersion]

	ORDER BY
				P.PackageVersion

END