#include <iostream>
#include "TreeHeap.h"

int main()
{


	auto size = sizeof(long);
	TreeHeap<int> tree(true);

	tree.Insert(33);
	tree.Insert(47);
	tree.Insert(92);
	tree.Insert(1);
	tree.Insert(8);
	tree.Insert(-10);
	tree.Insert(23);


	for (size_t i = 0; i < 7; i++)
	{
		std::cout << tree.Pop() << std::endl;
	}

	return 0;
}