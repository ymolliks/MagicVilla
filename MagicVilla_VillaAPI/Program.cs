using MagicVilla_VillaAPI.Data;
using MagicVilla_VillaAPI.Services;
using MagicVilla_VillaAPI.Repositories;
using MagicVilla_VillaAPI;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IDapperDbContext, DapperDbContext>();
builder.Services.AddScoped<IVillaService, VillaService>();
builder.Services.AddScoped<IVillaRepository, VillaRepository>();
builder.Services.AddAutoMapper(typeof(MappingConfig));
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();