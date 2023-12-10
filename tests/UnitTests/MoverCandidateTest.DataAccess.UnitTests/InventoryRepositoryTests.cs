using MoverCandidateTest.DataAccess.Repositories;
using MoverCandidateTest.Models.Inventory;

namespace MoverCandidateTest.DataAccess.UnitTests
{
    public class InventoryRepositoryTests
    {
        private IInventoryRepository _inventoryRepository;
        private InventoryItem _inventoryItem;
        [SetUp]
        public void Setup()
        {
            _inventoryRepository = new InventoryRepository();
            _inventoryItem = InventoryItem.Create("Gant-MV-B-L", "A beautiful gant blue V - neck t - shirt for youngsters", 2);
        }
        [Test]
        public void AddInventoryItemToRepository_WhenCalledWithInventoryItem_AddsInventoryItem()
        {
            // Act
            _inventoryRepository.AddInventoryItemToRepository(_inventoryItem);

            //Assert
            Assert.That(_inventoryRepository.InventoryItemExistsInRepository(_inventoryItem.Sku), Is.True);
            Assert.That(_inventoryRepository.GetInventoryItemFromRepository(_inventoryItem.Sku).Sku, Is.EqualTo(_inventoryItem.Sku));
            Assert.That(_inventoryRepository.GetInventoryItemFromRepository(_inventoryItem.Sku).Description, Is.EqualTo(_inventoryItem.Description));
            Assert.That(_inventoryRepository.GetInventoryItemFromRepository(_inventoryItem.Sku).Quantity, Is.EqualTo(_inventoryItem.Quantity));
        }
        [Test]
        public void GetInventoryItemFromRepository_WhenCalledWithSku_ReturnsInventoryItem()
        {
            // Arrange
            _inventoryRepository.AddInventoryItemToRepository(_inventoryItem);

            // Act
            var result = _inventoryRepository.GetInventoryItemFromRepository(_inventoryItem.Sku);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<InventoryItem>());
            Assert.That(result.Sku, Is.EqualTo(_inventoryItem.Sku));
            Assert.That(result.Description, Is.EqualTo(_inventoryItem.Description));
            Assert.That(result.Quantity, Is.EqualTo(_inventoryItem.Quantity));
        }
        [Test]
        public void GetInventoryListFromRepository_WhenCalled_ReturnsInventoryList()
        {
            // Arrange
            _inventoryRepository.AddInventoryItemToRepository(_inventoryItem);

            // Act
            var result = _inventoryRepository.GetInventoryListFromRepository();

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<List<InventoryItem>>());
            Assert.That(result, Is.Not.Empty);
        }
        [Test]
        public void InventoryItemExistsInRepository_WhenCalledWithEixstingSku_ReturnsTrue()
        {
            // Arrange
            _inventoryRepository.AddInventoryItemToRepository(_inventoryItem);

            // Act
            var result = _inventoryRepository.InventoryItemExistsInRepository(_inventoryItem.Sku);

            // Assert
            Assert.That(result, Is.True);
        }
        [Test]
        public void InventoryItemExistsInRepository_WhenCalledWithNonEixstingSku_ReturnsFalse()
        {
            // Arrange
            _inventoryRepository.AddInventoryItemToRepository(_inventoryItem);

            // Act
            var result = _inventoryRepository.InventoryItemExistsInRepository("Gant-MV-B-XL");

            // Assert
            Assert.That(result, Is.False);
        }
        [Test]
        public void UpdateInventoryItemInRepository_WhenCalledWithSkuAndQuantity_UpdatesInventoryItem()
        {
            // Arrange
            _inventoryRepository.AddInventoryItemToRepository(_inventoryItem);

            // Act
            _inventoryRepository.UpdateInventoryItemInRepository(_inventoryItem.Sku, 3);

            // Assert
            Assert.That(_inventoryRepository.GetInventoryItemFromRepository(_inventoryItem.Sku).Quantity, Is.EqualTo(3));
        }
        [Test]
        public void UpdateInventoryItemInRepository_WhenCalledWithSkuAndDescription_UpdatesInventoryItem()
        {
            // Arrange
            _inventoryRepository.AddInventoryItemToRepository(_inventoryItem);

            // Act
            _inventoryRepository.UpdateInventoryItemInRepository(_inventoryItem.Sku, "A beautiful gant blue V - neck t - shirt for teenagers", 3);

            // Assert
            Assert.That(_inventoryRepository.GetInventoryItemFromRepository(_inventoryItem.Sku).Description, Is.EqualTo("A beautiful gant blue V - neck t - shirt for teenagers"));
            Assert.That(_inventoryRepository.GetInventoryItemFromRepository(_inventoryItem.Sku).Quantity, Is.EqualTo(3));
        }
    }
}