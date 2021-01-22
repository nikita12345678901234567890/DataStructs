#include <iostream>
#include "TreeHeap.h"

int main()
{


	TreeHeap<int> tree(true);

	srand(time(nullptr));

	for (size_t i = 0; i < 100; i++)
	{
		tree.Insert(std::rand() % 1000 + 1);
	}

	for (size_t i = 0; i < 100; i++)
	{
		std::cout << tree.Pop() << std::endl;
	}

	return 0;
}