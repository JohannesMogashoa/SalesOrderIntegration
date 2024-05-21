using SO.Integration.API.Domain.Output;

namespace SO.Integration.API.Domain.Input.Extensions;
using OutputAddress = Output.Address;

public static class InputExtensions
{
	public static Order ToOutputOrder(this SalesOrder salesOrder)
	{
		return new Order
		{
			OrderRef = salesOrder.SalesOrderRef,
			OrderDate = salesOrder.OrderDate,
			Currency = salesOrder.Currency,
			ShipDate = salesOrder.ShipDate,
			CategoryCode = salesOrder.CategoryCode,
			Addresses = [],
			Lines = []
		};
	}

	public static OutputAddress ToOutputAddress(this Address address)
	{
		return OutputAddress.Create(
			addressType: address.AddressType == "BillTo" ? "BY" : "ST",
			locationNumber: address.LocationNumber,
			contactName: address.ContactName,
			lastName: address.LastName,
			companyName: address.CompanyName,
			addressLine1: address.AddressLine1,
			addressCity: address.City,
			addressState: address.State,
			postcode: address.Postcode,
			countryCode: address.CountryCode,
			phoneNumber: address.PhoneNumber,
			emailAddress: address.EmailAddress);
	}

	public static Line ToOutputLine(this OrderLine orderLine)
	{
		return Line.Create(
			sku: orderLine.SkuCode,
			qty: orderLine.Quantity,
			desc: orderLine.Description);
	}
}