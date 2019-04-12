FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["ravi.learn.docker.web/ravi.learn.docker.web.csproj", "ravi.learn.docker.web/"]
RUN dotnet restore "ravi.learn.docker.web/ravi.learn.docker.web.csproj"
COPY . .
WORKDIR "/src/ravi.learn.docker.web"
RUN dotnet build "ravi.learn.docker.web.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "ravi.learn.docker.web.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "ravi.learn.docker.web.dll"]