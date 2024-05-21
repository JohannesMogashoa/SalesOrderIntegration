using System.Text.Json.Serialization;

namespace SO.Integration.API.Domain.Output;

public class OutputRoot()
{
	[JsonPropertyName("order")]
	public Order Order { get; set; }
}