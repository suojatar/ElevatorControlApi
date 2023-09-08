namespace ElevatorControl.Services;

/// <summary>
/// Basic implementation of State Machine: add appropriate methods here to check and change elevator actions,
/// such as moving up/down, emergency button pressed, removing floors from queue, etc.
/// </summary>
public class ElevatorState : IElevatorState
{
	private int _numberOfFloors; //number of floors in the building

	private List<int> RequestedFloorQueue { get; set; }

	/// <summary>
	/// Constructor made private so the State Machine cannot be initiated without the number of floors
	/// </summary>
	private ElevatorState()
	{
		RequestedFloorQueue = new();
	}

	public ElevatorState(int numberOfFloors) : this()
	{
		_numberOfFloors = numberOfFloors;

		//NOTE: Populating Queue with dummy data - replace with real implementation!
		RequestedFloorQueue.AddRange(GetRandomFloors());
	}

	/// <summary>
	/// Add requested floor to the end of the queue so that the requested floor is served AFTER all previous requests have been fulfilled
	/// </summary>
	/// <param name="floorNumber"></param>
	public void CallFromFloor(int floorNumber)
	{
		AddFloorToQueue(floorNumber);
	}

	/// <summary>
	/// Insert requested floor into the queue so that it is served consecutively
	/// </summary>
	/// <param name="floorNumber"></param>
	public void CallFromCabin(int floorNumber)
	{
		AddFloorToQueue(floorNumber);
		RequestedFloorQueue.Sort();
	}

	public bool IsFloorValid(int floorNumber)
	{
		return floorNumber > 0 && floorNumber <= _numberOfFloors;
	}

	public IEnumerable<int> GetAllRequestedFloors()
	{
		return RequestedFloorQueue;
	}

	public int GetNextRequestedFloor()
	{
		return RequestedFloorQueue[2]; //just returning something from the queue
	}


	private void AddFloorToQueue(int floorNumber)
	{
		if (IsFloorValid(floorNumber) && !RequestedFloorQueue.Contains(floorNumber))
			RequestedFloorQueue.Add(floorNumber);
	}

	private IEnumerable<int> GetRandomFloors()
	{
		Random randomSelectedFloors = new();

		var floors = Enumerable
				.Repeat(0, 6)
				.Select(i => randomSelectedFloors.Next(1, _numberOfFloors))
				.ToHashSet()
				.OrderBy(i => i);

		return floors;
	}
}
