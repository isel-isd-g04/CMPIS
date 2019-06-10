#!/bin/bash

dotnet publish -c Release -r linux-x64 -o out /p:ShowLinkerSizeComparison=true

docker build -t kxpto/cmpi-tmais-service .

docker push kxpto/cmpi-tmais-service

read -p "Press any key to continue... " -n1 -s
docker run kxpto/cmpi-tmais-service --name cmoi-tmais -p 9090:9090