// convert to CQRS & MediatR
// https://chatgpt.com/c/67f8f451-e8f0-8010-b9dc-20d6d7cea9ba
// https://claude.ai/chat/72c2af3b-80f8-43e2-8bd6-6fd5e18b5200

using BookManagement.API.Extensions;
using BookManagement.API.Middleware;
using BookManagement.Core.Interfaces;
using BookManagement.Infrastructure.Data;
using BookManagement.Infrastructure.Repositories;
using BookManagement.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerServices();

builder.Services.AddDbContext<BookManagementDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddJwtServices(builder.Configuration);

builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IJwtTokenService, JwtTokenService>();

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader());
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowAll");

app.UseAuthentication();
app.UseAuthorization();

app.UseExceptionHandler();
app.MapControllers();

app.Run();