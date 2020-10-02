#include <iostream>
#include <array>
#include <string>
#include <vector>
#include <cmath>

int sum(int* numbers, size_t size)
{
	int sumval = 0;

	for (size_t i = 0; i < size; i++)
	{
		sumval += numbers[i];
	}

	return sumval;
}

// pass by pointer
void swap(int* x, int* y)
{
	int temp = *x;
	*x = *y;
	*y = temp;
}


// pass by reference
void swap(int& x, int& y)
{
	int temp = x;
	x = y;
	y = temp;
}

int hecDec(std::string hex)
{
	int thing = 0;
	int count = hex.length()-1;
	for (char c : hex)
	{
		int temp = 0;
		if (c >= '0' && c < '9')
		{
			temp = c-48;
		}
		else
		{
			switch (c)
			{
			case 'a':
				temp = 10;
				break;
			case 'b':
				temp = 11;
				break;
			case 'c':
				temp = 12;
				break;
			case 'd':
				temp = 13;
				break;
			case 'e':
				temp = 14;
				break;
			case 'f':
				temp = 15;
				break;
			}
		}

		thing += temp * std::pow(16, count);

		count--;
	}
	return thing;
}

void sort(std::vector<int>& list)
{
	int counter = 0;
	for (size_t j = 0; j < list.size(); j++)
	{
		for (size_t i = 0; i < list.size() - j - 1; i++)
		{
			if (list[i] > list[i + 1])
			{
				auto temp = list[i];
				list[i] = list[i + 1];
				list[i + 1] = temp;
			}
		}
	}
}

bool IsSorted(std::vector<int>& list)
{
	int prev = list[0];
	for (int thing : list)
	{
		if (thing < prev)
		{
			return false;
		}
		prev = thing;
	}
	return true;
}

bool linearSearch(std::vector<int>& list, int thing)
{
	for (int thingy : list)
	{
		if (thingy == thing)
		{
			return true;
		}
	}
	return false;
}

bool binarySearch(std::vector<int>& list, int thing)
{
	if (IsSorted(list))
	{
		/*int thingy = list.size() / 2;
		for (int i = 0; i < list.size(); i++)
		{
			if (list[thingy] == thing)
			{
				return true;
			}
			else if (list[thingy] < thing)
			{
				thingy = (list.size() - thingy) / 2;
			}
			else
			{
				thingy = ((list.size() - thingy) / 2) + thingy;
			}
		}
		return false;*/
		int min = 0;
		int max = list.size();
		while (min < max)
		{
			int center = (min + max) / 2;
			if (list[center] == thing)
			{
				return true;
			}
			if (thing > list[center])
			{
				min = center + 1;
			}
			if (thing < list[center])
			{
				max = center - 1;
			}
		}
	}
	return false;
}

int main()
{
	/*
	//int numbers[3];	// allocate an array of length 3 on the stack


	//const int size = 3;

	//int arr[size];


	int numbers[] = { 5,6,3,3 };
	for (auto& num : numbers)
	{
		std::cout << num << std::endl;
	}

	//int x = 5;

	//int* xpointer = &x;


	//std::cout << x << std::endl;

	//std::cout << xpointer << std::endl;

	//std::cout << *xpointer << std::endl;		// * before pointer variable is called dereferencing the pointer (since pointer is a reference), give me the value at that address


	//std::cout << &xpointer << std::endl;

	//int** xpointerpointer = &xpointer;

	//*xpointer = 6;


	int numbers[] = { 5,6,-1 };

	std::cout << sum(numbers, 3) << std::endl;


	for (size_t i = 0; i < 3; i++)
	{
		std::cout << numbers[i] << " = " << &numbers[i] << std::endl;
	}


	std::cout << &numbers << std::endl;


	int* numberarray = numbers;

	std::cout << numberarray << std::endl;
	std::cout << *numberarray << std::endl;


	//std::array<int, 3> numbers = { 4,5,6 };


	//// size_t is shorthand for unsigned int

	//for(size_t i = 0; i < numbers.size(); i++)
	//{
	//	std::cout << numbers[i] << std::endl;
	//}


	// ask the user for 5 numbers and store them in an array, print out their valuse and their memory address

	std::array<int, 5> numbers{};

	for (size_t i = 0; i < numbers.size(); i++)
	{
		int val = 0;
		std::cin >> val;

		numbers[i] = val;
	}
	for (size_t i = 0; i < numbers.size(); i++)
	{
		std::cout << numbers[i] << "\n" << &numbers[i] << "\n";
	}


	// create a function called swap, that takes in two int pointers and swaps their values

	//int x = 5;
	//int y = 7;

	////swap(&x, &y);
	//swap(x, y);

	//std::cout << x << "\n" << y << "\n";
	*/

	/* ask the user for a hex string, convert it to decimal

	std::string thing;
	std::cin >> thing;

	std::cout << hecDec(thing);*/

	//Create a simple sort function


	std::vector<int> list{};

	list.push_back(2);
	list.push_back(83);
	list.push_back(1);
	list.push_back(8);
	list.push_back(6);
	///*

	//for (size_t i = 0; i < list.size(); i++)
	//{
	//	std::cout << list[i] << "\n";
	//}

	//for (auto thing : list)
	//{
	//	std::cout << thing << "\n";
	//}

	//list.erase(list.begin()+1);

	//for (size_t i = 0; i < list.size(); i++)
	//{
	//	std::cout << list[i] << "\n";
	//}*/

	sort(list);
	bool temp = binarySearch(list, 3);



	for (int i = 0; i < 100; i++)
	{
		bool result = linearSearch(list, i);

		if (result == true)
		{
			std::cout << i << std::endl;
		}
	}


	return 0;
}