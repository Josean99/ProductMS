##Borrar la imagen vieja
docker rm $(docker stop $(docker ps -a -q --filter ancestor='solution-write-api' --format="{{.ID}}"))
docker rm $(docker stop $(docker ps -a -q --filter ancestor='solution-read-api' --format="{{.ID}}"))
docker rmi $(docker images -q solution-writeAPI)
docker rmi $(docker images -q solution-readAPI)
docker rmi $(docker images -q postgres)

##construir
cd ../Solution/
docker-compose up
