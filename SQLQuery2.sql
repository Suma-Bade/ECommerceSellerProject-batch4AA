/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP 1000 [itemid]
      ,[price]
      ,[itemname]
      ,[description]
      ,[stockno]
      ,[remarks]
      ,[sellerid]
  FROM [ECommerceDB].[dbo].[Items]
  alter table Items add imagename varchar(20)
  select * from Items