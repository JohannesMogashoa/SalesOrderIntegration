using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using SO.Integration.API.Services;

namespace SO.Integration.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UploadController(IImportFile importFile, ITransformSalesOrder salesOrderTransformer) : Controller
{
	[HttpPost("input")]
	public async Task<IActionResult> Upload([FromForm] IFormFile file)
	{
		var salesOrderRequest = await importFile.ImportInputFileAsync(file);
		var outputRoot = salesOrderTransformer.TransformInputToOutput(salesOrderRequest);

		var byteArray = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(outputRoot, salesOrderTransformer.Options));
		MemoryStream stream = new(byteArray);
		const string fileName = "output.json";

		// Return the file as a downloadable file with proper headers
		var contentDispositionHeader = new System.Net.Mime.ContentDisposition
		{
			FileName = fileName,
			Inline = false // false = prompt the user for downloading; true = browser to try to show the file inline
		};

		Response.Headers.Append("Content-Disposition", contentDispositionHeader.ToString());

		return File(byteArray, "application/json");
	}

	[HttpPost("output")]
	public async Task<IActionResult> UploadOutput(IFormFile file)
	{
		var output = await importFile.ImportOutputFileAsync(file);
		return Json(new
		{
			data = output
		});
	}
}