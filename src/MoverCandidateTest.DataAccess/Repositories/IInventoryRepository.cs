
using MoverCandidateTest.Models.Inventory;

namespace MoverCandidateTest.DataAccess.Repositories
{
    public interface IInventoryRepository
    {
        public void AddInventoryItemToRepository(InventoryItem item);
        public void UpdateInventoryItemInRepository(string sku, int quantity);
        public List<InventoryItem> GetInventoryListFromRepository();
        public bool InventoryItemExistsInRepository(string sku);
        public InventoryItem GetInventoryItemFromRepository(string sku);
    }
}