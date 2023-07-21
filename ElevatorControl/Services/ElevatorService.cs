namespace ElevatorControl.Services;

public class ElevatorService : IElevatorService
{
	private const int NumberOfFloors = 16;
	private readonly ILogger _logger; //logging is currently not implemented

	public ElevatorService
	(
		ILogger<ElevatorService> logger
	)
	{
		_logger = logger;
	}

	public async Task<bool> FetchToFloor(int floorNumber)
	{
		//WARNING: This is a stub - replace with real implementation

		var isOnItsWay = IsFloorValid(floorNumber);
		return await Task.FromResult(isOnItsWay);
	}

	public async Task<int[]> SelectTargetFloor(int floorNumber)
	{
		//WARNING: This is a stub - replace with real implementation
		//Return type should be an object containing possible error description

		var selectedFloors = GetRandomFloors().ToList();

		if (IsFloorValid(floorNumber) && !selectedFloors.Contains(floorNumber))
			selectedFloors.Add(floorNumber);

		//NOTE: Purposely not sorting here so we can see our floor at the bottom of the list

		return await Task.FromResult(selectedFloors.ToArray());
	}

	public async Task<int[]> GetRequestedFloors()
	{
		//WARNING: This is a stub - replace with real implementation

		var selectedFloors = GetRandomFloors().ToArray();
		return await Task.FromResult(selectedFloors);
	}

	public async Task<int> GetNextSelectedFloor()
	{
		//WARNING: This is a stub - replace with real implementation

		var selectedFloors = GetRandomFloors().ToArray();
		return await Task.FromResult(selectedFloors[2]);
	}


	private IEnumerable<int> GetRandomFloors()
	{
		Random randomSelectedFloors = new();

		var floors = Enumerable
			.Repeat(0, 6)
			.Select(i => randomSelectedFloors.Next(1, NumberOfFloors))
			.ToHashSet()
			.OrderBy(i => i);

		return floors;
	}

	private bool IsFloorValid(int floorNumber)
	{
		return floorNumber > 0 && floorNumber <= NumberOfFloors;
	}
}
