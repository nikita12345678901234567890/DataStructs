#pragma once
#include "Node.h"

class List
{
	private:
		Node* Head;

	public:
		List();
		void Add(int value);
		void Remove(int value);
		void Insert(int value, int place);
};