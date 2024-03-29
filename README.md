# Plantilla
## Entorno Desconectado

```html
        public void Agregar(Profesor profesor){
            var profattach= _context.Attach(profesor);
            profattach.State = EntityState.Added;
            _context.SaveChanges();
        }

        public void Eliminar(Profesor profesor){
            _context.Attach(profesor).State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public void Modificar(Profesor profesor){
            _context.Attach(profesor).State = EntityState.Modified;
            _context.SaveChanges();
        }
```
https://dev.to/christianaugustyn/entity-framework-core-connected-vs-disconnected-3dk7

## Ejecutar Stored Procedures

```html
        List<Product> list;
        string sql = "EXEC SalesLT.Product_Get @ProductID";
        List<SqlParameter> parms = new List<SqlParameter>
        {
            // Create parameter(s)    
            new SqlParameter { ParameterName = "@ProductID", Value = 706 }
        };

        list = _db.Products.FromSqlRaw<Product>(sql, parms.ToArray()).ToList();
```
## Ejecutar Vista SQL

```html
            string sql = "select * from VistaMatrices where art_CodGen=@art_CodGen";
            List<SqlParameter> parms = new List<SqlParameter>
            {    
                new SqlParameter { ParameterName = "@art_CodGen", Value = id }
            };

            var matrices=_context.Matrices.FromSqlRaw<Matriz>(sql, parms.ToArray());
            return matrices.First();
```

## Insertar datos en la migración
```html
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO MyNewTable(NyColumnName) Values('Test')");
	}
```
## Crear y borrar la base cuando ejecuta el proyecto

```html
public BookContext(DbContextOptions<BookContext> options)
            :base(options)
        {
             
            //Database.EnsureCreated();
            //Database.EnsureDeleted();
            
        }
```
### En model puedo poner la siguiente linea para no crear clave autoincremental:
  
  <b>[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]    </b>

/*clave compuesta*/
modelBuilder.Entity<MaterialPieza>()
                .HasKey(c => new { c.art_CodGen, c.MaterialId });
		
## Exportar Script SQL

dotnet ef migrations script
 
dotnet ef migrations script --output "script.sql" --context AppDbContext

## Nuevas funcionalidades

Edicion de foto y muestra sinfoto.jpg a las vacias.

dotnet restore

agrego en el archivo appsettings.json

`
"Microsoft.EntityFrameworkCore.Database.Command": "Information"
`
y en startup.cs

```html
//AGREGO ESTA LINEA
            services.AddDbContext<CineDbContext>(
            o => 
                o.UseSqlServer(Configuration.GetConnectionString("CineConnectionString")).EnableSensitiveDataLogging()
            );
```

## Pasos previos:

Crear un proyecto .net core webapi o angular.

`
dotnet new webapi --o ProyCine --no-https
`

## Instalar los siguientes paquetes nuget
Dentro de la carpeta del proyecto 

    dotnet add package Microsoft.EntityFrameworkCore.SqlServer
    
    dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
    
    dotnet add package Microsoft.EntityFrameworkCore.Design 

También instalar las siguientes herramientas a nivel global

    dotnet tool install --global dotnet-ef 
    
    dotnet tool install --global dotnet-aspnet-codegenerator  --version 5.0.2

Hacer un build de la aplicación con el siguiente comando:

	dotnet build


Luego tipear el siguiente comando:

	dotnet ef

Crear la base de datos Cine desde el Management Studio con el siguiente comando:

	create database cine

### Crear el archivo dbcontext utilizando el siguiente comando:
```html
    dotnet ef dbcontext scaffold "Server=192.168.99.100;Database=Instituto;user=sa;password=Password_123; "  Microsoft.EntityFrameworkCore.Sqlserver   -o Models -c InstitutoDbContext
```

### Crea el dbcontext con determinadas tablas
```html
dotnet ef dbcontext scaffold "Server=desadb;Database=Instituto;user=sa;password=Password_123; "  Microsoft.EntityFrameworkCore.Sqlserver   -o Models -c InstitutoDbContext -t Afiliados -t Localidades
```

### Crear el dbcontext con Data Annotations

```
dotnet ef dbcontext scaffold "Server=localhost;Database=herramientas2022;trusted_connection=true; "  Microsoft.EntityFrameworkCore.Sqlserver   -o ModelsDA -c IsteaDbContext --data-annotations
```
Alternativamente la instancia en tu PC puede ser localhost o .\sqlexpress, y si no tenemos configurado usuario y password podemos utilizar trusted_connection=true.
Abrir el archivo CineDbContext y comentar la línea que dice #warning...


	dotnet ef migrations add AgregoBiodeActor
	dotnet ef database update
---
### Mapear una vista

```
dotnet ef dbcontext scaffold  "server=.;database=AccesoriosDos;trusted_connection=true;"  Microsoft.EntityFrameworkCore.Sqlserver   -o ModelsDA -c IsteaDbContext -t VistaFuerzaArticulos --data-annotations
```
Resultado
```html
            modelBuilder.Entity<VistaFuerzaArticulo>(entity =>
            {
                entity.ToView("VistaFuerzaArticulos");
            });
```

## Punto 5: Ordenando los archivos

Agregar en el archivo Appsettings.json el connection string:
```html
  "ConnectionStrings": {
    "CineConnectionString": 
    " Server=192.168.99.100;Database=Cine;user=sa;password=Password_123; "
  },
```
En el archivo startup.cs agregar en el siguiente método la línea.
using ProyCine.Models;
using Microsoft.EntityFrameworkCore;


   ```html
   public void ConfigureServices(IServiceCollection services)
        {
//AGREGO ESTA LINEA
            services.AddDbContext<CineDbContext>(o => o.UseSqlServer(Configuration.GetConnectionString("CineConnectionString")));
        }
```

En el dbcontext comento la línea con el connection string
---
## Punto 6: Crear controladores con el comando dotnet aspnet-codegenerator
```html   
dotnet tool update -g dotnet-aspnet-codegenerator
    
dotnet aspnet-codegenerator controller -name PeliculasController -api -m Pelicula -dc CineDbContext -outDir Controllers

dotnet aspnet-codegenerator razorpage -m Profesor -dc HerramientasDbContext -outDir ./Pages/Profesores
```
## Tener en cuenta:

-	controller especifica que voy a crear un controlador
-	-name especifica el nombre del controlador
-	-api  el tipo del controlador
-	-m toma la entidad a partir de la cual crea el controlador
-	-dc especifica el dbcontext que utiliza
-	-outDir es la carpeta donde coloca el controlador
-	-udl Usa el layout por default
