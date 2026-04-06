using Microsoft.EntityFrameworkCore;
using Npgsql;
using ZooApi.Data;
using ZooApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Get connection string: either from Render's DATABASE_URL or local appsettings.json
var databaseUrl = Environment.GetEnvironmentVariable("DATABASE_URL");
string connectionString;

if (!string.IsNullOrEmpty(databaseUrl))
{
    // Convert DATABASE_URL to Npgsql connection string
    var npgsqlBuilder = new NpgsqlConnectionStringBuilder(databaseUrl)
    {
        SslMode = SslMode.Require,
    };
    connectionString = npgsqlBuilder.ConnectionString;
}
else
{
    // Fallback to local connection string in appsettings.json
    connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
}

// Add DbContext
builder.Services.AddDbContext<DataContext>(options =>
    options.UseNpgsql(connectionString));

// Add application services
builder.Services.AddScoped<ZooService>();

// Add controllers and OpenAPI
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApi();

// Configure CORS for local Angular frontend
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policy => policy
            .WithOrigins("http://localhost:4200")
            .AllowAnyHeader()
            .AllowAnyMethod());
});

var app = builder.Build();

// Configure HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseCors("AllowFrontend");
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

// Automatically apply migrations and seed database
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<DataContext>();
    db.Database.Migrate();
    DbSeeder.Seed(db);
}

app.Run();