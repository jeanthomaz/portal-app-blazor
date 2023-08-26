using Persistence;

var builder = WebApplication.CreateBuilder(args);

// Injeta dependências (serviços)
builder.Services.AddDbContext<ApplicationDbContext>();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();