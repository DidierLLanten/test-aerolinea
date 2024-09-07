using Microsoft.EntityFrameworkCore;
using WebApiAerolinea.Context;
using WebApiAerolinea.Mapper;
using WebApiAerolinea.Repositories;
using WebApiAerolinea.Repositories.Interfaces;
using WebApiAerolinea.Services;
using WebApiAerolinea.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(
    options => options.UseSqlServer(connectionString)
);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddAutoMapper(typeof(MappingProfile)); //Solo para el perfil específico
//builder.Services.AddAutoMapper(typeof(Program)); //Buscará perfiles en el ensamblado que contiene la clase Program
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies()); //Escaneará todos los ensamblados cargados en el dominio actual en busca de perfiles

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IUserRepository, UserRepository>();


builder.Services.AddScoped(typeof(IGenericService<>), typeof(GenericService<>));
builder.Services.AddScoped<IUserService, UserService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
