using E470CodeChallenge.Entities;
using E470CodeChallenge.Model;
using E470CodeChallenge.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace E470CodeChallenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly ILogger<VehicleController> _logger;
        private readonly IVehicleService _vehicleService;
        
        /// <summary>
        /// Constructor for the Vehicle Controller
        /// </summary>
        /// <param name="logger">The logger for the controller.</param>
        /// <param name="vehicleService">The Vehicle Service for performing operations on a Vehicle.</param>
        /// <param name="transponderService">The Transponder Service for performing operations on a Vehicle.</param>
        public VehicleController(
            ILogger<VehicleController> logger,
            IVehicleService vehicleService,
            ITransponderService transponderService) : base()
        {
            _logger = logger;
            _vehicleService = vehicleService;
            _vehicleService.VehicleCreated += transponderService.OnVehicleCreated;
        }

        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Create(VehicleDto dto)
        {
            string method = $"{nameof(VehicleController)}.{nameof(Create)}";
            _logger.LogTrace($"{method} : Executing.");

            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid data was passed as argument in DTO.");
                return BadRequest(ModelState);
            }
            _logger.LogTrace($"{method} : Dto validated.");

            try
            {
                Vehicle vehicle = new()
                {
                    Year = dto.Year,
                    Make = dto.Make,
                    Model = dto.Model
                };
          
                vehicle = await _vehicleService.Create(vehicle);
                _logger.LogTrace($"{method} : Vehicle created -- Success.");
                // No location for created get, so leaving blank for challenge
                return new CreatedResult("",null);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "A critical error occured which prevented normal processing");
                return StatusCode(500, "An internal error has occured. Please contact an administrator to determine the problem");
            }
        } 
    
    }
}
