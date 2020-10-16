#include "List.h"
#include <iostream>
#include <string>
#define null nullptr

List::List()
{
	Head = null;
}

List::~List()
{
	auto thing = Head;
	while (thing)
	{

		auto thingy = thing->next;
		delete thing;
		thing = thingy;
	}
	;
}

void List::Add(int value)
{
	if (Head == null)
	{
		Head = new Node(value);
		return;
	}
	Node* thing = Head;
	while (thing->next != null)
	{
		thing = thing->next;
	}
	thing->next = new Node(value);
}

void List::Remove(int value)
{
	if (Head->value == value)
	{
		auto yeet = Head;
		Head = Head->next;
		delete yeet;
		return;
	}

	Node* thingy = Head;
	while (thingy->next != null)
	{
		if (thingy->next->value == value)
		{
			auto Thing = thingy->next;
			thingy->next = thingy->next->next;
			delete Thing;
			return;
		}
		thingy = thingy->next;
	}
	std::cout << "Thee has't to giveth me something yond is actually in the listeth f'r me to removeth t thee no more brain than stone!!\n";
}

void List::Insert(int value, int place)
{

}

//print list function
//destructor