#pragma once
#include <memory>
#include <iostream>

template <typename T>
class ShoppingList
{
	private:
	std::unique_ptr<T[]> List;
	int size;
public:
	ShoppingList() : size(0), List(std::make_unique <T[]>(size))
	{
		
	}

	void Add(T thing);
	void Remove(T thing);
	void Print();

};