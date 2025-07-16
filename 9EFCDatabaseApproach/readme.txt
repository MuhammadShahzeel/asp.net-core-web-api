database approach
it will used when database is already created and we want to use it in our project
it will cretae model and dbcontext automatically

step 1: install required packages
using nuget package manager console or dotnet cli
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Tools
dotnet add package Microsoft.EntityFrameworkCore.Design


Step 2:
Execute a command for Scaffold DbContext.

For Visual Studio (Package Manager Console):

Scaffold-DbContext "Server=YOUR_SERVER_NAME;Database=YOUR_DATABASE_NAME;Trusted_Connection=True;TrustServerCertificate=True" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -Context YOUR_CONTEXT_NAME


For VS Code or .NET CLI terminal:

dotnet ef dbcontext scaffold "Server=YOUR_SERVER_NAME;Database=YOUR_DATABASE_NAME;Trusted_Connection=True;TrustServerCertificate=True" Microsoft.EntityFrameworkCore.SqlServer -o Models -c YOUR_CONTEXT_NAME


Note:
If you add more columns or tables in the database, run the command again with -Force to overwrite existing files.


For Visual Studio (with -Force):

Scaffold-DbContext "Server=YOUR_SERVER_NAME;Database=YOUR_DATABASE_NAME;Trusted_Connection=True;TrustServerCertificate=True" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -Context YOUR_CONTEXT_NAME -Force


For VS Code or .NET CLI (with --force):

dotnet ef dbcontext scaffold "Server=YOUR_SERVER_NAME;Database=YOUR_DATABASE_NAME;Trusted_Connection=True;TrustServerCertificate=True" Microsoft.EntityFrameworkCore.SqlServer -o Models -c YOUR_CONTEXT_NAME --force


After running the command, you will find a new folder named "Models" in your project directory. This folder contains the generated DbContext and entity classes based on your existing database schema.

Step 3:
move connection string to appsettings.json file

  "ConnectionStrings": {
	"dbcs": "put your string here"
	},

step 4: 
in contextdb
replace this:

protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    => optionsBuilder.UseSqlServer("connectionstring");

with this:

protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
    if (!optionsBuilder.IsConfigured)
    {
        // Connection string is configured in Program.cs
    }
}

step 5:
register connection string in Program.cs file

add after
var builder = WebApplication.CreateBuilder(args);

-------------------------------------------------------

var provider = builder.Services.BuildServiceProvider();
var config = provider.GetRequiredService<IConfiguration>();
builder.Services.AddDbContext<StudentDBContext>(items =>
    items.UseSqlServer(config.GetConnectionString("dbcs"))); 

    <StudentDBContext> --replace with your actual name
--------------------------------------------------------
and before this
var app = builder.Build()

step 6:
after that inject DbContext in your controller constructor check controller for details

ctrl + . shortcut

then delete home view and in controller  add new view check for details

create view by slecting indec action method and  select list 







CodeFirstDbContext.cs ghlti sy yeh name hogya StudentDBContext.cs rkhna chahiye tha