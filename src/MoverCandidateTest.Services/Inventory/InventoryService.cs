
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
            throw new NotImplementedException();
        }

        public List<InventoryItem> GetInventoryList()
        {
            throw new NotImplementedException();
        }

        public bool InventoryItemExists(string sku)
        {
            throw new NotImplementedException();
        }

        public void RemoveInventoryItem(string sku, int quantity)
        {
            throw new NotImplementedException();
        }
    }
}