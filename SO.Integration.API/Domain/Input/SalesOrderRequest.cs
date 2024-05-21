using System.Text.Json.Serialization;

namespace SO.Integration.API.Domain.Input;

public class SalesOrderRequestRoot()
{
	[JsonPropertyName("SalesOrderRequest")]
	public SalesOrderRequest SalesOrderRequest { get; set; }
}

public class SalesOrderRequest()
{
	[JsonPropertyName("SalesOrder")]
	public SalesOrder SalesOrder { get; set; }

	internal static SalesOrderRequest Create(SalesOrder salesOrder)
	{
		return new SalesOrderRequest
		{
			SalesOrder = salesOrder
		};
	}
}