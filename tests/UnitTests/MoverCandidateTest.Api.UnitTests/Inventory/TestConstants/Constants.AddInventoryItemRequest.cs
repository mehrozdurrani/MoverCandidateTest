using MoverCandidateTest.Contracts.Inventory;

namespace MoverCandidateTest.Api.UnitTests.Inventory.TestConstants
{
    public static partial class Constants
    {
        public static class ValidAddInventoryItemRequest
        {
            public static AddInventoryItemRequest GetValue() => new AddInventoryItemRequest
            {
                Sku = "Gant-MV-B-L",
                Description = "A beautiful gant blue V-neck t - shirt for youngsters",
                Quantity = 2
            };
        }
        public static class InvalidAddInventoryItemRequest
        {
            public static AddInventoryItemRequest GetValueWithInvalidSku() => new AddInventoryItemRequest
            {
                Sku = "",
                Description = "A beautiful gant blue V-neck t - shirt for youngsters",
                Quantity = 2
            };
            public static AddInventoryItemRequest GetValueWithZeroQuantity() => new AddInventoryItemRequest
            {
                Sku = "Gant-MV-B-L",
                Description = "A beautiful gant blue V-neck t - shirt for youngsters",
                Quantity = 0
            };
            public static AddInventoryItemRequest GetValueWithNegativeQuantity() => new AddInventoryItemRequest
            {
                Sku = "Gant-MV-B-L",
                Description = "A beautiful gant blue V-neck t - shirt for youngsters",
                Quantity = -2
            };
            public static AddInventoryItemRequest GetValueWithInvalidDescription() => new AddInventoryItemRequest
            {
                Sku = "Gant-MV-B-L",
                Description = "A beautiful gant blue V-neck t - shirt for youngsters A beautiful gant blue V-neck t - shirt for youngsters A beautiful gant blue V-neck t - shirt for youngsters A beautiful gant blue V-neck t - shirt for youngsters A beautiful gant blue V-neck t - shirt for youngsters A beautiful gant blue V-neck t - shirt for youngsters A beautiful gant blue V-neck t - shirt for youngsters A beautiful gant blue V-neck t - shirt for youngsters A beautiful gant blue V-neck t - shirt for youngsters A beautiful gant blue V-neck t - shirt for youngsters A beautiful gant blue V-neck t - shirt for youngsters A beautiful gant blue V-neck t - shirt for youngsters",
                Quantity = 2
            };
        }
    }
}