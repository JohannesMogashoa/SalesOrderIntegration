using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;
using MudBlazor;
using SO.Integration.Client.Models.Input;
using SO.Integration.Client.Models.Output;

namespace SO.Integration.Client.Pages;

public partial class Home
{
	private readonly List<IBrowserFile> _files = [];
	private string? OutputJson { get; set; }
	private string? InputJson { get; set; }
	private string FileName { get; set; } = "transformed-file.json";

	private readonly JsonSerializerOptions _jsonSerializerOptions = new() { WriteIndented = true };

	private async void UploadFiles(IBrowserFile file)
	{
		_files.Add(file);
		ReadInputFile(file);

		var response = await FileTransformerHttpClient.TransformFileAsync(file);

		if (!response.IsSuccessStatusCode)
		{
			Snackbar.Add("Failed to upload file", Severity.Error);
			return;
		}

		var salesOrder = await response.Content.ReadFromJsonAsync<OutputRoot>();

		if(salesOrder == null)
		{
			Snackbar.Add("Failed to read response from server", Severity.Error);
			return;
		}

		OutputJson = JsonSerializer.Serialize(salesOrder, _jsonSerializerOptions);
		FileName = $"{salesOrder.Order.OrderRef}-{salesOrder.Order.CategoryCode}-{DateTime.Now.ToShortDateString()}.json";

		StateHasChanged();
	}

	private async void ReadInputFile(IBrowserFile file)
	{
		using var reader = new StreamReader(file.OpenReadStream());
		var content = await reader.ReadToEndAsync();

		var salesOrderRequest = JsonSerializer.Deserialize<SalesOrderRequestRoot>(content);

		if(salesOrderRequest?.SalesOrderRequest == null)
		{
			Snackbar.Add("Failed to read response from server", Severity.Error);
			return;
		}

		InputJson = JsonSerializer.Serialize(salesOrderRequest, _jsonSerializerOptions);
	}

	private async Task DownloadFileFromStream()
	{
		if(OutputJson == null)
		{
			Snackbar.Add("Failed to download file, please re-upload", Severity.Error);
			return;
		}

		var stream = new MemoryStream(Encoding.UTF8.GetBytes(OutputJson));

		using var streamRef = new DotNetStreamReference(stream);

		await JS.InvokeVoidAsync("downloadFileFromStream", FileName, streamRef);

		StateHasChanged();
	}

	private void ClearContext()
	{
		OutputJson = null;
		InputJson = null;
		_files.Clear();
	}
}