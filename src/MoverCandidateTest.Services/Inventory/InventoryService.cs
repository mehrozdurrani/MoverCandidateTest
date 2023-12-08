
using MoverCandidateTest.DataAccess.Repositories;
using MoverCandidateTest.Models.Inventory;
using MoverCandidateTest.Services.Errors;

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
            if (!_inventoryRepository.InventoryItemExistsInRepository(sku))
            {
                throw new InventoryItemNotFoundException(sku);
            }

            var inventoryItem = _inventoryRepository.GetInventoryItemFromRepository(sku);
            var newQuantity = inventoryItem.Quantity - quantity;

            if (newQuantity < 0 || newQuantity == inventoryItem.Quantity)
            {
                throw new InvalidQuantityException();
            }

            _inventoryRepository.UpdateInventoryItemInRepository(sku, newQuantity);
        }
    }
}