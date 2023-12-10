using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using MoverCandidateTest.Api.Controllers.Inventory;
using MoverCandidateTest.Api.UnitTests.Inventory.TestConstants;
using MoverCandidateTest.Api.UnitTests.Inventory.TestData;
using MoverCandidateTest.Contracts.Inventory;
using MoverCandidateTest.Models.Inventory;
using MoverCandidateTest.Services.Inventory;

namespace MoverCandidateTest.Api.UnitTests.Inventory
{
    public class InventoryControllerTests
    {
        private Mock<IInventoryService> _inventoryServiceMock;
        private Mock<ILogger<InventoryController>> _logger;
        private InventoryController _inventoryController;

        [SetUp]
        public void Setup()
        {
            _inventoryServiceMock = new Mock<IInventoryService>();
            _logger = new Mock<ILogger<InventoryController>>();
            _inventoryController = new InventoryController(_inventoryServiceMock.Object, _logger.Object);
        }

        [Test]
        public void AddInventoryItem_ValidRequest_ReturnsOk()
        {
            // Arrange
            AddInventoryItemRequest request = Constants.ValidAddInventoryItemRequest.GetValue();

            // Act
            var result = _inventoryController.AddInventoryItem(request);

            // Assert
            Assert.That(result, Is.TypeOf<OkObjectResult>());
            _inventoryServiceMock.Verify(x => x.AddInventoryItem(It.IsAny<InventoryItem>()), Times.Once);
        }

        [Test]
        [TestCaseSource(typeof(InvalidAddInventoryItemTestData), nameof(InvalidAddInventoryItemTestData.TestCases))]
        public void AddInventoryItem_InvalidRequest_ReturnsBadRequest(
            AddInventoryItemRequest request
        )
        {
            // Arrange
            // Manually adding ModelState errors as in unit test there is no pipline
            _inventoryController.ModelState.AddModelError(nameof(request.Sku), "SKU is required");
            _inventoryController.ModelState.AddModelError(nameof(request.Description), "Description must be between 1 and 100 characters");
            _inventoryController.ModelState.AddModelError(nameof(request.Quantity), "Quantity must be a non-negative number");

            // Act
            var result = _inventoryController.AddInventoryItem(request);

            // Assert
            Assert.That(result, Is.TypeOf<BadRequestObjectResult>());
            _inventoryServiceMock.Verify(x => x.AddInventoryItem(It.IsAny<InventoryItem>()), Times.Never);
        }

        [Test]
        public void RemoveInventoryItem_ValidRequest_ReturnsOk()
        {
            // Arrange
            RemoveInventoryItemRequest request = Constants.ValidRemoveInventoryItemRequest.GetValue();

            // Act
            var result = _inventoryController.RemoveInventoryItem(request);

            // Assert
            Assert.That(result, Is.TypeOf<OkObjectResult>());
            _inventoryServiceMock.Verify(x => x.RemoveInventoryItem(It.IsAny<string>(), It.IsAny<int>()), Times.Once);
        }
        [Test]
        [TestCaseSource(typeof(InvalidRemoveInventoryItemTestData), nameof(InvalidRemoveInventoryItemTestData.TestCases))]
        public void RemoveInventoryItem_InvalidRequest_ReturnsBadRequest(RemoveInventoryItemRequest request)
        {
            // Arrange
            // Manually adding ModelState errors as in unit test there is no pipline
            _inventoryController.ModelState.AddModelError(nameof(request.Sku), "SKU is required");
            _inventoryController.ModelState.AddModelError(nameof(request.Quantity), "Quantity must be a non-negative number");

            // Act
            var result = _inventoryController.RemoveInventoryItem(request);

            // Assert
            Assert.That(result, Is.TypeOf<BadRequestObjectResult>());
            _inventoryServiceMock.Verify(x => x.RemoveInventoryItem(It.IsAny<string>(), It.IsAny<int>()), Times.Never);
        }
        [Test]
        public void GetInventoryList_WhenCalled_ReturnsList()
        {
            // Arrange
            _inventoryServiceMock.Setup(x => x.GetInventoryList()).Returns(new List<InventoryItem>());

            // Act
            var result = _inventoryController.GetInventoryList();
            var okResultObject = (OkObjectResult)result;
            var getInventoryListResponse = okResultObject.Value;

            // Assert
            Assert.That(result, Is.TypeOf<OkObjectResult>());
            Assert.That(getInventoryListResponse, Is.TypeOf<GetInventoryListResponse>());
            _inventoryServiceMock.Verify(x => x.GetInventoryList(), Times.Once);
        }
    }
}
