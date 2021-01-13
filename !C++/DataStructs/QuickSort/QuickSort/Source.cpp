#include <iostream>
#include <memory>
#include <string>
#include <random>
#include <vector>
#include "SortQuick.h"

int main()
{
	SortQuick<int> quick{};

	std::vector<int> array = { 7, 4, 3, 6, 2, 1, 5 };

	quick.Sort(array, 0, array.size() - 1);

	for (size_t i = 0; i < array.size(); i++)
	{
		std::cout << array[i] << ", " << std::endl;
	}

	return 0;
}