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

	public async Task<int[]> PressButtonFromFloor(int floorNumber)
	{
		//WARNING: This is a stub - replace with real implementation

		if (!_elevatorState.IsFloorValid(floorNumber))
			return new[] { -1 }; //very basic return value for bad request

		var currentlySelectedFloors = _elevatorState.GetAllRequestedFloors().ToArray();
		_elevatorState.CallFromFloor(floorNumber);

		return await Task.FromResult(currentlySelectedFloors.ToArray());
	}

	public async Task<int[]> PressButtonFromCabin(int floorNumber)
	{
		//WARNING: This is a stub - replace with real implementation
		//Return type should be an object containing possible error description

		if (!_elevatorState.IsFloorValid(floorNumber))
			return new[] { -1 };

		_elevatorState.CallFromCabin(floorNumber);

		return await GetRequestedFloors();
	}

	public async Task<int[]> GetRequestedFloors()
	{
		//WARNING: This is a stub - replace with real implementation
		return await Task.FromResult(_elevatorState.GetAllRequestedFloors().ToArray());
	}

	public async Task<int> GetNextSelectedFloor()
	{
		//WARNING: This is a stub - replace with real implementation
		return await Task.FromResult(_elevatorState.GetNextRequestedFloor());
	}
}
