
using MoverCandidateTest.Models.Inventory;

namespace MoverCandidateTest.Services.Inventory
{
    public interface IInventoryService
    {
        public void AddInventoryItem(InventoryItem item);
        public void RemoveInventoryItem(string sku, int quantity);
        public List<InventoryItem> GetInventoryList();
    }
}