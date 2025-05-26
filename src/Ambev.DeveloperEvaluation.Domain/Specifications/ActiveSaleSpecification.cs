using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Specifications;

/// <summary>
/// Specification to determine whether a sale is active.
/// A sale is considered active if it is not cancelled.
/// </summary>
public class ActiveSaleSpecification : ISpecification<Sale>
{
    /// <summary>
    /// Evaluates whether the given sale is active.
    /// </summary>
    /// <param name="sale">The sale entity to evaluate.</param>
    /// <returns>True if the sale is not cancelled; otherwise, false.</returns>
    public bool IsSatisfiedBy(Sale sale)
    {
        return !sale.IsCancelled;
    }
}