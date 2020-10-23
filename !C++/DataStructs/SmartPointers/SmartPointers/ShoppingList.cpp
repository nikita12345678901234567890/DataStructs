#include "ShoppingList.h"

template <typename T>
void ShoppingList<T>::Add(T thing)
{
	size++;
	std::unique_ptr<T[]> thigny = std::make_unique <T[]>(size);

	for (size_t i = 0; i < size - 1; i++)
	{
		thigny.get()[i] = List.get()[0];
	}
}

template <typename T>
void ShoppingList<T>::Remove(T thing)
{

}

template <typename T>
void ShoppingList<T>::Print()
{

}