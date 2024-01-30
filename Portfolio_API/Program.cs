var builder = WebApplication.CreateBuilder(args);

string? jwtSecret = builder.Configuration.GetValue<string>("JwtSecret");
string? dbStringConnection = builder.Configuration.GetValue<string>("DbContext");
if(jwtSecret is null || dbStringConnection is null){
    throw new ArgumentNullException("Some env variable is null. Check your configuration");
}

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();

