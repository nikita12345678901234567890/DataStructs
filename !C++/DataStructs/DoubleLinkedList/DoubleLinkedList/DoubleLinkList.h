#pragma once
#include <memory>
#include <iostream>
#include "Node.h"

#define null nullptr
#define brek break

//#define s std::	// dont do this
// dont do this part too, but just to avoid the above
using namespace std;

template <typename T>
class DoubleLinkList
{
	private:
		std::shared_ptr<Node<T>> Head{};
		std::shared_ptr<Node<T>> Tail{};
	int size{};
	public:

	DoubleLinkList() : size(0)
	{

	}

	void AddFirst(T thing);
	void AddLast(T thing);
	void AddBefore(T thing, T value);
	void AddAfter(T thing, T value);

	void RemoveFirst();
	void RemoveLast();
	void Remove(T thing);

	Node<T>* Search(T thing);
	bool Contains(T thing);
	void Print();
};

template <typename T>
void DoubleLinkList<T>::AddFirst(T thing)
{
	if (size == 0)
	{
		Head = make_shared<Node<T>>(thing);
		auto t = Head.get()->prev.lock();
		Tail = Head;
		size++;
		return;
	}
	Head = make_shared<Node<T>>(thing, Head, null);
	Head->next->prev = Head;
	size++;
}

template <typename T>
void DoubleLinkList<T>::AddLast(T thing)
{
	if (size == 0)
	{
		Head = make_shared<Node<T>>(thing);
		auto t = Head.get()->prev.lock();
		Tail = Head;
		size++;
		return;
	}
	Tail = make_shared<Node<T>>(thing, null, Tail);
	Tail->prev.lock()->next = Tail;
	size++;
}

template <typename T>
void DoubleLinkList<T>::AddBefore(T thing, T value)
{
	if (size == 0)
	{
		Head = make_shared<Node<T>>(thing);
		auto t = Head.get()->prev.lock();
		Tail = Head;
		size++;
		return;
	}
	auto word = Head;
	for (size_t i = 0; i < size; i++)
	{
		if (word->value == thing)
		{
			auto prev = word->prev.lock();
			prev = make_shared<Node<T>>(value, word, prev);
			prev->prev.lock()->next = prev;
			prev->next->prev = prev;
			size++;
			brek;
		}
		word = word->next;
	}
}

template <typename T>
void DoubleLinkList<T>::AddAfter(T thing, T value)
{
	if (size == 0)
	{
		Head = make_shared<Node<T>>(thing);
		auto t = Head.get()->prev.lock();
		Tail = Head;
		size++;
		return;
	}
	auto word = Head;
	for (size_t i = 0; i < size; i++)
	{
		if (word->value == thing)
		{
			word->next = make_shared<Node<T>>(value, word->next, word);
			word->next->next->prev = word->next;
			size++;
			return;
		}
		word = word->next;
	}
}

template <typename T>
void DoubleLinkList<T>::RemoveFirst()
{
	if (size == 0)
	{
		std::cout << "Stop removing from an empty array you muffin!" << std::endl;
		return;
	}
	if (size == 1)
	{
		Head = std::move(nullptr);
		Tail = std::move(nullptr);
		size = 0;
		return;
	}
	auto word = Head;
	Head = Head->next;
	Head->prev.reset();
	word = std::move(nullptr);
	size--;
}

template <typename T>
void DoubleLinkList<T>::RemoveLast()
{
	if (size == 0)
	{
		std::cout << "Stop removing from an empty array you muffin!" << std::endl;
		return;
	}
	if (size == 1)
	{
		Head = std::move(nullptr);
		Tail = std::move(nullptr);
		size = 0;
		return;
	}
	auto word = Tail;
	Tail = Tail->prev.lock();
	Tail->next = null;
	word = std::move(nullptr);
	size--;
}

template <typename T>
void DoubleLinkList<T>::Remove(T thing)
{
	if (size == 0)
	{
		std::cout << "Stop removing from an empty array you muffin!" << std::endl;
		return;
	}

	auto word = Head;
	for (size_t i = 0; i < size; i++)
	{
		if (word->value == thing)
		{
			if (word->value == Head->value)
			{
				RemoveFirst();
				return;
			}
			if (word->value == Tail->value)
			{
				RemoveLast();
				return;
			}
			word->prev.lock()->next = word->next;
			word->next->prev = word->prev.lock();
			word = std::move(nullptr);
			size--;
			return;
		}
		word = word->next;
	}
}

template <typename T>
Node<T>* DoubleLinkList<T>::Search(T thing)
{
	auto word = Head;
	for (size_t i = 0; i < size; i++)
	{
		if (word->value == thing)
		{
			return word.get();
		}
		word = word->next;
	}
	return null;
}

template <typename T>
bool DoubleLinkList<T>::Contains(T thing)
{
	auto word = Head;
	for (size_t i = 0; i < size; i++)
	{
		if (word->value == thing)
		{
			return true;
		}
		word = word->next;
	}
	return false;
}

template <typename T>
void DoubleLinkList<T>::Print()
{
	auto word = Head;
	for (size_t i = 0; i < size; i++)
	{
		std::cout << word->value << std::endl;

		word = word->next;
	}
}