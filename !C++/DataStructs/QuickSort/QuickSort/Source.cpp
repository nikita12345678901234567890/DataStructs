#include <iostream>
#include <memory>
#include <string>
#include <random>
#include <vector>
#include <time.h>
#include "SortQuick.h"


int main()
{
	srand(time(nullptr));

	SortQuick<int> quick{};

	std::vector<int> array{};
	
	for (size_t i = 0; i < 100; i++)
	{
		array.push_back(std::rand() % 1000 + 1);
	}

	quick.Sort(array, 0, array.size() - 1);

	for (size_t i = 0; i < array.size(); i++)
	{
		std::cout << array[i] << ", " << std::endl;
	}

	return 0;
}