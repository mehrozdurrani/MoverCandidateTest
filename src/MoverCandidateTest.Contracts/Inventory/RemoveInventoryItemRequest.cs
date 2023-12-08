using System.ComponentModel.DataAnnotations;

namespace MoverCandidateTest.Contracts.Inventory
{
    public record RemoveInventoryItemRequest
    {
        [Required(ErrorMessage = "SKU is required")]
        public required string Sku { get; init; }

        [Range(0, int.MaxValue, ErrorMessage = "Quantity must be a non-negative number")]
        public int Quantity { get; init; }
    }
}
