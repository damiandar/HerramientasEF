dotnet restore

agrego en el archivo appsettings.json
"Microsoft.EntityFrameworkCore.Database.Command": "Information"

y en startup.cs

        //AGREGO ESTA LINEA
            services.AddDbContext<CineDbContext>(
            o => 
                o.UseSqlServer(Configuration.GetConnectionString("CineConnectionString")).EnableSensitiveDataLogging()
            );
