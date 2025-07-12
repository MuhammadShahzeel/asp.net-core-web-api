using _4Middlewares.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// ===== CUSTOM MIDDLEWARES =====

// Middleware 1: Inline in Program.cs
app.Use(async (context, next) =>
{
    Console.WriteLine($"[Middleware 1] Incoming Request: {context.Request.Method} {context.Request.Path}");
    await next();
    Console.WriteLine($"[Middleware 1] Outgoing Response: {context.Response.StatusCode} for {context.Request.Method} {context.Request.Path}");
});

// Middleware 2: Inline in Program.cs
app.Use(async (context, next) =>
{
    Console.WriteLine($"[Middleware 2] Incoming Request: {context.Request.Method} {context.Request.Path}");
    await next();
    Console.WriteLine($"[Middleware 2] Outgoing Response: {context.Response.StatusCode} for {context.Request.Method} {context.Request.Path}");
});

// Middleware 3: Separate class
app.UseMiddleware<Middleware3>();



// ===== BUILT-IN MIDDLEWARES =====
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

//handle routing midlleware
app.MapControllers(); //jitny bh rotes sy controllers hain unko handle karega
//agr in routes sy pehly middle wares chlany hy to is sy upar lgana hoga


// ===== APP.RUN() ka middle ware next nhileta agre is k bad koi bhi middle ware lgadia to nhi chly ga=====
// Ye last middleware hota hai
// next nahi leta – pipeline yahin khatam ho jaati hai
// Iske baad koi aur middleware nahi chalega
//Midware 4: using app.run
//app.Run(async context =>
//{
//    Console.WriteLine($"[Middleware 4] Incoming Request: {context.Request.Method} {context.Request.Path}");
//    context.Response.StatusCode = 200; // Set response status code
//    await context.Response.WriteAsync("Hello from Middleware 4!"); // Write response body
//    Console.WriteLine($"[Middleware 4] Outgoing Response: {context.Response.StatusCode} for {context.Request.Method} {context.Request.Path}");
//});

app.Run();
