using System.Text.Json;
using SO.Integration.API.Domain.Input;
using SO.Integration.API.Domain.Output;

namespace SO.Integration.API.Services.Implementations;

public class ImportFile : IImportFile
{
	public async Task<SalesOrderRequestRoot> ImportInputFileAsync(IFormFile file)
	{
		using var reader = new StreamReader(file.OpenReadStream());
		var content = await reader.ReadToEndAsync();

		var salesOrderRequest = JsonSerializer.Deserialize<SalesOrderRequestRoot>(content);

		if (salesOrderRequest == null)
			throw new Exception("Invalid file format.");

		return salesOrderRequest;
	}

	public async Task<OutputRoot> ImportOutputFileAsync(IFormFile file)
	{
		using var reader = new StreamReader(file.OpenReadStream());
		var content = await reader.ReadToEndAsync();

		var output = JsonSerializer.Deserialize<OutputRoot>(content);

		if (output == null)
			throw new Exception("Invalid file format.");

		return output;
	}
}