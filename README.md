# Solution Overview

This solution is a C# project that involves file upload, transformation, and download. It uses the .NET 8 framework 
and the MudBlazor library for the front-end. The solution is divided into two main parts: the client and the API.

## Client

The client is a Blazor WebAssembly application. It provides a user interface for uploading a file, displaying the 
transformed content, and downloading the transformed file. The main functionality is in the `Home` component, which is 
located in `SO.Integration.Client/Pages/Home.razor` and `SO.Integration.Client/Pages/Home.razor.cs`.

The `Home` component has the following main methods:

- `UploadFiles`: This method is responsible for uploading the file, sending it to the API for transformation, and 
displaying the transformed content.
- `ReadInputFile`: This method reads the uploaded file and displays its content.
- `DownloadFileFromStream`: This method allows the user to download the transformed file.

## API

The API is a .NET 8 Web API application. It provides an endpoint for uploading and transforming the file. The main 
functionality is in the `UploadController`, which is located in `SO.Integration.API/Controllers/UploadController.cs`.

The `UploadController` has the following main method:

- `Upload`: This method is responsible for receiving the uploaded file, transforming it, and returning the transformed 
content as a downloadable file.

# How to Run the Solution

To run the solution, you need to have .NET 8 SDK installed on your machine. 
You can download it from the [official .NET website](https://dotnet.microsoft.com/download).

Once you have .NET 8 SDK installed, you can run the solution using the following steps:

**Option 1: Using Visual Studio**
1. Open the solution file `SO.Integration.sln` in Visual Studio.
2. Configure a multiple startup project, with the `SO.Integration.API` and `SO.Integration.Client` projects set to start.
3. Press `F5` to run the solution.
4. The client application will open in a web browser at `https://localhost:7006`.

**Option 2: Using the Command Line**
1. Open a terminal window.
2. Navigate to the root directory of the solution.
3. Run the API by navigating to the `SO.Integration.API` directory and running the command `dotnet run`.
4. In a new terminal window, run the client by navigating to the `SO.Integration.Client` directory and running the command `dotnet run`.
5. Open a web browser and navigate to `https://localhost:7006` to see the client application.