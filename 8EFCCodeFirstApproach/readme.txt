abhi mvc bna ra hun q k kaam tosame hi hoga wese is sy yeh hy k frontend miljae ga


step 1: install required packages
using nuget package manager console or dotnet cli
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Tools
dotnet add package Microsoft.EntityFrameworkCore.Design


Hamesha chahiye:
Microsoft.EntityFrameworkCore

Database ke liye:
Microsoft.EntityFrameworkCore.SqlServer (ya jo bhi provider ho)

Migration ke liye:
Microsoft.EntityFrameworkCore.Tools

Design-time support ke liye (recommended):
Microsoft.EntityFrameworkCore.Design

step 2: create a model class and dbcontext class in Models folder check  models folder for detail or you can also  put dbcontext in Data folder



step 3: add connection string in appsettings.json file

"ConnectionStrings": {
  "dbcs": "Server=YOUR_MACHINE_NAME\\SQLEXPRESS;Database=YOUR_DATABASE_NAME;Trusted_Connection=True;TrustServerCertificate=True;"
}

step 4:
register connection string in Program.cs file

add after
var builder = WebApplication.CreateBuilder(args);

-------------------------------------------------------

var provider = builder.Services.BuildServiceProvider();
var config = provider.GetRequiredService<IConfiguration>();
builder.Services.AddDbContext<StudentDBContext>(items =>
    items.UseSqlServer(config.GetConnectionString("dbcs"))); 

    <StudentDBContext> --replace with your actual name


    //use this now its reciommended not the upper one

    builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


--------------------------------------------------------
and before this
var app = builder.Build()

---note:--- after that inject DbContext in your controller constructor check controller for details

ctrl + . shortcut

then delete home view and in controller  add new view check for details

create view by slecting indec action method and  select list 



step 5: add migration using package manager console or dotnet cli

dotnet ef migrations add anyMeaningfulName

or 

tools > NuGet Package Manager > Package Manager Console

add-migration anyMeaningfulName  eg: CodeFirstCreateDB

after date migration generated, you can check Migrations folder for migration file

step 6: update database using package manager console or dotnet cli
dotnet ef database update
or
tools > NuGet Package Manager > Package Manager Console
update-database


note to add a column:
1. Add the property to your model class.
2. Add a new migration using the command:
   dotnet ef migrations add anyMeaningfulName
   or
   add-migration anyMeaningfulName eg: CodeFirstAddStandard
   3. Update the database using the command:
   dotnet ef database update
   // or
   update-database


step 7: display data
in your controller add constructor and do dependency injection check controller for more details 
then just simpple pass in view or return as api









