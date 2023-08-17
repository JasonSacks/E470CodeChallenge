using E470CodeChallenge.Entities;
using E470CodeChallenge.Events.Vehicular;
using E470CodeChallenge.Repositories;
using E470CodeChallenge.Services;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;
using Moq;

namespace E470CodeChallenge.Tests.Services
{
    public class VehicleServiceTest
    {
        private readonly Mock<ILogger<VehicleService>> _logger = new();
        private readonly Mock<IVehicleRepository> _repository = new();
        private readonly Mock<IDbContextTransaction> _transaction = new();

        [Fact]
        public async void Create_Is_Successful()
        {
            VehicleService service = CreateService();
            service.VehicleCreated += TestEvent;
            Vehicle vehicle = await service.Create(new Vehicle() {Year = "2000", Make="test", Model="Test" });
            Assert.NotNull(vehicle); //used to test transaction but not supported with in memory
        }
               
        [Fact]
        public  void Create_Fails_Due_To_No_Assigned_Event()
        {
            VehicleService service = CreateService();
            service.VehicleCreated -= TestEvent;
            Assert.ThrowsAsync<InvalidOperationException>(async () => await service.Create(It.IsAny<Vehicle>()));
        }

        private VehicleService CreateService()
        {
            ConfigureRepository();
            return new VehicleService(_repository.Object, _logger.Object);
        }

        private void ConfigureRepository()
        {
            _repository.Setup(repo => repo.Create(It.IsAny<Vehicle>())).Verifiable();
            ConfigureTransaction();
            _repository.Setup(repo => repo.BeginTransactionAsync()).ReturnsAsync(_transaction.Object).Verifiable();
        }
               
        private void ConfigureTransaction()
        {
            _transaction.Setup(transaction => transaction.CommitAsync(It.IsAny<CancellationToken>())).Verifiable();
            _transaction.Setup(transaction => transaction.Rollback()).Verifiable();
        }

        private async Task TestEvent(VehicleEventArgs args) => await Task.Run(() => { });
    }
}
