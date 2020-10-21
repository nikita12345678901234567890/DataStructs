#pragma once
#include "Node.h"

template <typename T>
class List
{
	private:
		Node<T>* Head;

	public:
		List<T>();
		~List<T>();
		
		void Add(T value);
		void Remove(T value);
		void Insert(T value, int place);
		void Proint();
};