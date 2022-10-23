FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["BlazorBlog.Server/BlazorBlog.Server.csproj", "BlazorBlog.Server/"]
RUN dotnet restore "BlazorBlog.Server/BlazorBlog.Server.csproj"
COPY . .
WORKDIR "/src/BlazorBlog.Server"
RUN dotnet build "BlazorBlog.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BlazorBlog.Server.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BlazorBlog.Server.dll"]
