using Autofac;
using Autofac.Extensions.DependencyInjection;
using Dogat_backend_net_core.Config;

var builder = WebApplication.CreateBuilder(args);

string _MyCors = "miCors";


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

// Register services directly with Autofac here. Don't
// call builder.Populate(), that happens in AutofacServiceProviderFactory.
builder.Host.ConfigureContainer<ContainerBuilder>(builder => builder.RegisterModule(new PublicacionesModule()));

builder.Host.ConfigureServices(services =>
{
    services.AddCors(OptionsBuilderConfigurationExtensions =>
    {
        OptionsBuilderConfigurationExtensions.AddPolicy(name: _MyCors, builder =>
        {
            builder.SetIsOriginAllowed(origin => new Uri(origin).Host == "localhost").AllowAnyHeader().AllowAnyMethod();
        });
    }
    );
});


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

app.UseCors(_MyCors);

app.Run();
