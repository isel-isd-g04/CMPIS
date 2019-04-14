#!/bin/bash

./protoc -I="." --csharp_out=../ServiceModels/csharp ValidationService.proto UserService.proto
./protoc -I="." --java_out=../ServiceModels/java ValidationService.proto UserService.proto
./protoc -I="." --cpp_out=../ServiceModels/cpp ValidationService.proto UserService.proto