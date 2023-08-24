# craps-simulator

VS uses this command to build:
```
docker build -f "D:\dev\joelcaples\craps-simulator\craps-simulator.service\Dockerfile" --force-rm -t crapssimulatorservice  --label "com.microsoft.created-by=visual-studio" --label "com.microsoft.visual-studio.project-name=craps-simulator.service" "D:\dev\joelcaples\craps-simulator"
```

To build from Solution Root:
```
docker build --force-rm -t craps-simulator-service -f .\craps-simulator.service\Dockerfile .
```

To run container image exposed to the host on port 3000:
```
docker run -dp 127.0.0.1:3000:80 craps-simulator-service
```

http://localhost:3000/craps


