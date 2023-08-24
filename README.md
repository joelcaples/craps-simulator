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

### Run Containers (from Solution Root):
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


