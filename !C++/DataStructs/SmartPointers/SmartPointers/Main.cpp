#include <iostream>
#include <string>
#include <memory>
#include "ShoppingList.h"

int main()
{
	int b = 5;

	//int* a = new int[b];

	//a[0] = 1;
	//a[1] = 2;
	//a[2] = 3;
	//a[3] = 4;
	//a[4] = 5;

	//unique, shared, weak
	/*std::unique_ptr<Node> myUnique = std::make_unique<Node>();

	std::unique_ptr<int[]> a = std::make_unique<int[]>(b);
	a.get()[0] = 1;
	a.get()[1] = 2;
	a.get()[2] = 3;
	a.get()[3] = 4;
	a.get()[4] = 5;

	for (size_t i = 0; i < b; i++)
	{  
		std::cout << a.get()[i] << std::endl;
	}*/

	//Do a shopping List Program with unique pointers
	//ShoppiNg LIST clasS
	//UNIqUE pOinTer is IN THE ClAsS itselF
	//Add functioN which increaseS the ArraY SIZe and aDds aN elemENt to The arRay
	//RemOVE functIon whicH decREAsEs the SizE of tHE aRray AnD remOvES aN ElemeNt from tHe array
	//Print function whicH priNtS the liSt

	ShoppingList<double> shopping{};
	


	return 3;
}