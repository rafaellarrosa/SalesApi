using Ambev.DeveloperEvaluation.Domain.Entities;
using Bogus;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;

/// <summary>
/// Provides methods for generating test data for <see cref="Sale"/> and <see cref="SaleItem"/>.
/// This class centralizes all test data generation to ensure consistency
/// across test cases and provide both valid and invalid data scenarios.
/// </summary>
public static class SaleTestData
{
    /// <summary>
    /// Configures the Faker to generate valid Sale entities.
    /// The generated sales will have:
    /// - SaleNumber (random alphanumeric)
    /// - Customer (company name)
    /// - Branch (city name)
    /// - SaleDate (current date)
    /// - Items (at least one valid item)
    /// </summary>
    private static readonly Faker<Sale> SaleFaker = new Faker<Sale>()
        .RuleFor(s => s.SaleNumber, f => f.Random.AlphaNumeric(8).ToUpper())
        .RuleFor(s => s.Customer, f => f.Company.CompanyName())
        .RuleFor(s => s.Branch, f => f.Address.City())
        .RuleFor(s => s.SaleDate, f => f.Date.Recent())
        .RuleFor(s => s.Items, f => new List<SaleItem> { GenerateValidSaleItem() });

    /// <summary>
    /// Configures the Faker to generate valid SaleItem entities.
    /// The generated items will have:
    /// - ProductId (Guid)
    /// - ProductName (commerce product name)
    /// - Quantity (between 1 and 20)
    /// - UnitPrice (between 10 and 100)
    /// </summary>
    private static readonly Faker<SaleItem> SaleItemFaker = new Faker<SaleItem>()
        .RuleFor(i => i.ProductId, f => f.Random.Guid())
        .RuleFor(i => i.ProductName, f => f.Commerce.ProductName())
        .RuleFor(i => i.Quantity, f => f.Random.Int(1, 20))
        .RuleFor(i => i.UnitPrice, f => f.Random.Decimal(10, 100));

    /// <summary>
    /// Generates a valid Sale entity with randomized data.
    /// </summary>
    /// <returns>A valid Sale entity.</returns>
    public static Sale GenerateValidSale()
    {
        var sale = SaleFaker.Generate();
        foreach (var item in sale.Items)
            item.ApplyDiscount();
        return sale;
    }

    /// <summary>
    /// Generates a valid SaleItem entity with randomized data.
    /// The discount is applied based on the business rules.
    /// </summary>
    /// <returns>A valid SaleItem entity.</returns>
    public static SaleItem GenerateValidSaleItem()
    {
        var item = SaleItemFaker.Generate();
        item.ApplyDiscount();
        return item;
    }

    /// <summary>
    /// Generates a SaleItem with quantity greater than 20 to test validation errors.
    /// </summary>
    /// <returns>An invalid SaleItem entity (Quantity > 20).</returns>
    public static SaleItem GenerateInvalidSaleItemWithHighQuantity()
    {
        return new SaleItem
        {
            ProductId = Guid.NewGuid(),
            ProductName = new Faker().Commerce.ProductName(),
            Quantity = 25,
            UnitPrice = 50
        };
    }

    /// <summary>
    /// Generates a SaleItem with quantity less than 4 to test no discount scenario.
    /// </summary>
    /// <returns>A valid SaleItem entity with no discount applied.</returns>
    public static SaleItem GenerateSaleItemWithoutDiscount()
    {
        var item = new SaleItem
        {
            ProductId = Guid.NewGuid(),
            ProductName = new Faker().Commerce.ProductName(),
            Quantity = 2,
            UnitPrice = 100
        };
        item.ApplyDiscount();
        return item;
    }
}