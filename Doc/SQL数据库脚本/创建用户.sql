CREATE LOGIN [medsurgery] WITH PASSWORD=N'medsurgery', DEFAULT_DATABASE=[master], DEFAULT_LANGUAGE=[¼òÌåÖÐÎÄ], CHECK_EXPIRATION=OFF, CHECK_POLICY=ON
GO
EXEC sys.sp_addsrvrolemember @loginame = N'medsurgery', @rolename = N'sysadmin'