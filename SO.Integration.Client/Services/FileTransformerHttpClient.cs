using System.Net.Http.Headers;
using Microsoft.AspNetCore.Components.Forms;

namespace SO.Integration.Client.Services;

public class FileTransformerHttpClient(HttpClient httpClient) : IFileTransformerHttpClient
{
	public async Task<HttpResponseMessage> TransformFileAsync(IBrowserFile file)
	{
		using var content = new MultipartFormDataContent();
		var fileContent = new StreamContent(file.OpenReadStream());
		fileContent.Headers.ContentType = new MediaTypeHeaderValue(file.ContentType);
		content.Add(content: fileContent, name: "file", fileName: file.Name);

		var response = await httpClient.PostAsync("api/upload/", content);
		return response;
	}
}