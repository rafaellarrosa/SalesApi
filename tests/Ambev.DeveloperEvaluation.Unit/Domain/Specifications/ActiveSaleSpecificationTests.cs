using Ambev.DeveloperEvaluation.Domain.Specifications;
using Ambev.DeveloperEvaluation.Unit.Domain.Specifications.TestData;
using FluentAssertions;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Specifications;

/// <summary>
/// Contains unit tests for the <see cref="ActiveSaleSpecification"/> class.
/// Tests verify if a sale is considered active or cancelled.
/// </summary>
public class ActiveSaleSpecificationTests
{
    [Theory(DisplayName = "Given sale status When validating Then should return expected result")]
    [InlineData(false, true)]   // Not cancelled -> active
    [InlineData(true, false)]   // Cancelled -> not active
    public void IsSatisfiedBy_ShouldValidateSaleStatus(bool isCancelled, bool expectedResult)
    {
        // Arrange
        var sale = ActiveSaleSpecificationTestData.GenerateSale(isCancelled);
        var specification = new ActiveSaleSpecification();

        // Act
        var result = specification.IsSatisfiedBy(sale);

        // Assert
        result.Should().Be(expectedResult);
    }
}