using Autofac;
using Autofac.Extensions.DependencyInjection;
using Business.Abstract;
using Business.Concrete;
using Business.DependencyResolvers.Autofac;
using DataAccess.Abstract;
using DataAccess.Concrete;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

// Call ConfigureContainer on the Host sub property 
builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
{
    builder.RegisterModule(new AutofacBusinessModule());
});

//builder.Services.AddSingleton<IEmployeeService, EmployeeManager>();
//builder.Services.AddSingleton<IEmployeeDal, EmployeeDal>();

//builder.Services.AddSingleton<IPositionService, PositionManager>();
//builder.Services.AddSingleton<IPositionDal, PositionDal>();

//builder.Services.AddSingleton<IDepartmenService, DepartmentManager>();
//builder.Services.AddSingleton<IDepartmentDal, DepartmentDal>();

//builder.Services.AddSingleton<IAnnouncementService, AnnouncementManager>();
//builder.Services.AddSingleton<IAnnouncementDal, AnnouncementDal>();

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
