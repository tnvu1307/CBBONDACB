FROM mcr.microsoft.com/dotnet/aspnet:6.0-alpine AS base
WORKDIR /app
EXPOSE 138
#EXPOSE 8181
#ENV ASPNETCORE_URLS=https://*:8181

RUN apk add curl

FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine AS build
WORKDIR /src
COPY HOSTService/HOSTService.vbproj HOSTService/
RUN dotnet restore "HOSTService/HOSTService.vbproj"
COPY . .
WORKDIR "/src/HOSTService"
RUN dotnet build "HOSTService.vbproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "HOSTService.vbproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "HOSTService.dll"]