
using MoverCandidateTest.Models.Inventory;

namespace MoverCandidateTest.DataAccess.Repositories
{
    public class InventoryRepository : IInventoryRepository
    {
        private readonly Dictionary<string, InventoryItem> _inventoryList = new();
        public void AddInventoryItemToRepository(InventoryItem item)
        {
            _inventoryList.Add(item.Sku, item);
        }

        public List<InventoryItem> GetInventoryListFromRepository()
        {
            // Returning deep copy
            return _inventoryList.Values.Select(item => InventoryItem.Create(item.Sku, item.Description, item.Quantity)).ToList();
        }

        public bool InventoryItemExistsInRepository(string sku)
        {
            return _inventoryList.ContainsKey(sku);
        }

        public void UpdateInventoryItemInRepository(string sku, int quantity)
        {
            _inventoryList[sku].ChangeQuantity(quantity);
        }
    }
}