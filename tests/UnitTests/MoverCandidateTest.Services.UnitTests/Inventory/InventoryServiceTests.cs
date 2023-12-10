using Microsoft.Extensions.Logging;
using Moq;
using MoverCandidateTest.DataAccess.Repositories;
using MoverCandidateTest.Models.Inventory;
using MoverCandidateTest.Services.Errors;
using MoverCandidateTest.Services.Inventory;

namespace MoverCandidateTest.Services.UnitTests.Inventory
{
    public class InventoryServiceTests
    {
        private Mock<ILogger<InventoryService>> _loggerMock;
        private Mock<IInventoryRepository> _inventoryRepositoryMock;
        private IInventoryService _inventoryService;
        private InventoryItem _inventoryItem;

        [SetUp]
        public void Setup()
        {
            _loggerMock = new Mock<ILogger<InventoryService>>();
            _inventoryRepositoryMock = new Mock<IInventoryRepository>();
            _inventoryService = new InventoryService(_loggerMock.Object, _inventoryRepositoryMock.Object);
            _inventoryItem = InventoryItem.Create("Gant-MV-B-L", "A beautiful gant blue V - neck t - shirt for youngsters", 2);
        }

        [Test]
        public void AddInventoryItem_ItemDoesNotExist_AddsNewInventoryItem()
        {
            // Arrange
            _inventoryRepositoryMock.Setup(x => x.InventoryItemExistsInRepository(It.IsAny<string>())).Returns(false);

            // Act
            _inventoryService.AddInventoryItem(_inventoryItem);

            // Assert
            _inventoryRepositoryMock.Verify(x => x.AddInventoryItemToRepository(_inventoryItem), Times.Once);
            _inventoryRepositoryMock.Verify(x => x.UpdateInventoryItemInRepository(It.IsAny<string>(), It.IsAny<int>()), Times.Never);

        }

        [Test]
        public void AddInventoryItem_ItemDoesExist_UpdatesInventoryItem()
        {
            // Arrange
            _inventoryRepositoryMock.Setup(x => x.InventoryItemExistsInRepository(It.IsAny<string>())).Returns(true);
            _inventoryRepositoryMock.Setup(x => x.GetInventoryItemFromRepository(It.IsAny<string>())).Returns(_inventoryItem);
            // Act
            _inventoryService.AddInventoryItem(_inventoryItem);

            // Assert
            _inventoryRepositoryMock.Verify(x => x.UpdateInventoryItemInRepository(It.IsAny<string>(), It.IsAny<int>()), Times.Once);
            _inventoryRepositoryMock.Verify(x => x.AddInventoryItemToRepository(_inventoryItem), Times.Never);

        }

        [Test]
        public void GetInventoryList_InventoryListIsNotEmpty_ReturnsInventoryList()
        {
            // Arrange
            List<InventoryItem> inventoryList = new();
            inventoryList.Add(_inventoryItem);
            _inventoryRepositoryMock.Setup(x => x.GetInventoryListFromRepository()).Returns(inventoryList);

            // Act
            var result = _inventoryService.GetInventoryList();

            //Assert
            _inventoryRepositoryMock.Verify(x => x.GetInventoryListFromRepository(), Times.Once);
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.Not.Empty);
            Assert.That(result, Is.EquivalentTo(inventoryList));
        }

        [Test]
        public void GetInventoryList_InventoryListIsEmpty_ThrowsException()
        {
            // Arrange
            List<InventoryItem> inventoryList = new();
            _inventoryRepositoryMock.Setup(x => x.GetInventoryListFromRepository()).Returns(inventoryList);

            // Act and Assert
            Assert.That(() => _inventoryService.GetInventoryList(), Throws.TypeOf<EmptyInventoryListException>());
            _inventoryRepositoryMock.Verify(x => x.GetInventoryListFromRepository(), Times.Once);
        }

        [Test]
        public void RemoveInventoryItem_ItemExists_RemovesInventoryItem()
        {
            // Arrange
            _inventoryRepositoryMock.Setup(x => x.InventoryItemExistsInRepository(It.IsAny<string>())).Returns(true);
            _inventoryRepositoryMock.Setup(x => x.GetInventoryItemFromRepository(It.IsAny<string>())).Returns(_inventoryItem);
            // Act
            _inventoryService.RemoveInventoryItem("Gant-MV-B-L", 1);

            // Assert
            _inventoryRepositoryMock.Verify(x => x.GetInventoryItemFromRepository(It.IsAny<string>()), Times.Once);
            _inventoryRepositoryMock.Verify(x => x.UpdateInventoryItemInRepository(It.IsAny<string>(), It.IsAny<int>()), Times.Once);

        }

        [Test]
        public void RemoveInventoryItem_ItemDoesNotExist_ThrowsException()
        {
            // Arrange
            _inventoryRepositoryMock.Setup(x => x.InventoryItemExistsInRepository(It.IsAny<string>())).Returns(false);

            // Act and Assert
            Assert.That(() => _inventoryService.RemoveInventoryItem("Gant-MV-B-L", 1), Throws.TypeOf<InventoryItemNotFoundException>());
            _inventoryRepositoryMock.Verify(x => x.InventoryItemExistsInRepository(It.IsAny<string>()), Times.Once);
            _inventoryRepositoryMock.Verify(x => x.GetInventoryItemFromRepository(It.IsAny<string>()), Times.Never);
            _inventoryRepositoryMock.Verify(x => x.UpdateInventoryItemInRepository(It.IsAny<string>(), It.IsAny<int>()), Times.Never);
        }

        [Test]
        public void RemoveInventoryItem_QuntityMoreThanInventoryStock_ThrowsException()
        {
            // Arrange
            _inventoryRepositoryMock.Setup(x => x.InventoryItemExistsInRepository(It.IsAny<string>())).Returns(true);
            _inventoryRepositoryMock.Setup(x => x.GetInventoryItemFromRepository(It.IsAny<string>())).Returns(_inventoryItem);

            // Act and Assert
            Assert.That(() => _inventoryService.RemoveInventoryItem("Gant-MV-B-L", 5), Throws.TypeOf<InvalidQuantityException>());
            _inventoryRepositoryMock.Verify(x => x.GetInventoryItemFromRepository(It.IsAny<string>()), Times.Once);
            _inventoryRepositoryMock.Verify(x => x.UpdateInventoryItemInRepository(It.IsAny<string>(), It.IsAny<int>()), Times.Never);
        }
    }
}