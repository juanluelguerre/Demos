# Docker Compose Sample

To run sample execute:
```
docker build -t dockercompose .

docker run -d -p 443:443 -p80:80 --name mydocker dockercompose

curl http://localhost/api/values


```
Note: HTTS is not ready in this example.