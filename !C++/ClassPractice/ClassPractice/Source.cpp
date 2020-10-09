#include "Demo.h"
#include "Car.h"
#include <iostream>
#include <vector>

int main()
{
	//Create a Car class
		//Model
		//Year
		//Make
		//Color
		//Displasement
		//engine type
		//chris factor

	//Vector with 4 cars
	//Display all information about the cars

	std::vector<Car> cars;

	cars.push_back(Car("Toyota", "Tacoma", 2002, "White", 2.7, "I4", 0));
	cars.push_back(Car("BMW", "M240i", 2017, "Blue", 3.0, "I6", 10));
	cars.push_back(Car("BMW", "328i", 2016, "White", 2.0, "I4", 5));
	cars.push_back(Car("Toyota", "Corolla", 2020, "White", 2, "I4", 0));

	for (Car car : cars)
	{
		std::cout << car.GetMake() << car.GetModel() << car.GetYear() << car.GetColor() << car.GetDisplacement() << car.GetEngineType() << car.GetChrisFactor() << std::endl;
	}

	return 0;
}