#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Services/Course/Course.API/Course.API.csproj", "Services/Course/Course.API/"]
COPY ["Services/Course/Course.Domain/Course.DomainObject.csproj", "Services/Course/Course.Domain/"]
RUN dotnet restore "Services/Course/Course.API/Course.API.csproj"
COPY . .
WORKDIR "/src/Services/Course/Course.API"
RUN dotnet build "Course.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Course.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Course.API.dll"]