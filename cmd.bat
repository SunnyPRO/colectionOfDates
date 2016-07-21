SET SERVERPROJECT=ServerApp\bin\Debug\ServerApp.exe
SET CLIENTPROJECT=ColectiiDistribuitePAD\bin\Debug\ColectiiDistribuitePAD.exe


echo "Starting server projects..."
start %SERVERPROJECT% 12331 1 12336
start %SERVERPROJECT% 12332 1 12336
start %SERVERPROJECT% 12333 1 12335
start %SERVERPROJECT% 12334 1 12335
start %SERVERPROJECT% 12335 3 12333 12334 12336
start %SERVERPROJECT% 12336 3 12331 12332 12335

echo "Start client..."
start %CLIENTPROJECT%
pause