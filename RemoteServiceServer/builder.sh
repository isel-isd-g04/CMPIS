#!/bin/bash

dotnet publish -c Release -r linux-x64 -o out /p:ShowLinkerSizeComparison=true

docker build -t kxpto/cmpi-service .

docker push kxpto/cmpi-service
read -p "Press any key to continue... " -n1 -s
#docker run cmpi-service --name cmpi