STEP: 1

• Add Identity To Our Project.
// Right Click on the Project
// Select "Add" -> "New Scaffolded Item..."
// Select "Identity" from the left pane
// Click "Add" button

Add Layout Page 
// select views>shared>_Layout.cshtml


Select Features you want to add in Identity.

Create a Data Context Class which is used to communicate with our database.

Create a User Class

• After Adding Identity there is a folder called "Areas" appears.

Step : 2

add partial view for login and register in navbar
in _Layout.cshtml 
<partial name="_LoginPartial"/>

step:3 
in program.cs
add before app.Run()
app.MapRazorPages();

Step: 4

Add Some Properties In Application User class.
Areas>Identity>Data>ApplicationUser.cs

Register these properties OR configure in ApplicationDbContext class.

// Areas>Identity>Data>ApplicationDbContext.cs
// Add the following code in OnModelCreating method

  base.OnModelCreating(builder);
        builder.ApplyConfiguration(new ApplicationUserEntityConfiguration());


ApplicationUserEntityConfiguration() -> anyname you want

click on bulb 
and select "Generate class 'ApplicationUserEntityConfiguration'"

change internal to public

<object> change it to ApplicationUser or class name
click on bulb and select "implement interface"

throw new NotImplementedException(); -> remove it 

add this:

//nameshould match your properties youy added


builder.Property(x => x.FirstName).HasMaxLength(255);
builder.Property(x => x.LastName).HasMaxLength(255);


step 5:
add connection string in appsettings.json

by default it give you this

(localdb)\\mssqllocaldb-> replace it with your server name 

  "ConnectionStrings": {
    "ApplicationDBContextConnection": "Server=(localdb)\\mssqllocaldb;Database=13Identity;Trusted_Connection=True;MultipleActiveResultSets=true"
  }

  steep 6:
  add migrations
  // Open Package Manager Console

  // Run the following command to add a migration
  Add-Migration InitialCreate 
  // Run the following command to update the database
  Update-Database

  step 7:
  add properties in register view
  // Areas>Identity>Pages>Account>Register.cshtml.cs

 right click on input.email > go to definition 
  add your own properties

    <div class="form-floating mb-3">
                <input asp-for="Input.Email" class="form-control" autocomplete="username" aria-required="true" placeholder="name@example.com" />
                <label asp-for="Input.Email">Email</label>
                <span asp-validation-for="Input.Email" class="text-danger"></span>
            </div> copy and change accordingly



step: 8 
again go to definition 
 public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                var user = CreateUser();

                -------------------------
        ->        // Add the following code to set the additional properties
                user.FirstName = Input.FirstName;
                user.LastName = Input.LastName;
                ---------------------------

                await _userStore.SetUserNameAsync(user, Input.Email, CancellationToken.None);



                note:

                builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false).AddEntityFrameworkStores<ApplicationDBContext>();

                make it false if you dint need email confirmation