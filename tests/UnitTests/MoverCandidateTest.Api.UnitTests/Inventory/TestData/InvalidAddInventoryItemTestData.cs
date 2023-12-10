using System.Collections;
using static MoverCandidateTest.Api.UnitTests.Inventory.TestConstants.Constants;

namespace MoverCandidateTest.Api.UnitTests.Inventory.TestData
{
    public static class InvalidAddInventoryItemTestData
    {
        public static IEnumerable TestCases
        {
            get
            {
                yield return new TestCaseData(InvalidAddInventoryItemRequest.GetValueWithInvalidSku());
                yield return new TestCaseData(InvalidAddInventoryItemRequest.GetValueWithZeroQuantity());
                yield return new TestCaseData(InvalidAddInventoryItemRequest.GetValueWithNegativeQuantity());
                yield return new TestCaseData(InvalidAddInventoryItemRequest.GetValueWithInvalidDescription());
            }
        }
    }
}