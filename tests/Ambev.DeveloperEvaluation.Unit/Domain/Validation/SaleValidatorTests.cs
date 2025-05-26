using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Validation;
using Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;
using FluentValidation.TestHelper;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Validation;

/// <summary>
/// Contains unit tests for the <see cref="SaleValidator"/> class.
/// Tests validation of customer, branch, and items in a sale.
/// </summary>
public class SaleValidatorTests
{
    private readonly SaleValidator _validator;

    public SaleValidatorTests()
    {
        _validator = new SaleValidator();
    }

    /// <summary>
    /// Tests that validation passes when all sale properties are valid.
    /// </summary>
    [Fact(DisplayName = "Given valid sale When validating Then should pass")]
    public void Given_ValidSale_When_Validating_Then_ShouldPass()
    {
        // Arrange
        var sale = SaleTestData.GenerateValidSale();

        // Act
        var result = _validator.TestValidate(sale);

        // Assert
        result.ShouldNotHaveAnyValidationErrors();
    }

    /// <summary>
    /// Tests that an empty customer fails validation.
    /// </summary>
    [Fact(DisplayName = "Given empty customer When validating Then should fail")]
    public void Given_EmptyCustomer_When_Validating_Then_ShouldFail()
    {
        // Arrange
        var sale = SaleTestData.GenerateValidSale();
        sale.Customer = string.Empty;

        // Act
        var result = _validator.TestValidate(sale);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Customer);
    }

    /// <summary>
    /// Tests that an empty branch fails validation.
    /// </summary>
    [Fact(DisplayName = "Given empty branch When validating Then should fail")]
    public void Given_EmptyBranch_When_Validating_Then_ShouldFail()
    {
        // Arrange
        var sale = SaleTestData.GenerateValidSale();
        sale.Branch = string.Empty;

        // Act
        var result = _validator.TestValidate(sale);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Branch);
    }

    /// <summary>
    /// Tests that an empty item list fails validation.
    /// </summary>
    [Fact(DisplayName = "Given sale without items When validating Then should fail")]
    public void Given_SaleWithoutItems_When_Validating_Then_ShouldFail()
    {
        // Arrange
        var sale = SaleTestData.GenerateValidSale();
        sale.Items.Clear();

        // Act
        var result = _validator.TestValidate(sale);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Items);
    }
}
