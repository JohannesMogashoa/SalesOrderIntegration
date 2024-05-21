using System.Text.Json.Serialization;

namespace SO.Integration.Client.Models;

public class OutputRoot()
{
	[JsonPropertyName("order")]
	public Order Order { get; set; }
}