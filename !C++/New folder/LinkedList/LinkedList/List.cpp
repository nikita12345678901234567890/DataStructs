#include "List.h"

List::List()
{
	Head = nullptr;
}

void List::Add(int value)
{
	if (Head == nullptr)
	{
		Head = new Node(value);
		return;
	}
	Node* thing = Head;
	while (thing->next != nullptr)
	{
		thing = thing->next;
	}
	thing->next = new Node(value);
}

void List::Remove(int value)
{
	if (Head->value == value)
	{
		Head = Head->next;
		return;
	}
}

void List::Insert(int value, int place)
{

}