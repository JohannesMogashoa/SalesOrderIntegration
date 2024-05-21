using SO.Integration.API.Filters;
using SO.Integration.API.Services;
using SO.Integration.API.Services.Implementations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers(options =>
{
	options.Filters.Add<ExceptionFilter>();
});
builder.Services.AddScoped<ITransformSalesOrder, TransformSalesOrder>();
builder.Services.AddScoped<IImportFile, ImportFile>();

builder.Services.AddCors(options =>
{
	options.AddDefaultPolicy(policy =>
	{
		policy.WithOrigins("https://localhost:7006")
			.WithMethods("POST")
			.WithHeaders("Content-Type");

	});
});

var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.UseCors();

app.Run();