using System.Text.Json.Serialization;

namespace SO.Integration.Client.Models;

public class Order
{
	[JsonPropertyName("orderRef")]
	public required string OrderRef { get; set; }

	[JsonPropertyName("orderDate")]
	public required string OrderDate { get; set; }

	[JsonPropertyName("currency")]
	public required string Currency { get; set; }

	[JsonPropertyName("shipDate")]
	public required string ShipDate { get; set; }

	[JsonPropertyName("categoryCode")]
	public required string CategoryCode { get; set; }

	[JsonPropertyName("addresses")]
	public List<Address> Addresses { get; set; } = new();

	[JsonPropertyName("lines")]
	public List<Line> Lines { get; set; } = new();

	internal static Order Create(
		string orderRef,
		string orderDate,
		string currency,
		string shipDate,
		string categoryCode,
		List<Address> addresses,
		List<Line> lines)
	{
		return new Order
		{
			OrderRef = orderRef,
			OrderDate = orderDate,
			Currency = currency,
			ShipDate = shipDate,
			CategoryCode = categoryCode,
			Addresses = addresses,
			Lines = lines
		};
	}
}