#pragma once
#include <memory>
#include <iostream>
#include "Node.h"

//#define s std::	// dont do this
// dont do this part too, but just to avoid the above
using namespace std;

template <typename T>
class DoubleLinkList
{
	private:
	std::unique_ptr<Node<T>> Head;
	std::unique_ptr<Node<T>> Tail;
	int size;
	public:

	DoubleLinkList() : size(0), List(std::make_unique <T[]>(size))
	{

	}

	void AddFirst(T thing);
	void AddLast(T thing);
	void AddBefore(T thing, T value);
	void AddAfter(T thing, T value);

	void RemoveFirst(T thing);
	void RemoveLast(T thing);
	void Remove(T thing);

	Node<T>* Search(T thing);
	bool Contains(T thing);
	void Print();
};

//not circle!!!!!!

template <typename T>
void DoubleLinkList<T>::AddFirst(T thing)
{
	if (size == 0)
	{
		Head = make_unique<Node<T>>(thing);
		Tail = Head;
		Head.next = Tail;
		Head.prev = Tail;
		Tail.next = Head;
		Tail.prev = Head;
		return;
	}
	Head = make_unique<Node<T>>(thing, Head, Tail);
}

template <typename T>
void DoubleLinkList<T>::AddLast(T thing)
{
	if (size == 0)
	{
		Head = make_unique<Node<T>>(thing);
		Tail = Head;
		Head.next = Tail;
		Head.prev = Tail;
		Tail.next = Head;
		Tail.prev = Head;
		return;
	}
	Head = make_unique<Node<T>>(thing, Head, Tail);
}

template <typename T>
void DoubleLinkList<T>::AddBefore(T thing, T value)
{

}

template <typename T>
void DoubleLinkList<T>::AddAfter(T thing, T value)
{

}

template <typename T>
void DoubleLinkList<T>::RemoveFirst(T thing)
{

}

template <typename T>
void DoubleLinkList<T>::RemoveLast(T thing)
{

}

template <typename T>
void DoubleLinkList<T>::Remove(T thing)
{

}

template <typename T>
Node<T>* DoubleLinkList<T>::Search(T thing)
{

}

template <typename T>
bool DoubleLinkList<T>::Contains(T thing)
{

}

template <typename T>
void DoubleLinkList<T>::Print()
{

}