#include <iostream>
#include "TreeHeap.h"

int main()
{
	std::vector<int> input = { 10, 305, 23, 325, 6, 563, 2, 343, 56, 6, 7, 54 };

	TreeHeap<int> heap = new TreeHeap<int>(true);

	auto doesthiswork = heap.YEETSort(input);

	/*TreeHeap<int> tree(true);

	srand(time(nullptr));

	for (size_t i = 0; i < 100; i++)
	{
		tree.Insert(std::rand() % 1000 + 1);
	}

	for (size_t i = 0; i < 100; i++)
	{
		std::cout << tree.Pop() << std::endl;
	}*/

	return 0;
}