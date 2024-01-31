using Microsoft.AspNetCore.Identity;
using Portfolio_API;

var builder = WebApplication.CreateBuilder(args);

string? jwtSecret = builder.Configuration.GetValue<string>("JwtSecret");
string? dbStringConnection = builder.Configuration.GetValue<string>("DbContext");
if(jwtSecret is null || dbStringConnection is null){
    throw new ArgumentNullException("Some env variable is null. Check your configuration");
}

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddIdentity<IdentityUser<int>, IdentityRole<int>>()
    .AddEntityFrameworkStores<UserDbContext>()
    .AddDefaultTokenProviders();
builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<IRegisterService, RegisterService>();
builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MigrateDatabase();

app.Run();

