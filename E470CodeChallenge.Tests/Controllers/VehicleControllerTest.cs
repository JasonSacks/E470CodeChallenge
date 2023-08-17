
using E470CodeChallenge.Controllers;
using E470CodeChallenge.Entities;
using E470CodeChallenge.Events.Vehicular;
using E470CodeChallenge.Model;
using E470CodeChallenge.Services;
using Microsoft.Extensions.Logging;
using Moq;
using Moq.Language.Flow;

namespace E470CodeChallenge.Tests.Controllers
{
    public class VehicleControllerTest
    {
        private readonly Mock<ILogger<VehicleController>> _logger = new();
        private readonly Mock<IVehicleService> _vehicleService = new();
        private readonly Mock<ITransponderService> _transponderService = new();

        [Fact]
        public async void Create_Is_Successful()
        {
            VehicleController controller = CreateController(true);
            await controller.Create(new VehicleDto());
            _vehicleService.Verify(service => service.Create(It.IsAny<Vehicle>()));
        }

        [Fact]
        public async void Create_Fails_Due_To_Invalid_Data()
        {
            VehicleController controller = CreateController(true);
            controller.ModelState.AddModelError("test", "Data is bad..mmmkay");
            await controller.Create(new VehicleDto());
            Assert.False(controller.ModelState.IsValid);
        }

        [Fact]
        public void Create_Fails_Due_To_Exception()
        {
            VehicleController controller = CreateController(false);
            Assert.ThrowsAsync<Exception>(async () => await controller.Create(new VehicleDto()));
        }

        private VehicleController CreateController(bool isSucessful)
        {
            ConfigureTransponderService();
            ConfigureVehicleService(isSucessful);
            return new VehicleController(
                _logger.Object,
                _vehicleService.Object,
                _transponderService.Object);
        }

        private void ConfigureVehicleService(bool isSuccessful)
        {
            ISetup<IVehicleService, Task<Vehicle>> setup = _vehicleService.Setup(service => service.Create(It.IsAny<Vehicle>()));
            
            if (isSuccessful)
            {
                setup.ReturnsAsync(new Vehicle());
                return;
            }

            setup.Throws<Exception>();
        }
        
        private void ConfigureTransponderService() =>
            _transponderService.Setup(service => service.OnVehicleCreated(It.IsAny<VehicleEventArgs>() ));
        
    }
}
