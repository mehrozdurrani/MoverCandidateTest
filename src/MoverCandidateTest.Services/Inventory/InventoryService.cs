using Microsoft.Extensions.Logging;
using MoverCandidateTest.DataAccess.Repositories;
using MoverCandidateTest.Models.Inventory;
using MoverCandidateTest.Services.Errors;

namespace MoverCandidateTest.Services.Inventory
{
    public class InventoryService : IInventoryService
    {
        private readonly ILogger<InventoryService> _logger;
        private readonly IInventoryRepository _inventoryRepository;

        public InventoryService(
            ILogger<InventoryService> logger,
            IInventoryRepository inventoryRepository
        )
        {
            _logger = logger;
            _inventoryRepository = inventoryRepository;
        }

        // Adds or updates an inventory item based on SKU.
        public void AddInventoryItem(InventoryItem item)
        {
            if (_inventoryRepository.InventoryItemExistsInRepository(item.Sku))
            {
                // If the item exists, update its quantity.
                var inventoryItem = _inventoryRepository.GetInventoryItemFromRepository(item.Sku);
                var newQuantity = inventoryItem.Quantity + item.Quantity;
                _inventoryRepository.UpdateInventoryItemInRepository(item.Sku, newQuantity);
                _logger.LogInformation("Adding stock to existing inventory item: {item}", item);
            }
            else
            {
                // If the item does not exist, add it to the inventory.
                _inventoryRepository.AddInventoryItemToRepository(item);
                _logger.LogInformation("Adding stock to inventory item: {item}", item);
            }
        }

        public List<InventoryItem> GetInventoryList()
        {
            var inventoryList = _inventoryRepository.GetInventoryListFromRepository();
            if (inventoryList.Count == 0)
            {
                // If the inventory list is empty, log an error and throw an exception.
                _logger.LogError("Inventory List is Empty.");
                throw new EmptyInventoryListException();
            }
            _logger.LogInformation("Fetching Inventory List of size: {Count}", inventoryList.Count);
            return inventoryList;
        }

        public void RemoveInventoryItem(string sku, int quantity)
        {
            if (!_inventoryRepository.InventoryItemExistsInRepository(sku))
            {
                // If the item does not exist, log an error and throw an exception.
                _logger.LogError("Inventory Item of SKU: {Sku} Not Found.", sku);
                throw new InventoryItemNotFoundException(sku);
            }

            // Retrieve the inventory item and calculate the new quantity after removal.
            var inventoryItem = _inventoryRepository.GetInventoryItemFromRepository(sku);
            var newQuantity = inventoryItem.Quantity - quantity;

            if (newQuantity < 0)
            {
                // If the resulting quantity is invalid (negative), log an error and throw an exception.
                _logger.LogError("Invalid Quantity: {Quantity}", quantity);
                throw new InvalidQuantityException();
            }

            // Update the inventory item with the new quantity after removal.
            _inventoryRepository.UpdateInventoryItemInRepository(sku, newQuantity);
            _logger.LogInformation("Removed stock from inventory item: {item}", inventoryItem);
        }
    }
}
