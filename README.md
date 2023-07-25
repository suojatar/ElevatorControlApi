**ElevatorControlApi**

This API exposes four endpoints with actions mimicking Elevator Control:

1) PUT: /Elevator/CallFromFloor - calls the elevator upon passenger request from outside the car;
2) PUT: /Elevator/SelectFromCabin - adds the floor selected by passenger from inside the car to the list of floors at which the elevator will stop;
3) GET: /Elevator/SelectedFloors/All - returns a list of floors selected by all passengers during the current trip;
4) GET: /Elevator/SelectedFloors/Next - shows the next floor at which the elevator will stop.

All actions are stubs operating on artificial values. Actual implementation is required to make the API truly operational.

INSTRUCTIONS:
Clone the repository in Visual Studio; build and run the project project.

Request URLs:

http://localhost:8080/Elevator/CallFromFloor
http://localhost:8080/Elevator/SelectFromCabin
http://localhost:8080/Elevator/SelectedFloors/All
http://localhost:8080/Elevator/SelectedFloors/Next

Swagger Doc:

http://localhost:8080/swagger/index.html
