# Docker Compose Sample

To run sample execute:
```
docker build -t dockercompose .

docker run -d -p 443:443 -p80:80 --name mydocker dockercompose

curl http://localhost/api/values

```

To Push image to Docker Hub:
```
docker login -u <USER_NAME> -p <PASSWORD>
docker tag <IMAGE_ID> juanluelguerre/demo1
docker push juanluelguerre/demo1
```

To Push image to Nexus (Steps)
```
doker loging -u jguerrmi -p <PASSWORD> steps.everis.com:10012
docker tag <IMAGE_ID> steps.everis.com:10012/demo1
docker push juanluelguerre/demo1
```
Donde: 10012, es el puerto donde se publican las imágenes docker en el repositorio concreto de Nexus.

Note: HTTS app is not ready in this example.