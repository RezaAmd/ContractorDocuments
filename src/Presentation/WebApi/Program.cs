var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Register all dependency services for this layer.
builder.Services.AddDependencyServices(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // Enable Swagger in development mode
    app.UseSwagger();
    app.UseSwaggerUI((options) =>
    {
        options.DocumentTitle = "Bildora API";
        options.HeadContent = "<link rel='icon' href='/favicon.ico' />";
        options.InjectStylesheet("/css/dark-swagger.min.css");
    });
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseCors(options =>
{
    options.AllowAnyHeader();
    options.AllowAnyMethod();
    options.AllowAnyOrigin();
});

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

await app.RunAsync();