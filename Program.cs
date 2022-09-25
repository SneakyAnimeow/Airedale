using Airedale;
using Airedale.Database.Context;
using Airedale.Database.Model;
using Airedale.GraphQL;
using Airedale.Security;
using PasswordGenerator;

var builder = WebApplication.CreateBuilder(args);

AiredaleConfig.Instance = builder.Configuration.GetSection("Airedale").Get<AiredaleConfig>();

builder.Services.AddHttpContextAccessor();

builder.Services.AddControllersWithViews();

builder.Services.AddSwaggerGen();

builder.Services.AddGraphQLServer()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) {
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.MapGraphQL("/api/graphql");

if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI(c => {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Airedale CMS API v1");
    });
}

app.UseSecurity();

var initializeDatabase = () => {
    var context = new AiredaleDbContext();
    
    if(!context.Users.Any(user => user.Name == "admin")) {
        var password = new Password().Next();
        
        Console.WriteLine($"No admin user found, creating user 'admin' with password: {password}");
        
        context.Users.Add(new User {
            Name = "admin",
            PassHash = AiredaleArgon2.Hash(password),
            Token = Guid.NewGuid().ToString()
        });
    }

    context.SaveChanges();
};

initializeDatabase();

app.Run();