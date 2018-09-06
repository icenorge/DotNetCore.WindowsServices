FROM microsoft/dotnet:2.1-sdk

# Pre-pre dotnet
RUN dotnet --info
RUN dotnet tool install -g Cake.Tool --version 0.30.0
RUN dotnet tool list -g
ENV PATH="/root/.dotnet/tools:${PATH}"
WORKDIR \build
COPY .\ .
RUN dotnet cake