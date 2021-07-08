FROM mcr.microsoft.com/dotnet/aspnet:5.0-focal AS base
WORKDIR /app
EXPOSE 5000
EXPOSE 5001

ENV ASPNETCORE_URLS=http://+:5000

# Creates a non-root user with an explicit UID and adds permission to access the /app folder
# For more info, please refer to https://aka.ms/vscode-docker-dotnet-configure-containers
RUN adduser -u 5678 --disabled-password --gecos "" appuser && chown -R appuser /app
USER appuser

FROM mcr.microsoft.com/dotnet/sdk:5.0-focal AS build
RUN apt-get update && \
    apt-get install -y wget && \
    apt-get install -y gnupg2 && \
    wget -qO- https://deb.nodesource.com/setup_10.x | bash - && \
    apt-get install -y build-essential nodejs
WORKDIR /src
COPY ["Hahn.ApplicatonProcess.February2021.Web/Hahn.ApplicatonProcess.February2021.Web.csproj", "Hahn.ApplicatonProcess.February2021.Web/"]
RUN dotnet restore "Hahn.ApplicatonProcess.February2021.Web/Hahn.ApplicatonProcess.February2021.Web.csproj"
COPY . .
WORKDIR "/src/Hahn.ApplicatonProcess.February2021.Web"
RUN dotnet build "Hahn.ApplicatonProcess.February2021.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Hahn.ApplicatonProcess.February2021.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Hahn.ApplicatonProcess.February2021.Web.dll"]
