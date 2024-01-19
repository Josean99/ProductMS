##Copiar ficheros de la base de datos
$source = "../../Database"
$destino = "."

Copy-Item -Path $source -Filter "*.sql" -Recurse -Destination $destino -Container -force

##Borrar la imagen vieja
docker rm $(docker stop $(docker ps -a -q --filter ancestor='postgres' --format="{{.ID}}"))
docker rmi $(docker images -q postgres)

##construir la imagen
docker build -t postgres .

##iniciar el contenedor
docker run -d -p 6432:5432 postgres
