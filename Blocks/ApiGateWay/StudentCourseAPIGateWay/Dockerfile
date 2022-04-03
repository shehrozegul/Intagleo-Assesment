#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Blocks/ApiGateWay/StudentCourseAPIGateWay/StudentCourseAPIGateWay.csproj", "Blocks/ApiGateWay/StudentCourseAPIGateWay/"]
RUN dotnet restore "Blocks/ApiGateWay/StudentCourseAPIGateWay/StudentCourseAPIGateWay.csproj"
COPY . .
WORKDIR "/src/Blocks/ApiGateWay/StudentCourseAPIGateWay"
RUN dotnet build "StudentCourseAPIGateWay.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "StudentCourseAPIGateWay.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "StudentCourseAPIGateWay.dll"]
