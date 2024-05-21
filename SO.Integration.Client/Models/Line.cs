using System.Text.Json.Serialization;

namespace SO.Integration.Client.Models;

public class Line
{
	[JsonPropertyName("sku")]
	public required string Sku { get; set; }

	[JsonPropertyName("qty")]
	public int Qty { get; set; }

	[JsonPropertyName("desc")]
	public required string Desc { get; set; }

	internal static Line Create(string sku, int qty, string desc)
	{
		return new Line()
		{
			Sku = sku,
			Qty = qty,
			Desc = desc
		};
	}
}