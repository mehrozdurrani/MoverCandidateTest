
namespace MoverCandidateTest.Models.Inventory
{
    public class InventoryItem
    {
        public string Sku { get; private set; }
        public string Description { get; private set; }
        public int Quantity { get; private set; }

        private InventoryItem(string sku, string description, int quantity)
        {
            Sku = sku;
            Description = description;
            Quantity = quantity;
        }
        public static InventoryItem Create(string sku, string description, int quantity)
        {
            return new InventoryItem(sku, description, quantity);
        }

        public void ChangeQuantity(int quantity)
        {
            Quantity = quantity;
        }
        public void ChangeDescription(string description)
        {
            Description = description;
        }
    }
}