CREATE USER [3dea86ca-ddb0-4f1c-b905-d6387a65e681] FROM EXTERNAL PROVIDER;
exec sp_addrolemember ‘dbmanager’, ‘3dea86ca-ddb0-4f1c-b905-d6387a65e681’ ;
exec sp_addrolemember ‘loginmanager’, ‘3dea86ca-ddb0-4f1c-b905-d6387a65e681’ ;


CREATE USER [3dea86ca-ddb0-4f1c-b905-d6387a65e681] FROM EXTERNAL PROVIDER;
EXEC sp_addrolemember 'dbmanager', '3dea86ca-ddb0-4f1c-b905-d6387a65e681';
EXEC sp_addrolemember 'loginmanager', '3dea86ca-ddb0-4f1c-b905-d6387a65e681';


