using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities;

/// <summary>
/// Contains unit tests for the Sale entity class.
/// Tests cover cancellation behavior and validation scenarios.
/// </summary>
public class SaleTests
{
    /// <summary>
    /// Tests that a sale can be cancelled successfully.
    /// </summary>
    [Fact(DisplayName = "Sale should be marked as cancelled when cancelling")]
    public void Given_ValidSale_When_Cancelling_Then_IsCancelledShouldBeTrue()
    {
        // Arrange
        var sale = SaleTestData.GenerateValidSale();

        // Act
        sale.Cancel();

        // Assert
        Assert.True(sale.IsCancelled);
    }

    /// <summary>
    /// Tests that cancelling an already cancelled sale throws an exception.
    /// </summary>
    [Fact(DisplayName = "Cancelling an already cancelled sale should throw exception")]
    public void Given_CancelledSale_When_CancellingAgain_Then_ThrowsException()
    {
        // Arrange
        var sale = SaleTestData.GenerateValidSale();
        sale.Cancel();

        // Act
        void act() => sale.Cancel();

        // Assert
        var exception = Assert.Throws<InvalidOperationException>(act);
        Assert.Equal("Sale is already cancelled.", exception.Message);
    }

    /// <summary>
    /// Tests that validation passes when all sale properties are valid.
    /// </summary>
    [Fact(DisplayName = "Validation should pass for valid sale data")]
    public void Given_ValidSaleData_When_Validated_Then_ShouldReturnValid()
    {
        // Arrange
        var sale = SaleTestData.GenerateValidSale();

        // Act
        var result = sale.Validate();

        // Assert
        Assert.True(result.IsValid);
        Assert.Empty(result.Errors);
    }

    /// <summary>
    /// Tests that validation fails when sale properties are invalid.
    /// </summary>
    [Fact(DisplayName = "Validation should fail for invalid sale data")]
    public void Given_InvalidSaleData_When_Validated_Then_ShouldReturnInvalid()
    {
        // Arrange
        var sale = new Sale
        {
            Customer = "", // Invalid: empty
            Branch = "",   // Invalid: empty
            Items = new List<SaleItem>() // Invalid: no items
        };

        // Act
        var result = sale.Validate();

        // Assert
        Assert.False(result.IsValid);
        Assert.NotEmpty(result.Errors);
    }
}
