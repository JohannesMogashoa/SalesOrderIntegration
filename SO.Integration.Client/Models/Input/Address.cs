using System.Text.Json.Serialization;

namespace SO.Integration.Client.Models.Input;

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

    [JsonPropertyName("city")]
    public required string City { get; set; }

    [JsonPropertyName("state")]
    public required string State { get; set; }

    [JsonPropertyName("postcode")]
    public int Postcode { get; set; }

    [JsonPropertyName("countryCode")]
    public required string CountryCode { get; set; }

    [JsonPropertyName("phoneNumber")]
    public string? PhoneNumber { get; set; }

    [JsonPropertyName("emailAddress")]
    public string? EmailAddress { get; set; }

    [JsonPropertyName("locationNumberQualifier")]
    public string? LocationNumberQualifier { get; set; }

    public static Address Create(
        string addressType,
        int locationNumber,
        string contactName,
        string lastName,
        string companyName,
        string addressLine1,
        string city,
        string state,
        int postcode,
        string countryCode,
        string phoneNumber,
        string emailAddress,
        string locationNumberQualifier)
    {
        return new Address
        {
            AddressType = addressType,
            LocationNumber = locationNumber,
            ContactName = contactName,
            LastName = lastName,
            CompanyName = companyName,
            AddressLine1 = addressLine1,
            City = city,
            State = state,
            Postcode = postcode,
            CountryCode = countryCode,
            PhoneNumber = phoneNumber,
            EmailAddress = emailAddress,
            LocationNumberQualifier = locationNumberQualifier
        };
    }
}