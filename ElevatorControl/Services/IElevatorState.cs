namespace ElevatorControl.Services;

public interface IElevatorState
{
	void CallFromFloor(int floorNumber);
	void CallFromCabin(int floorNumber);
	IEnumerable<int> GetAllRequestedFloors();
	public int GetNextRequestedFloor();
	bool IsFloorValid(int floorNumber);
}
