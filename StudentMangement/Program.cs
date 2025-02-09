using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StudentMangement.Configurations;
using StudentMangement.Data;
using StudentMangement.Repository.Implementation;
using StudentMangement.Repository.Interface;
using StudentMangement.Services.Implementation;
using StudentMangement.Services.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
string connection = builder.Configuration.GetConnectionString("DBConnection")!;
builder.Services.AddDbContext<ApplicationDbContext>((b) => b.UseSqlServer(connection));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<ICourseService, CourseService>();

var mappingConfig = new MapperConfiguration(mc =>
           {
               mc.AddProfile(new MappingProfile());
           });
IMapper mapper = mappingConfig.CreateMapper();


builder.Services.AddSingleton(mapper);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors((x) => x.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
