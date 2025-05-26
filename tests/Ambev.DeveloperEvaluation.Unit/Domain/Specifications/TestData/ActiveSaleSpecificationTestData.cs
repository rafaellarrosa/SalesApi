using Ambev.DeveloperEvaluation.Domain.Entities;
using Bogus;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Specifications.TestData;

/// <summary>
/// Provides methods for generating test data for ActiveSaleSpecification tests.
/// This class centralizes all test data generation to ensure consistency.
/// </summary>
public static class ActiveSaleSpecificationTestData
{
    /// <summary>
    /// Configures the Faker to generate valid Sale entities.
    /// </summary>
    private static readonly Faker<Sale> SaleFaker = new Faker<Sale>()
        .RuleFor(s => s.SaleNumber, f => f.Random.AlphaNumeric(8).ToUpper())
        .RuleFor(s => s.Customer, f => f.Company.CompanyName())
        .RuleFor(s => s.Branch, f => f.Address.City())
        .RuleFor(s => s.IsCancelled, f => f.Random.Bool())
        .RuleFor(s => s.SaleDate, f => f.Date.Recent());

    /// <summary>
    /// Generates a Sale with the specified IsCancelled status.
    /// </summary>
    /// <param name="isCancelled">True to generate a cancelled sale; false otherwise.</param>
    /// <returns>A Sale entity with the specified cancellation status.</returns>
    public static Sale GenerateSale(bool isCancelled)
    {
        var sale = SaleFaker.Generate();
        if (isCancelled) sale.Cancel();
        return sale;
    }
}