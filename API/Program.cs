using API.EndPoints;
using Services;
using Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Planificador API", Version = "v1" });
});
builder.Services.AddDbContext<TPIContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowBlazorWasm",
        policy =>
        {
            policy.WithOrigins("https://localhost:7170", "http://localhost:5076")
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

builder.Services.AddScoped<CategoriaGastoRepository>();
builder.Services.AddScoped<CategoriaGastoService>();
builder.Services.AddScoped<GastoRepository>();
builder.Services.AddScoped<GastoService>();
builder.Services.AddScoped<GrupoRepository>();
builder.Services.AddScoped<GrupoService>();
builder.Services.AddScoped<PlanRepository>();
builder.Services.AddScoped<PlanService>();
builder.Services.AddScoped<TareaRepository>();
builder.Services.AddScoped<TareaService>();
builder.Services.AddScoped<UsuarioRepository>();
builder.Services.AddScoped<UsuarioService>();
builder.Services.AddScoped<UsuarioGrupoRepository>();
builder.Services.AddScoped<UsuarioGrupoService>();    

var app = builder.Build();

// Crear DB si es necesario
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<TPIContext>();
    // ELIMINAR Y RECREAR la base de datos (solo desarrollo)
    //context.Database.EnsureDeleted(); // Elimina la base de datos existente
    context.Database.EnsureCreated(); // Crea una nueva

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();
    app.UseCors("AllowBlazorWasm");

    // Map endpoints
    app.MapGet("/", () => Results.Redirect("/swagger/"));
    app.MapUsuarioEndPoints();
    app.MapCategoriaGastosEndpoints();
    app.MapTareaEndPoints();
    app.MapGastoEndPoints();
    app.MapGrupoEndPoints();
    app.MapPlanEndPoints();
    app.MapUsuarioGrupoEndPoints();

    app.Run();

}