dotnet restore

agrego en el archivo appsettings.json
"Microsoft.EntityFrameworkCore.Database.Command": "Information"

y en startup.cs

        //AGREGO ESTA LINEA
            services.AddDbContext<CineDbContext>(
            o => 
                o.UseSqlServer(Configuration.GetConnectionString("CineConnectionString")).EnableSensitiveDataLogging()
            );


##Pasos previos:

Crear un proyecto .net core webapi o angular.

dotnet new webapi --o ProyCine --no-https

Dentro de la carpeta del proyecto instalar los siguientes paquetes nuget

dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
dotnet add package Microsoft.EntityFrameworkCore.Design 

También instalar las siguientes herramientas a nivel global

dotnet tool install --global dotnet-ef 
dotnet tool install --global dotnet-aspnet-codegenerator

Hacer un build de la aplicación con el siguiente comando:

	dotnet build

Luego tipear el siguiente comando:

	dotnet ef

Crear la base de datos Cine desde el Management Studio con el siguiente comando:

	create database cine

Crear el archivo dbcontext utilizando el siguiente comando:

dotnet ef dbcontext scaffold "Server=192.168.99.100;Database=Instituto;user=sa;password=Password_123; "  Microsoft.EntityFrameworkCore.Sqlserver   -o Models -c InstitutoDbContext

Alternativamente la instancia en tu PC puede ser localhost o .\sqlexpress, y si no tenemos configurado usuario y password podemos utilizar trusted_connection=true.
Abrir el archivo CineDbContext y comentar la línea que dice #warning...


	dotnet ef migrations add AgregoBiodeActor
	dotnet ef database update

##Punto 5: Ordenando los archivos

Agregar en el archivo Appsettings.json el connection string:

  "ConnectionStrings": {
    "CineConnectionString": 
    " Server=192.168.99.100;Database=Cine;user=sa;password=Password_123; "
  },

En el archivo startup.cs agregar en el siguiente método la línea.
using ProyCine.Models;
using Microsoft.EntityFrameworkCore;


   public void ConfigureServices(IServiceCollection services)
        {
//AGREGO ESTA LINEA
            services.AddDbContext<CineDbContext>(o => o.UseSqlServer(Configuration.GetConnectionString("CineConnectionString")));
        }

En el dbcontext comento la línea con el connection string

##Punto 6: Crear controladores con el comando dotnet aspnet-codegenerator

dotnet tool update -g dotnet-aspnet-codegenerator

dotnet aspnet-codegenerator controller -name PeliculasController -api -m Pelicula -dc CineDbContext -outDir Controllers

Tener en cuenta:

•	controller especifica que voy a crear un controlador
•	-name especifica el nombre del controlador
•	-api  el tipo del controlador
•	-m toma la entidad a partir de la cual crea el controlador
•	-dc especifica el dbcontext que utiliza
•	-outDir es la carpeta donde coloca el controlador
