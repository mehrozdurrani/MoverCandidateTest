using System.Collections;
using static MoverCandidateTest.Api.UnitTests.Inventory.TestConstants.Constants;

namespace MoverCandidateTest.Api.UnitTests.Inventory.TestData
{
    public class InvalidRemoveInventoryItemTestData
    {
        public static IEnumerable TestCases
        {
            get
            {
                yield return new TestCaseData(InvalidRemoveInventoryItemRequest.GetValueWithInvalidSku());
                yield return new TestCaseData(InvalidRemoveInventoryItemRequest.GetValueWithZeroQuantity());
                yield return new TestCaseData(InvalidRemoveInventoryItemRequest.GetValueWithNegativeQuantity());
            }
        }
    }
}