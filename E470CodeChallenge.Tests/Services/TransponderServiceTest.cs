using E470CodeChallenge.Entities;
using E470CodeChallenge.Factories;
using E470CodeChallenge.Repositories;
using E470CodeChallenge.Services;
using Microsoft.Extensions.Logging;
using Moq;

namespace E470CodeChallenge.Tests.Services
{
    internal class TransponderDataGenerator
    {
        public static IEnumerable<object[]> GetValidVehicleData()
        { 
            yield return new Vehicle[] { new Vehicle(){ Year = "2000", Make = "Test", Model = "Test" }};
            yield return new Vehicle[] { new Vehicle() { Year = "1995", Make = "Test", Model = "Test" }};
            yield return new Vehicle[] { new Vehicle() { Year = "1925", Make = "Test", Model = "Test" }};

        }

        public static IEnumerable<object[]> GetInvalidVehicleData()
        {
            yield return new Vehicle[] { new Vehicle() { Year = "1800", Make = "Test", Model = "Test" }};
            yield return new Vehicle[] { new Vehicle() { Year = "-2", Make = "Test", Model = "Test" }};
            yield return new Vehicle[] { new Vehicle() { Year = null, Make = "Test", Model = "Test" }};

        }
    }

    public class TransponderServiceTest
    {
        private readonly Mock<ILogger<TransponderService>> _logger = new();
        private readonly Mock<ITransponderRepository> _repository = new();
        private readonly Mock<ITransponderRepositoryFactory> _factory = new();

       [Theory]
       [MemberData(nameof(TransponderDataGenerator.GetValidVehicleData), MemberType = typeof(TransponderDataGenerator))]
        public async void Create_Is_Successful(Vehicle vehicle)
        {
            TransponderService service = CreateService();
            Transponder transponder = await service.Create(vehicle);
            Assert.NotNull(transponder);
            _factory.Verify(factory => factory.GetTransponderRepository(It.IsAny<short>()));
            _repository.Verify(repo => repo.Create(It.IsAny<Transponder>()));
        }

        [Fact]
        public void Create_Fails_Due_To_Invalid_Data()
        {
            TransponderService service = CreateService();
            Assert.ThrowsAsync<ArgumentException>(async () => await service.Create(new Vehicle()));
        }

        private TransponderService CreateService()
        {
            ConfigureFactoryMocks();

            return new TransponderService(_factory.Object, _logger.Object);
        }

        private void ConfigureFactoryMocks() =>
           _factory
                .Setup(factory => factory.GetTransponderRepository(It.IsAny<short>()))
                .Returns(_repository.Object);

        private void ConfigureRepositoryMocks() =>
            _repository.Setup(repo => repo.Create(It.IsAny<Transponder>())).Verifiable();
    }
}
