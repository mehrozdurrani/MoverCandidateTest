using MoverCandidateTest.Models.Inventory;

namespace MoverCandidateTest.Contracts.Inventory
{
    public record GetInventoryListResponse(List<InventoryItem> Items);
}
