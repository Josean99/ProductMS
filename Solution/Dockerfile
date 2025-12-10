FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app

COPY ./ProductsMS.sln .
COPY ./BusinessLayer/*.csproj ./BusinessLayer/
COPY ./DBContext/*.csproj ./DBContext/
COPY ./DTOs/*.csproj ./DTOs/
COPY ./EntityService/*.csproj ./EntityService/
COPY ./ExternalServices/*.csproj ./ExternalServices/
COPY ./IBusinessLayer/*.csproj ./IBusinessLayer/
COPY ./Infrastructure/*.csproj ./Infrastructure/
COPY ./Infrastructure.Register/*.csproj ./Infrastructure.Register/
COPY ./IReadRepositories/*.csproj ./IReadRepositories/
COPY ./IWriteRepository/*.csproj ./IWriteRepository/
COPY ./ProductsWriteAPI/*.csproj ./ProductsWriteAPI/
COPY ./ReadRepositories/*.csproj ./ReadRepositories/
COPY ./WriteRepository/*.csproj ./WriteRepository/

RUN dotnet restore 

COPY ./BusinessLayer/. ./BusinessLayer/
COPY ./DBContext/. ./DBContext/
COPY ./DTOs/. ./DTOs/
COPY ./EntityService/. ./EntityService/
COPY ./ExternalServices/. ./ExternalServices/
COPY ./IBusinessLayer/. ./IBusinessLayer/
COPY ./Infrastructure/. ./Infrastructure/
COPY ./Infrastructure.Register/. ./Infrastructure.Register/
COPY ./IReadRepositories/. ./IReadRepositories/
COPY ./IWriteRepository/. ./IWriteRepository/
COPY ./ProductsWriteAPI/. ./ProductsWriteAPI/
COPY ./ReadRepositories/. ./ReadRepositories/
COPY ./WriteRepository/. ./WriteRepository/

WORKDIR /app/ProductsWriteAPI
RUN dotnet publish -o ./out

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /app

COPY --from=build /app/ProductsWriteAPI/out ./

#EXPOSE 5036
#EXPOSE 7036

ENTRYPOINT ["dotnet", "ProductsWriteAPI.dll"]
