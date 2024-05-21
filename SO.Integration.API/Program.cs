using SO.Integration.API.Domain.Input;
using SO.Integration.API.Services;
using SO.Integration.API.Services.Implementations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddScoped<ITransformSalesOrder, TransformSalesOrder>();
builder.Services.AddScoped<IImportFile, ImportFile>();

builder.Services.AddCors(options =>
{
	options.AddDefaultPolicy(policy =>
	{
		policy.AllowAnyOrigin()
			.AllowAnyMethod()
			.AllowAnyHeader();
	});
});

var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.UseCors();

app.Run();