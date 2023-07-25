namespace ElevatorControl.Services;

public class ElevatorService : IElevatorService
{
	private readonly ILogger _logger; //logging is currently not implemented
	private readonly IElevatorState _elevatorState;

	public ElevatorService
	(
		ILogger<ElevatorService> logger,
		IElevatorState elevatorState
	)
	{
		_logger = logger;
		_elevatorState = elevatorState;
	}

	public async Task<bool> FetchToFloor(int floorNumber)
	{
		//WARNING: This is a stub - replace with real implementation

		//var isOnItsWay = IsFloorValid(floorNumber);
		return await Task.FromResult(true);
	}

	public async Task<int[]> SelectTargetFloor(int floorNumber)
	{
		//WARNING: This is a stub - replace with real implementation
		//Return type should be an object containing possible error description

		_elevatorState.AddFloorToQueue(floorNumber);

		return await GetRequestedFloors();
	}

	public async Task<int[]> GetRequestedFloors()
	{
		//WARNING: This is a stub - replace with real implementation

		return await Task.FromResult(_elevatorState.GetRequestedFloors().ToArray());
	}

	public async Task<int> GetNextSelectedFloor()
	{
		//WARNING: This is a stub - replace with real implementation

		var selectedFloors = await GetRequestedFloors();
		return selectedFloors[2];
	}
}
