namespace ElevatorControl.Services;

public interface IElevatorState
{
	void AddFloorToQueue(int floorNumber);
	IEnumerable<int> GetRequestedFloors();
}
