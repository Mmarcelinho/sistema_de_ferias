using SistemaDeFerias.Domain.Entidades;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRouting(option => option.LowercaseUrls = true);

builder.Services.AddHttpContextAccessor();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
# region Swagger 
builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "SISTEMA DE FERIAS API", Version = "1.0"});
    option.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
        Scheme = "Bearer",
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Description = "JWT Authorization header utilizando o Bearer scheme. Example: \"Authorization: Bearer {token}\""
    });
    option.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
    {
        {
            new Microsoft.OpenApi.Models.OpenApiSecurityScheme
            {
                Reference = new Microsoft.OpenApi.Models.OpenApiReference
                {
                    Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            System.Array.Empty<string>()
        }
    });
});
# endregion
builder.Services.AdicionarInfrastructure(builder.Configuration);
builder.Services.AdicionarApplication(builder.Configuration);

builder.Services.AddMvc(options => options.Filters.Add(typeof(FiltroDasExceptions)));

builder.Services.AddAutoMapper(typeof(AutoMapperConfiguracao));

builder.Services.AddScoped<UsuarioAutenticadoAttribute<Admin>>();
builder.Services.AddScoped<UsuarioAutenticadoAttribute<Funcionario>>();

builder.Services.AddHealthChecks().AddDbContextCheck<SistemaDeFeriasContext>();

var app = builder.Build();

app.MapHealthChecks("health", new HealthCheckOptions
{
    AllowCachingResponses = false,
    ResultStatusCodes = 
    {
        [HealthStatus.Healthy] = StatusCodes.Status200OK,
        [HealthStatus.Unhealthy] = StatusCodes.Status503ServiceUnavailable
    }
});

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

AtualizarBaseDeDados();

app.Run();

void AtualizarBaseDeDados()
{
    using var serviceScope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope();

    using var context = serviceScope.ServiceProvider.GetService<SistemaDeFeriasContext>();

    context.Database.Migrate();
}