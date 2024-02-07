using Microsoft.AspNetCore.Identity;
using Portfolio_API;
var builder = WebApplication.CreateBuilder(args);

string jwtPass = builder.Configuration.GetValue<string>("JwtPass")
    ?? throw new ArgumentNullException("JwtPass not found");

string dbConnection = builder.Configuration.GetValue<string>("DbContext")
    ?? throw new ArgumentNullException("DbContext not found");

builder.Services
    .AddEndpointsApiExplorer()
    .AddSwaggerGen()
    .AddIdentity<IdentityUser<int>, IdentityRole<int>>(options =>
    {
        options.SignIn.RequireConfirmedEmail = true;
    })
    .AddEntityFrameworkStores<ApplicationDatabaseContext>()
    .AddDefaultTokenProviders();

builder.Services
    .AddScoped<IUserService, UserService>()
    .AddScoped<ILoginService, LoginService>()
    .AddScoped<ITokenService, TokenService>()
    .AddScoped<IEmailService, EmailService>()
    .AddScoped<IRegisterService, RegisterService>()
    .AddScoped<IJobService, JobService>()
    .AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MigrateDatabase();

app.Run();

