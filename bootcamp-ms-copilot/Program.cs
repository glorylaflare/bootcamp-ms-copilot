// Programa principal da aplicação ASP.NET Core para validação de bandeira de cartão de crédito.
//
// Explicação dos principais métodos e configurações:
//
// - WebApplication.CreateBuilder(args): Inicializa o builder da aplicação, responsável por configurar serviços e middlewares.
// - builder.Services.AddControllers(): Adiciona o suporte a controllers (API REST).
// - builder.Services.AddEndpointsApiExplorer(): Necessário para geração de documentação Swagger.
// - builder.Services.AddSwaggerGen(...): Configura o Swagger para gerar documentação interativa da API.
// - builder.Services.AddCors(...): Configura a política de CORS, permitindo que o frontend acesse a API de qualquer origem.
// - builder.Build(): Cria a aplicação baseada nas configurações anteriores.
// - app.UseSwagger(): Habilita a geração do documento Swagger (apenas em desenvolvimento).
// - app.UseSwaggerUI(): Habilita a interface web do Swagger para testar a API (apenas em desenvolvimento).
// - app.UseCors(...): Aplica a política de CORS definida anteriormente.
// - app.UseAuthorization(): Habilita o middleware de autorização (caso necessário no futuro).
// - app.MapControllers(): Mapeia os endpoints dos controllers para as rotas da API.
// - app.Run(): Inicia a aplicação.

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure CORS to allow frontend access
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowFrontend");
app.UseAuthorization();
app.MapControllers();

// Serve static files from wwwroot
app.UseStaticFiles();

// Fallback to serve index.html for SPA
app.MapFallbackToFile("index.html");

app.Run();