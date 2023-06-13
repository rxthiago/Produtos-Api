using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using ProdutosApi.Application.Interfaces;
using ProdutosApi.Application.Services;
using ProdutosApi.Domain.Interfaces.Repositories;
using ProdutosApi.Domain.Interfaces.Services;
using ProdutosApi.Domain.Services;
using ProdutosApi.Infra.Data.Repositories;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Definindo a política de autenticação do projeto

builder.Services.AddAuthentication(
    auth =>
    {
        auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    }
    ).AddJwtBearer(bearer =>
    {
        bearer.RequireHttpsMetadata = false;
        bearer.SaveToken = true;
        bearer.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            //CHAVE SECRETA para descriptografar os TOKENS recebidos pela API
            //utilizando a mesma chave da API de usuários (compartilhar os TOKENS)
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("aeb718a2-e0be-4b95-9dcc-0f8712db6ee7")),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });

#endregion

#region Configurando o CORS

builder.Services.AddCors(cors => cors.AddPolicy("DefaultPolicy",
    builder => { builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader(); }));

#endregion

#region Configurando as injeção de dependência do projeto

builder.Services.AddTransient<ICategoriaAppService, CategoriaAppService>();
builder.Services.AddTransient<IProdutoAppService, ProdutoAppService>();

builder.Services.AddTransient<ICategoriaDomainService, CategoriaDomainService>();
builder.Services.AddTransient<IProdutoDomainService, ProdutoDomainService>();

builder.Services.AddTransient<ICategoriaRepository, CategoriaRepository>();
builder.Services.AddTransient<IProdutoRepository, ProdutoRepository>();

#endregion

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthentication();
app.UseAuthorization();

app.UseCors("DefaultPolicy");

app.MapControllers();

app.Run();
