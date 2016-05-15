USE [ComicsCatalogue]
GO

SELECT uasd.name, schemaName = kds.name, uasd.collation_name FROM sys.types as uasd  
inner join (SELECT * FROM sys.schemas)as kds
on uasd.schema_id = kds.schema_id
WHERE uasd.is_user_defined = 1