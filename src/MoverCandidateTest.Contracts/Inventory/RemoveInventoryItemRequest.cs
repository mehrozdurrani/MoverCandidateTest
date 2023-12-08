using System.ComponentModel.DataAnnotations;

namespace MoverCandidateTest.Contracts.Inventory
{
    public record RemoveInventoryItemRequest
    {
        [Required(ErrorMessage = "SKU is required")]
        public required string Sku { get; init; }

        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater than 0")]
        public int Quantity { get; init; }
    }
}
