using System.Text.Json.Serialization;

namespace SO.Integration.Client.Models.Input;

public class SalesOrder
{
	[JsonPropertyName("salesOrderRef")]
	public required string SalesOrderRef { get; set; }

	[JsonPropertyName("orderDate")]
	public required string OrderDate { get; set; }

	[JsonPropertyName("currency")]
	public required string Currency { get; set; }

	[JsonPropertyName("shipDate")]
	public required string ShipDate { get; set; }

	[JsonPropertyName("categoryCode")]
	public required string CategoryCode { get; set; }

	[JsonPropertyName("addresses")]
	public List<Address> Addresses { get; set; } = [];

	[JsonPropertyName("orderLines")]
	public List<OrderLine> OrderLines { get; set; } = [];

	public static SalesOrder Create(
		string salesOrderRef,
		string orderDate,
		string currency,
		string shipDate,
		string categoryCode,
		List<Address> addresses,
		List<OrderLine> orderLines)
	{
		return new SalesOrder
		{
			SalesOrderRef = salesOrderRef,
			OrderDate = orderDate,
			Currency = currency,
			ShipDate = shipDate,
			CategoryCode = categoryCode,
			Addresses = addresses,
			OrderLines = orderLines
		};
	}
}