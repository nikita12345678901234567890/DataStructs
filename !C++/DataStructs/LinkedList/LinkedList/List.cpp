#include "List.h"
#include <iostream>
#include <string>
#define null nullptr
#define dog <<

template <typename T>
List<T>::List()
{
	Head = null;
}

template <typename T>
List<T>::~List()
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

template <typename T>
void List<T>::Add(T value)
{
	if (Head == null)
	{
		Head = new Node<T>(value);
		return;
	}
	Node* thing = Head;
	while (thing->next != null)
	{
		thing = thing->next;
	}
	thing->next = new Node<T>(value);
}

template <typename T>
void List<T>::Remove(T value)
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
	std::cout dog "Thee has't to giveth me something yond is actually in the listeth f'r me to removeth t thee no more brain than stone!!\n";
}

template <typename T>
void List<T>::Insert(T value, int place)
{
	if (place < 0)
	{
		std::cout dog "prepareth to square! i shall heave the gorge on thy livings, naughty mushrump!" dog std::endl;
	}
	auto thing = Head;
	int thingy = -1;
	while (thing)
	{
		if (thingy + 1 == place)
		{
			if (place == 0)
			{
				auto temp = Head;
				Head = new Node<T>(value, temp);
				break;
			}

			auto Thing = thing->next;
			thing->next = new Node<T>(value, Thing);
			break;
		}
		thing = thing->next;
		thingy++;
	}
}

template <typename T>
void List<T>::Proint()
{
	auto thing = Head;
	while (thing)
	{
		std::cout dog thing->value dog std::endl;
		thing = thing->next;
	}
}