# Seguridad

## echo "Hola, mundo!" > README.md

## pego en csproj las librerias que necesito

<PackageReference Include="microsoft.entityframeworkcore" Version="3.1.9" />
<PackageReference Include="Microsoft.EntityFrameworkCore.SqlServer" Version="3.1.9" />
<PackageReference Include="Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore" Version="3.1.0" />
<PackageReference Include="Microsoft.AspNetCore.Identity.EntityFrameworkCore" Version="3.1.0" />
<PackageReference Include="Microsoft.AspNetCore.Identity.UI" Version="3.1.0" />
<PackageReference Include="Microsoft.EntityFrameworkCore.Design" Version="3.1.0" /> 
<PackageReference Include="Microsoft.EntityFrameworkCore.Tools" Version="3.1.0" />
<PackageReference Include="Microsoft.VisualStudio.Web.CodeGeneration.Design" Version="3.1.0" />
<PackageReference Include="Microsoft.EntityFrameworkCore.Sqlite" Version="3.1.9" />


## dotnet restore


## dotnet aspnet-codegenerator identity --listFiles

## dotnet aspnet-codegenerator identity --files

## dotnet aspnet-codegenerator identity --files --useSqLite

## dotnet aspnet-codegenerator identity --files="Account.AccessDenied;Account.ConfirmEmail;Account.ExternalLogin;Account.ForgotPassword;Account.ForgotPasswordConfirmation;Account.Lockout;Account.Login;Account.LoginWith2fa;Account.LoginWithRecoveryCode;Account.Logout;Account.Manage._Layout;Account.Manage._ManageNav;Account.Manage._StatusMessage;Account.Manage.ChangePassword;Account.Manage.DeletePersonalData;Account.Manage.Disable2fa;Account.Manage.DownloadPersonalData;Account.Manage.EnableAuthenticator;Account.Manage.ExternalLogins;Account.Manage.GenerateRecoveryCodes;Account.Manage.Index;Account.Manage.PersonalData;Account.Manage.ResetAuthenticator;Account.Manage.SetPassword;Account.Manage.TwoFactorAuthentication;Account.Register;Account.ResetPassword;Account.ResetPasswordConfirmation"

## https://www.codaffection.com/asp-net-core-article/asp-net-core-identity-for-user-authentication-and-registration/


## dotnet aspnet-codegenerator identity --files="Account.AccessDenied;Account.ConfirmEmail;Account.ExternalLogin;Account.Logout;Account.Register;" --useSqlLite

## https://bjdejongblog.nl/category/azure/

## dotnet aspnet-codegenerator identity --useSqLite -dc IdentityDbContext --files "Account.Register;Account.Login;Account.Logout"

## dotnet ef migrations add MigrarIdentidad --context IdentityDbContext

## dotnet ef database update --context IdentityDbContext 


<pre>
public void ConfigureServices(IServiceCollection services)
{
    ...
    //agregado para identity
    services.AddRazorPages();
}

public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
{
    ...

    app.UseRouting();

    //agregado para identity
    app.UseAuthentication();
    app.UseAuthorization();

    app.UseEndpoints(endpoints =>
    {
        endpoints.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");
        //agregado para identity
        endpoints.MapRazorPages();
    });
}
</pre>

## En Views/Shared/_Layout.cshtml
### agrego <partial name="_LoginPartial" ></partial>


### En areas Identity está todo el código generado el cual podemos modificar las vistas y los controladores generados

## En Areas/Identity/IdentityHostingStartup.cs podemos configurar las distintas opciones como vimos en clase (usuario bloqueado, caracteres especiales, longitud de contraseña).

## La autorización en ASP.NET Core se controla con AuthorizeAttribute y sus diversos parámetros. En su forma más simple, aplicar el atributo [Authorize] a un controlador o acción, limita el acceso a ese componente a cualquier usuario autenticado.

## También puede utilizar el atributo AllowAnonymous para permitir el acceso de usuarios no autenticados a acciones individuales.

## [AllowAnonymous]omite todas las declaraciones de autorización. Si combina [AllowAnonymous]y cualquier [Authorize]atributo, los [Authorize]atributos se ignoran. Por ejemplo, si aplica [AllowAnonymous]en el nivel de controlador, [Authorize]se ignora cualquier atributo en el mismo controlador (o en cualquier acción dentro de él).


## var user = await _userManager.GetUserAsync(HttpContext.User);

