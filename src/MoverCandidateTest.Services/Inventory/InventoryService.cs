
using MoverCandidateTest.DataAccess.Repositories;
using MoverCandidateTest.Models.Inventory;

namespace MoverCandidateTest.Services.Inventory
{
    public class InventoryService : IInventoryService
    {
        private readonly IInventoryRepository _inventoryRepository;

        public InventoryService(IInventoryRepository inventoryRepository)
        {
            _inventoryRepository = inventoryRepository;
        }
        public void AddInventoryItem(InventoryItem item)
        {
            if (_inventoryRepository.InventoryItemExistsInRepository(item.Sku))
            {
                var inventoryItem = _inventoryRepository.GetInventoryItemFromRepository(item.Sku);
                var newQuantity = inventoryItem.Quantity + item.Quantity;
                _inventoryRepository.UpdateInventoryItemInRepository(item.Sku, newQuantity);
            }
            else
            {
                _inventoryRepository.AddInventoryItemToRepository(item);
            }
        }

        public List<InventoryItem> GetInventoryList()
        {
            return _inventoryRepository.GetInventoryListFromRepository();
        }

        public void RemoveInventoryItem(string sku, int quantity)
        {
            if (_inventoryRepository.InventoryItemExistsInRepository(sku))
            {
                var inventoryItem = _inventoryRepository.GetInventoryItemFromRepository(sku);
                var newQuantity = inventoryItem.Quantity - quantity;
                _inventoryRepository.UpdateInventoryItemInRepository(sku, newQuantity);
            }
        }
    }
}