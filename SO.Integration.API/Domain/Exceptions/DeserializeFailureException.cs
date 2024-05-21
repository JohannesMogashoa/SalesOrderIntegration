namespace SO.Integration.API.Domain.Exceptions;

public class DeserializeFailureException(string filename) : Exception($"Failed to deserialize file {filename}.");