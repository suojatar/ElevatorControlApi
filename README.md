**ElevatorControlApi**

This API exposes four endpoints with actions mimicking Elevator Control:

1) GET: /Elevator/FetchToFloor/floorNumber - calls the elevator upon passenger request from outside the car;
2) PUT: /Elevator/SelectTargetFloor - adds the floor selected by passenger from inside the car to the list of floors at which the elevator will stop;
3) GET: /Elevator/GetRequestedFloors - returns a list of floors selected by all passengers during the current trip;
4) GET: /Elevator/GetNextFloor - shows the next floor at which the elevator will stop.

All actions are stubs operating on artificial values. Actual implementation is required to make the API truly operational.

INSTRUCTIONS:
Clone the repository in Visual Studio; build and run the project project.

Request URLs:

http://localhost:8080/Elevator/FetchToFloor/floorNumber?floorNumber=12 
http://localhost:8080/Elevator/SelectTargetFloor?floorNumber=8
http://localhost:8080/Elevator/GetRequestedFloors
http://localhost:8080/Elevator/GetNextFloor

Swagger Doc:

http://localhost:8080/swagger/index.html
