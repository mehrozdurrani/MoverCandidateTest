
using System.ComponentModel.DataAnnotations;

namespace MoverCandidateTest.Contracts.Inventory
{
    public record AddInventoryItemRequest
    {
        [Required(ErrorMessage = "SKU is required")]
        public required string Sku { get; init; }

        [StringLength(100, MinimumLength = 1, ErrorMessage = "Description must be between 1 and 100 characters")]
        public string? Description { get; init; }

        [Range(0, int.MaxValue, ErrorMessage = "Quantity must be a non-negative number")]
        public int Quantity { get; init; }
    }
}
