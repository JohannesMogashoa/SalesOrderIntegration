namespace SO.Integration.Client.Models;

public class ErrorModel
{
	public int StatusCode { get; set; }
	public string? Message { get; set; }
	public string? Details { get; set; }
}