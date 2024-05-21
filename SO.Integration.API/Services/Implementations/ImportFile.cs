using System.Text.Json;
using SO.Integration.API.Domain.Exceptions;
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
			throw new DeserializeFailureException(file.FileName);

		if(salesOrderRequest.SalesOrderRequest == null)
			throw new DeserializeFailureException(file.FileName);

		return salesOrderRequest;
	}
}