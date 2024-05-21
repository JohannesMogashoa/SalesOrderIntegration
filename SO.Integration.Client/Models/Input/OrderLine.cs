using System.Text.Json.Serialization;

namespace SO.Integration.Client.Models.Input;

public class OrderLine
{
	[JsonPropertyName("skuCode")]
	public required string SkuCode { get; set; }

	[JsonPropertyName("quantity")]
	public int Quantity { get; set; }

	[JsonPropertyName("description")]
	public required string Description { get; set; }

	public static OrderLine Create(
		string skuCode,
		int quantity,
		string description)
	{
		return new OrderLine
		{
			SkuCode = skuCode,
			Quantity = quantity,
			Description = description
		};
	}
}