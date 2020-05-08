# import-module sqlps;
$Folder   = '/var/opt/mssql/data/backups';
$FileName = 'db_0.bak';
$database = 'db';
$BackupFile = $Folder + '/' + $FileName ;

$user = 'sa';
$pass = 'xVnQB3xg';
$securePass = ConvertTo-SecureString -String $pass

$cred = New-Object PSObject;
$cred | add-member user $user;
$cred | add-member password $pass;

Backup-SqlDatabase -ServerInstance '127.0.0.1' -Database $database -BackupFile $BackupFile -SqlCredential $cred # (Get-Credential sa);

