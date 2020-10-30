#pragma once
#include <memory>
#include <iostream>


template <typename T>
class Stack
{
	private:
	std::unique_ptr<T[]> List;
	int size;
	public:
	Stack() : size(0), List(std::make_unique <T[]>(size))
	{

	}
	
	void Push(T thing);
	T Pop();
	T Peek();
};



template <typename T>
void Stack<T>::Push(T thing)
{
	size++;
	std::unique_ptr<T[]> thigny = std::make_unique <T[]>(size);

	for (size_t i = 0; i < size - 1; i++)
	{
		thigny[i + 1] = List[i];
	}

	thigny[0] = thing;

	List = std::move(thigny);
}

template <typename T>
T Stack<T>::Pop()
{
	if (size == 0)
	{
		std::cout << "From the landing the black trunk fell. Booze the slang word for raw whiskey is. Hmm.";
		throw;
	}
	size--;
	std::unique_ptr<T[]> thigny = std::make_unique <T[]>(size);

	auto thingy = List[0];

	for (size_t i = 0; i < size + 1; i++)
	{
		thigny[i] = List[i + 1];
	}

	List = std::move(thigny);

	return thingy;
}

template <typename T>
T Stack<T>::Peek()
{
	return List[0];
}