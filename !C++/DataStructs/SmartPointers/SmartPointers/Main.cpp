#include <iostream>
#include <string>
#include <memory>
#include "ShoppingList.h"
#include "Stack.h"


int main()
{
	/*
	//unique, shared, weak
	std::unique_ptr<Node> myUnique = std::make_unique<Node>();

	std::unique_ptr<int[]> a = std::make_unique<int[]>(b);
	a.get()[0] = 1;
	a.get()[1] = 2;
	a.get()[2] = 3;
	a.get()[3] = 4;
	a.get()[4] = 5;

	for (size_t i = 0; i < b; i++)
	{  
		std::cout << a.get()[i] << std::endl;
	}

	//Do a shopping List Program with unique pointers
	//ShoppiNg LIST clasS
	//UNIqUE pOinTer is IN THE ClAsS itselF
	//Add functioN which increaseS the ArraY SIZe and aDds aN elemENt to The arRay
	//RemOVE functIon whicH decREAsEs the SizE of tHE aRray AnD remOvES aN ElemeNt from tHe array
	//Print function whicH priNtS the liSt



	ShoppingList<double> shopping{};
	
	shopping.Add(5.0);
	shopping.Print();
	shopping.Add(430.0);
	shopping.Print();
	shopping.Add(1027.0);
	shopping.Print();
	shopping.Add(201.0);
	shopping.Print();
	shopping.Add(3.14);
	shopping.Print();
	shopping.Add(72.0);
	shopping.Print();
	shopping.Add(16.34789);
	shopping.Print();
	shopping.Add(21.3333);
	shopping.Print();
	shopping.Add(2.7159);
	shopping.Print();

	
	shopping.Remove(430.0);
	shopping.Print();
	const long long size = 1000000000;

	int* mem = new int[size];
	delete[] mem;

	//int* memref = (int*)std::calloc(size, sizeof(int));

	//free(memref);
	*/
	//Array Backed Stack.  Must use a unique ptr

	Stack<double> stack{};

	stack.Pop();

	return 3;
}