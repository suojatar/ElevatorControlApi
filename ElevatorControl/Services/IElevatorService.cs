namespace ElevatorControl.Services;

public interface IElevatorService
{
	/// <summary>
	/// Brings the elevator to desired floor when requested by passenger outside the car
	/// </summary>
	/// <returns>Array of floor numbers to serve prior to the selected floor</returns>
	Task<int[]> PressButtonFromFloor(int floorNumber);

	/// <summary>
	/// Adds a floor to the array of selected floors and instructs the elevator to stop at that floor.
	/// Based on implementation, may highlight the given floor inside the cabin.
	/// </summary>
	/// <returns>Array of floor numbers with the new floor added</returns>
	Task<int[]> PressButtonFromCabin(int floorNumber);

	/// <summary>
	/// Gets all floor numbers requested by passengers inside the car
	/// </summary>
	/// <returns>Array of floor numbers</returns>
	Task<int[]> GetRequestedFloors();

	/// <summary>
	/// Gets the next floor the elevator will stop at
	/// </summary>
	/// <returns>Number of next floor to stop at</returns>
	Task<int> GetNextSelectedFloor();
}
