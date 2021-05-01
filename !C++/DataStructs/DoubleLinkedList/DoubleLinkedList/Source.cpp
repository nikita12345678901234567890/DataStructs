#include <iostream>
#include "Node.h"
#include "DoubleLinkList.h"

int main()
{
	DoubleLinkList<int> list{};

	list.AddFirst(10);

	list.AddFirst(9);

	list.AddLast(13);

	list.AddBefore(13, 12);

	list.AddAfter(10, 11);

	list.Print();

	std::cout << std::endl;

	list.Remove(11);

	list.RemoveFirst();

	list.RemoveLast();

	list.Print();

	std::cout << std::endl;

	std::cout << list.Contains(5) << std::endl;

	std::cout << list.Contains(10) << std::endl;

	std::cout << std::endl;

	list.Remove(10);
	list.Remove(12);

	list.Remove(9);


	for (size_t i = 0; i < 12000; i++)
	{
		list.AddFirst(i);
	}

	//Fix the crashing when deleting the smartpointers

}

/*

Stupid things I've done:

not incrementing size

not doing word = word.next in loops

writing '.' instead of '->'

not using .lock()

*/