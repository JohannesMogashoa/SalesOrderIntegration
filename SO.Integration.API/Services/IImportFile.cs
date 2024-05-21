using SO.Integration.API.Domain.Input;
using SO.Integration.API.Domain.Output;

namespace SO.Integration.API.Services;

public interface IImportFile
{
	Task<SalesOrderRequestRoot> ImportInputFileAsync(IFormFile file);
}