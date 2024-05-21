using System.Text.Json.Serialization;

namespace SO.Integration.API.Domain.Output;

public class Address
{
    [JsonPropertyName("addressType")]
    public required string AddressType { get; set; }

    [JsonPropertyName("locationNumber")]
    public int LocationNumber { get; set; }

    [JsonPropertyName("contactName")]
    public required string ContactName { get; set; }

    [JsonPropertyName("lastName")]
    public required string LastName { get; set; }

    [JsonPropertyName("companyName")]
    public required string CompanyName { get; set; }

    [JsonPropertyName("addressLine1")]
    public required string AddressLine1 { get; set; }

    [JsonPropertyName("addressCity")]
    public required string AddressCity { get; set; }

    [JsonPropertyName("addressState")]
    public required string AddressState { get; set; }

    [JsonPropertyName("postcode")]
    public int Postcode { get; set; }

    [JsonPropertyName("countryCode")]
    public required string CountryCode { get; set; }

    [JsonPropertyName("phoneNumber")]
    public string? PhoneNumber { get; set; }

    [JsonPropertyName("emailAddress")]
    public string? EmailAddress { get; set; }

    internal static Address Create(
        string addressType,
        int locationNumber,
        string contactName,
        string lastName,
        string companyName,
        string addressLine1,
        string addressCity,
        string addressState,
        int postcode,
        string countryCode,
        string? phoneNumber,
        string? emailAddress)
    {
        return new Address()
        {
            AddressType = addressType,
            LocationNumber = locationNumber,
            ContactName = contactName,
            LastName = lastName,
            CompanyName = companyName,
            AddressLine1 = addressLine1,
            AddressCity = addressCity,
            AddressState = addressState,
            Postcode = postcode,
            CountryCode = countryCode,
            PhoneNumber = phoneNumber,
            EmailAddress = emailAddress
        };
    }
}