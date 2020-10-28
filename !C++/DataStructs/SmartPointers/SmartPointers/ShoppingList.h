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



template <typename T>
void ShoppingList<T>::Add(T thing)
{
	size++;
	std::unique_ptr<T[]> thigny = std::make_unique <T[]>(size);

	for (size_t i = 0; i < size - 1; i++)
	{
		thigny[i] = List[i];
	}

	thigny[size - 1] = thing;

	List = std::move(thigny);
}

template <typename T>
void ShoppingList<T>::Remove(T thing)
{
	size--;
	std::unique_ptr<T[]> thigny = std::make_unique <T[]>(size);

	for (size_t i = 0, j = 0; i < size + 1; i++, j++)
	{
		if (List[j] == thing)
		{
			j++;
		}
		thigny[i] = List[j];
	}

	thigny[size - 1] = thing;

	List = std::move(thigny);
}

template <typename T>
void ShoppingList<T>::Print()
{
	for (size_t i = 0; i < size; i++)
	{
		std::cout << List[i] << std::endl;
	}
	std::cout << std::endl;
}