using Microsoft.AspNetCore.Components.Forms;

namespace SO.Integration.Client.Services;

public interface IFileTransformerHttpClient
{
	Task<HttpResponseMessage> TransformFileAsync(IBrowserFile file);
}