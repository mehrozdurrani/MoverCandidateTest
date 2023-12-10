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

        public InventoryItem GetInventoryItemFromRepository(string sku)
        {
            // Returning deep copy
            return InventoryItem.Create(_inventoryList[sku].Sku, _inventoryList[sku].Description, _inventoryList[sku].Quantity);
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

        public void UpdateInventoryItemInRepository(string sku, string description, int quantity)
        {
            _inventoryList[sku].ChangeDescription(description);
            _inventoryList[sku].ChangeQuantity(quantity);
        }
    }
}