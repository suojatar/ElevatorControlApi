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
		[HttpGet]
		[Route("[action]/floorNumber")]
		public async Task<IActionResult> FetchToFloor(int floorNumber)
		{
			var isSuccess = await _elevatorService.FetchToFloor(floorNumber);

			if (isSuccess)
				return Ok($"Coming to floor {floorNumber}!");
			else
				return BadRequest($"Floor {floorNumber} does not exist!");
		}


		/// <summary>
		/// Adds the floor selected by passenger from inside the car to the list of floors to stop at
		/// </summary>
		/// <response code="200">Selected floor added</response>
		/// <response code="400">Error: No selected floors were returned</response>
		[HttpPut]
		[Route("[action]")]
		public async Task<IActionResult> SelectTargetFloor(int floorNumber)
		{
			var requestedFloors = await _elevatorService.SelectTargetFloor(floorNumber);

			if (requestedFloors != null)
				return Ok(requestedFloors);
			else
				return BadRequest("No floors have been selected.");
		}


		/// <summary>
		/// Returns a list of floors selected by all passengers during the current trip
		/// </summary>
		/// <response code="200">Selected floors found</response>
		[HttpGet]
		[Route("[action]")]
		public async Task<IActionResult> GetRequestedFloors()
		{
			var requestedFloors = await _elevatorService.GetRequestedFloors();

			return Ok(requestedFloors);
		}

		/// <summary>
		/// Shows the next floor at which the elevator will stop
		/// </summary>
		/// <response code="200">Next floor found</response>
		[HttpGet]
		[Route("[action]")]
		public async Task<IActionResult> GetNextFloor()
		{
			var nextFloor = await _elevatorService.GetNextSelectedFloor();

			return Ok(nextFloor);
		}
	}
}