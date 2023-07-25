namespace ElevatorControl.Services;

/// <summary>
/// Basic implementation of State Machine: add appropriate methods here to check and change elevator actions, such as moving up/down, emergency button pressed, etc.
/// </summary>
public class ElevatorState : IElevatorState
{
	private int _numberOfFloors; //number of floors in the building

	public IList<int> RequestedFloorQueue { get; set; }

	/// <summary>
	/// Constructor made private so the State Machine cannot be initiated without the number of floors
	/// </summary>
	private ElevatorState()
	{
		RequestedFloorQueue = new List<int>();
	}

	public ElevatorState(int numberOfFloors) : this()
	{
		_numberOfFloors = numberOfFloors;

		//NOTE: Populating Queue with dummy data - replace with real implementation!
		((List<int>)RequestedFloorQueue).AddRange(GetRandomFloors());
	}

	public void AddFloorToQueue(int floorNumber)
	{
		//NOTE: Purposely not sorting here so our floor numbers appear at the bottom
		if (IsFloorValid(floorNumber) && !RequestedFloorQueue.Contains(floorNumber))
			RequestedFloorQueue.Add(floorNumber);
	}

	public IEnumerable<int> GetRequestedFloors()
	{
		return RequestedFloorQueue;
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

	private bool IsFloorValid(int floorNumber)
	{
		return floorNumber > 0 && floorNumber <= _numberOfFloors;
	}
}
