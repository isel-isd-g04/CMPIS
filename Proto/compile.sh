#!/bin/bash

#./protoc -I="." --csharp_out=../ServiceModels/csharp ValidationService.proto UserData.proto TMAISAPI.proto
./protoc -I="D:\\projects\\ISD\\Proto\\ValidationModels.proto" --csharp_out=../ServiceModels/csharp ValidationService.proto UserData.proto TMAISAPI.proto
./protoc -I="." --java_out=../ServiceModels/java ValidationService.proto UserService.proto
./protoc -I="." --cpp_out=../ServiceModels/cpp ValidationService.proto UserService.proto


./protoc  --include_imports -I="D:\\projects\\ISD\\Proto\\ValidationModels.proto" --csharp_out=../ServiceModels/csharp ValidationService.proto UserData.proto TMAISAPI.proto


 ./protoc  --include_imports -I="../../Proto/ValidationModels.proto" --csharp_out=../ServiceModels/csharp ValidationService.proto UserData.proto TMAISAPI.proto