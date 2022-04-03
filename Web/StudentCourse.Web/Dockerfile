#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
RUN apt-get update -yq \
    && apt-get install curl gnupg -yq \
    && curl -sL https://deb.nodesource.com/setup_10.x | bash \
    && apt-get install nodejs -yq
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Web/StudentCourse.Web/StudentCourse.Web.csproj", "Web/StudentCourse.Web/"]
RUN dotnet restore "Web/StudentCourse.Web/StudentCourse.Web.csproj"
COPY . .
WORKDIR "/src/Web/StudentCourse.Web"
RUN dotnet build "StudentCourse.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "StudentCourse.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "StudentCourse.Web.dll"]
