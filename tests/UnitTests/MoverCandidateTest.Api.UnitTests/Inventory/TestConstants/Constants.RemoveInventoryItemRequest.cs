using MoverCandidateTest.Contracts.Inventory;

namespace MoverCandidateTest.Api.UnitTests.Inventory.TestConstants
{
    public static partial class Constants
    {
        public static class ValidRemoveInventoryItemRequest
        {
            public static RemoveInventoryItemRequest GetValue() => new RemoveInventoryItemRequest
            {
                Sku = "Gant-MV-B-L",
                Quantity = 2
            };
        }
        public static class InvalidRemoveInventoryItemRequest
        {
            public static RemoveInventoryItemRequest GetValueWithInvalidSku() => new RemoveInventoryItemRequest
            {
                Sku = "",
                Quantity = 2
            };
            public static RemoveInventoryItemRequest GetValueWithZeroQuantity() => new RemoveInventoryItemRequest
            {
                Sku = "Gant-MV-B-L",
                Quantity = 0
            };
            public static RemoveInventoryItemRequest GetValueWithNegativeQuantity() => new RemoveInventoryItemRequest
            {
                Sku = "Gant-MV-B-L",
                Quantity = -2
            };
        }
    }
}