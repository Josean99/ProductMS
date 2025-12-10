FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app

COPY ./ProductsMS.sln .
COPY ./../DBContext/*.csproj ./DBContext/
COPY ./../DTOs/*.csproj ./DTOs/
COPY ./../EntityService/*.csproj ./EntityService/
COPY ./../ExternalServices/*.csproj ./ExternalServices/
COPY ./../Infrastructure/*.csproj ./Infrastructure/
COPY ./../Infrastructure.Register/*.csproj ./Infrastructure.Register/
COPY ./../IReadBusinessLayer/*.csproj ./IReadBusinessLayer/
COPY ./../IReadRepositories/*.csproj ./IReadRepositories/
COPY ./../IWriteRepository/*.csproj ./IWriteRepository/
COPY ./../ProductsReadAPI/*.csproj ./ProductsReadAPI/
COPY ./../ProductsWriteAPI/*.csproj ./ProductsWriteAPI/
COPY ./../ReadBusinessLayer/*.csproj ./ReadBusinessLayer/
COPY ./../ReadDTOs/*.csproj ./ReadDTOs/
COPY ./../ReadRepositories/*.csproj ./ReadRepositories/
COPY ./../WriteRepository/*.csproj ./WriteRepository/

RUN dotnet restore 

COPY ./../DBContext/. ./DBContext/
COPY ./../DTOs/. ./DTOs/
COPY ./../EntityService/. ./EntityService/
COPY ./../ExternalServices/. ./ExternalServices/
COPY ./../Infrastructure/. ./Infrastructure/
COPY ./../Infrastructure.Register/. ./Infrastructure.Register/
COPY ./../IReadBusinessLayer/. ./IReadBusinessLayer/
COPY ./../IReadRepositories/. ./IReadRepositories/
COPY ./../IWriteRepository/. ./IWriteRepository/
COPY ./../ProductsReadAPI/. ./ProductsReadAPI/
COPY ./../ReadBusinessLayer/. ./ReadBusinessLayer/
COPY ./../ReadDTOs/. ./ReadDTOs/
COPY ./../ReadRepositories/. ./ReadRepositories/
COPY ./../WriteRepository/. ./WriteRepository/

WORKDIR /app/ProductsReadAPI
RUN dotnet publish -o ./out

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /app

COPY --from=build /app/ProductsReadAPI/out ./

#EXPOSE 5036
#EXPOSE 7036

ENTRYPOINT ["dotnet", "ProductsReadAPI.dll"]
