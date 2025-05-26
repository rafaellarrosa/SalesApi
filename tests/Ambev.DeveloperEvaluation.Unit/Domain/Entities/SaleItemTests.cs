using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentAssertions;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities;

/// <summary>
/// Contains unit tests for the <see cref="SaleItem"/> entity.
/// Tests focus on discount rules and total calculation.
/// </summary>
public class SaleItemTests
{
    /// <summary>
    /// Tests that items with quantity below 4 have no discount.
    /// </summary>
    [Fact(DisplayName = "Given quantity less than 4 When applying discount Then discount should be zero")]
    public void Given_QuantityLessThan4_When_ApplyingDiscount_Then_DiscountShouldBeZero()
    {
        // Arrange
        var item = new SaleItem { Quantity = 3, UnitPrice = 100 };

        // Act
        item.ApplyDiscount();

        // Assert
        item.Discount.Should().Be(0);
        item.TotalAmount.Should().Be(300);
    }

    /// <summary>
    /// Tests that items with quantity between 4 and 9 get a 10% discount.
    /// </summary>
    [Fact(DisplayName = "Given quantity between 4 and 9 When applying discount Then should apply 10%")]
    public void Given_QuantityBetween4And9_When_ApplyingDiscount_Then_ShouldApply10Percent()
    {
        // Arrange
        var item = new SaleItem { Quantity = 5, UnitPrice = 100 };

        // Act
        item.ApplyDiscount();

        // Assert
        item.Discount.Should().Be(50);
        item.TotalAmount.Should().Be(450);
    }

    /// <summary>
    /// Tests that items with quantity between 10 and 20 get a 20% discount.
    /// </summary>
    [Fact(DisplayName = "Given quantity between 10 and 20 When applying discount Then should apply 20%")]
    public void Given_QuantityBetween10And20_When_ApplyingDiscount_Then_ShouldApply20Percent()
    {
        // Arrange
        var item = new SaleItem { Quantity = 15, UnitPrice = 100 };

        // Act
        item.ApplyDiscount();

        // Assert
        item.Discount.Should().Be(300);
        item.TotalAmount.Should().Be(1200);
    }

    /// <summary>
    /// Tests that quantity above 20 throws an exception.
    /// </summary>
    [Fact(DisplayName = "Given quantity greater than 20 When applying discount Then throws exception")]
    public void Given_QuantityGreaterThan20_When_ApplyingDiscount_Then_ThrowsException()
    {
        // Arrange
        var item = new SaleItem { Quantity = 25, UnitPrice = 100 };

        // Act
        Action act = () => item.ApplyDiscount();

        // Assert
        act.Should().Throw<InvalidOperationException>()
            .WithMessage("Cannot sell more than 20 identical items.");
    }
}
