FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["event-grid-webhook/EventGridWebhook.csproj", "EventGridWebhook/"]
RUN dotnet restore "event-grid-webhook/EventGridWebhook.csproj"
COPY . .
WORKDIR "/src/EventGridWebhook"
RUN dotnet build "EventGridWebhook.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EventGridWebhook.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EventGridWebhook.dll"]