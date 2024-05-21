using System.Text.Json;
using System.Text.Json.Serialization;
using SO.Integration.API.Domain.Input;
using SO.Integration.API.Domain.Input.Extensions;
using SO.Integration.API.Domain.Output;
using Address = SO.Integration.API.Domain.Output.Address;

namespace SO.Integration.API.Services.Implementations;

public class TransformSalesOrder : ITransformSalesOrder
{
	public OutputRoot TransformInputToOutput(SalesOrderRequestRoot input)
	{
		// Transform the lines
		List<Line> outputLines = [];
		var inputLines = input.SalesOrderRequest.SalesOrder.OrderLines;
		outputLines.AddRange(inputLines.Select(line => line.ToOutputLine()));

		// Transform the addresses
		List<Address> outputAddresses = [];
		var inputAddresses = input.SalesOrderRequest.SalesOrder.Addresses;
		outputAddresses.AddRange(inputAddresses.Select(address => address.ToOutputAddress()));

		// Transform the sales order
		var outputOrder = input.SalesOrderRequest.SalesOrder.ToOutputOrder();
		outputOrder.Addresses = outputAddresses;
		outputOrder.Lines = outputLines;

		return new OutputRoot
		{
			Order = outputOrder
		};
	}

	public JsonSerializerOptions Options { get; } = new()
	{
		WriteIndented = true,
		DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
	};
}