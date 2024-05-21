using System.Text.Json;
using SO.Integration.API.Domain.Input;
using SO.Integration.API.Domain.Output;

namespace SO.Integration.API.Services;

public interface ITransformSalesOrder
{
	OutputRoot TransformInputToOutput(SalesOrderRequestRoot input);
	JsonSerializerOptions Options { get; }
}