# craps-simulator

VS uses this command to build:
```
docker build -f "D:\dev\joelcaples\craps-simulator\craps-simulator.service\Dockerfile" --force-rm -t crapssimulatorservice  --label "com.microsoft.created-by=visual-studio" --label "com.microsoft.visual-studio.project-name=craps-simulator.service" "D:\dev\joelcaples\craps-simulator"
```

### Build Docker Images (from Solution Root):
```
docker build --force-rm -t craps-simulator-service -f .\craps-simulator.service\Dockerfile .
docker build --force-rm -t craps-simulator-react -f .\craps-simulator.react\Dockerfile .
```

### Run Containers (http)
- Run from Solution root
- Service API: 3001:
- Website: 3000
```
docker run -dp 127.0.0.1:3001:80 craps-simulator-service
docker run -dp 127.0.0.1:3000:3000 craps-simulator-react
```

### Website:
http://localhost:3000

### Service API:
http://localhost:3001/craps



## Certs
https://learn.microsoft.com/en-us/aspnet/core/security/docker-https?view=aspnetcore-7.0

### Create Cert (localhost only)
```
$password="123456"
$user_profile_path="C:\Users\jmcap"

dotnet dev-certs https -ep $user_profile_path\.aspnet\https\aspnetapp.pfx -p $password
dotnet dev-certs https --trust
```

### Run Container (http, https)
- Run from Solution root

```
$password="123456"
$user_profile_path="C:\Users\jmcap"

docker run --rm -it -dp 8080:80 -p 8443:443 -e ASPNETCORE_URLS="https://+;http://+" -e ASPNETCORE_HTTPS_PORT=8001 -e ASPNETCORE_Kestrel__Certificates__Default__Password="$password" -e ASPNETCORE_Kestrel__Certificates__Default__Path=/https/aspnetapp.pfx -v $user_profile_path\.aspnet\https:/https/ craps-simulator-service
```

