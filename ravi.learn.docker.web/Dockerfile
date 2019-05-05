FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

ENV ConnectionStrings:MagsConnectionAzMsSql="Server={ENVSRV};Initial Catalog=Magazines;Persist Security Info=False;User ID={ENVDBID};Password={ENVDBPWD};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30"
#ENV DB_UserId=demoadmin
#ENV DB_Pwd=(Chiru123)
#ENV DB_Server=tcp:rgdemodbsql1.database.windows.net,1433

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