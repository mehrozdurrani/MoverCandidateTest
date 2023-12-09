
using System.ComponentModel.DataAnnotations;

namespace MoverCandidateTest.Contracts.Inventory
{
    public record AddInventoryItemRequest
    {
        [Required(ErrorMessage = "SKU is required")]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "SKU must be between 1 and 20 characters")]
        public required string Sku { get; init; }

        [StringLength(100, MinimumLength = 0, ErrorMessage = "Description must be between 1 and 100 characters")]
        public string? Description { get; init; }

        [Range(0, int.MaxValue, ErrorMessage = "Quantity must be a non-negative number")]
        public int Quantity { get; init; }
    }
}
