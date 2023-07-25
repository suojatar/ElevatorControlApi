using ElevatorControl.Services;
using Microsoft.AspNetCore.Mvc;

namespace ElevatorControl.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class ElevatorController : ControllerBase
	{
		private readonly ILogger<ElevatorController> _logger;
		private readonly IElevatorService _elevatorService;

		public ElevatorController
		(
			ILogger<ElevatorController> logger,
			IElevatorService elevatorService
		)
		{
			_logger = logger;
			_elevatorService = elevatorService;
		}


		/// <summary>
		/// Calls the elevator upon passenger request from outside the car
		/// </summary>
		/// <response code="200">Elevator called to specified floor</response>
		/// <response code="400">Invalid floor was entered</response>
		[HttpPut]
		[Route("[action]")]
		public async Task<IActionResult> CallFromFloor(int floorNumber)
		{
			var priorFloors = await _elevatorService.PressButtonFromFloor(floorNumber);

			if (!priorFloors.Any())
				return Ok($"Floor {floorNumber} will be served immediately.");
			else if (priorFloors.Count() == 1 && priorFloors[0] == -1)
				return BadRequest($"Floor {floorNumber} does not exist!");
			else
				return Ok($"Floor {floorNumber} will be served after floors {string.Join(", ", priorFloors)}");
		}


		/// <summary>
		/// Adds the floor selected by passenger from inside the car to the list of floors to stop at
		/// </summary>
		/// <response code="200">Selected floor added</response>
		/// <response code="400">Error: No selected floors were returned</response>
		[HttpPut]
		[Route("[action]")]
		public async Task<IActionResult> SelectFromCabin(int floorNumber)
		{
			var requestedFloors = await _elevatorService.PressButtonFromCabin(floorNumber);

			if (requestedFloors.Any())
				return Ok(requestedFloors);
			else
				return BadRequest("No floors have been selected.");
		}

		/// <summary>
		/// Returns a list of floors selected by all passengers during the current trip
		/// </summary>
		/// <response code="200">Selected floors found</response>
		[HttpGet]
		[Route("SelectedFloors/[action]")]
		public async Task<IActionResult> All()
		{
			var requestedFloors = await _elevatorService.GetRequestedFloors();

			return Ok(requestedFloors);
		}


		/// <summary>
		/// Shows the next floor at which the elevator will stop
		/// </summary>
		/// <response code="200">Next floor found</response>
		[HttpGet]
		[Route("SelectedFloors/[action]")]
		public async Task<IActionResult> Next()
		{
			var nextFloor = await _elevatorService.GetNextSelectedFloor();

			return Ok(nextFloor);
		}
	}
}