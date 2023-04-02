var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app
    .MapGet("api/welcome", () =>
    {
        var username = $"{Environment.UserDomainName}/{Environment.UserName}";
        var tunnelUrl = Environment.GetEnvironmentVariable("VS_TUNNEL_URL");
        return string.IsNullOrWhiteSpace(tunnelUrl)
        ? $"Welcome [{username}] on Localhost"
        : $"Welcome [{username}] on DevTunnel";
    })
    .WithName("SayWelcome");

app.Run();