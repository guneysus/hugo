
USE [master];
GO

DECLARE @kill varchar(8000) = '';  
SELECT @kill = @kill + 'kill ' + CONVERT(varchar(5), session_id) + ';'  
FROM sys.dm_exec_sessions
WHERE database_id  = db_id('MYDB')

EXEC(@kill);


ALTER DATABASE [MYDB] SET OFFLINE

RESTORE DATABASE [MYDB] 
    FROM DISK = N'/var/opt/mssql/data/MYDB.bak' 
    WITH FILE = 1, 
    MOVE N'MYDB' TO N'/var/opt/mssql/data/MYDB.mdf', 
    MOVE N'MYDB_log' TO N'/var/opt/mssql/data/MYDB_log.ldf', 
    NOUNLOAD, STATS = 5
GO

ALTER DATABASE [MYDB] SET ONLINE