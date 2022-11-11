FROM mcr.microsoft.com/dotnet/sdk:5.0-alpine AS build
WORKDIR /source

# copy csproj and restore as distinct layers
COPY source/projektas/projektas/*.csproj .
RUN dotnet restore -r linux-musl-arm64 /p:PublishReadyToRun=true

# copy everything else and build app
COPY source/projektas/projektas/. .
RUN dotnet publish -c Release -o /app -r linux-musl-x64 --self-contained true --no-restore /p:PublishReadyToRun=true /p:PublishSingleFile=true

# final stage/image
FROM mcr.microsoft.com/dotnet/runtime-deps:5.0-alpine-arm64v8
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT ["./projektas"]

# See: https://github.com/dotnet/announcements/issues/20
# Uncomment to enable globalization APIs (or delete)
# ENV \
#     DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false \
#     LC_ALL=en_US.UTF-8 \
#     LANG=en_US.UTF-8
# RUN apk add --no-cache \
#     icu-data-full \
#     icu-libs
