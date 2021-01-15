#pragma once
#include <vector>

template<typename T>
class TreeHeap
{
private:

	std::vector<T> array();

	void HeapifyUp(int index);
	void HeapifyDown(int index);
	int FindParent(int index);
	int FindLeft(int index);
	int FindRight(int index);

public:

	bool min;

	TreeHeap(bool min) : min(min);

	void Insert(T value);
	T Pop();

};


template<typename T>
void TreeHeap<T>::HeapifyUp(int index)
{
	if (index == 0)
	{
		return;
	}
	for (size_t i = 0; i < array.size(); i++)
	{
		if (min)
		{
			if (array[index] < array[FindParent(index)])
			{
				T thing = array[index];
				array[index] = array[FindParent(index)];
				array[FindParent(index)] = thing;
				index = FindParent(index);
			}
		}
		else
		{
			if (array[index] > array[FindParent(index)])
			{
				T thing = array[index];
				array[index] = array[FindParent(index)];
				array[FindParent(index)] = thing;
				index = FindParent(index);
			}
		}
	}
}

template<typename T>
void TreeHeap<T>::HeapifyDown(int index)
{
	for (size_t i = 0; i < array.size(); i++)
	{
		if (min)
		{
			if ((FindLeft(index) < array.size()))
			{
				T thing = array[index];
				array[index] = array[FindLeft(index)];
				array[FindLeft(index)] = thing;
				index = FindLeft(index);
			}
			if ()
			{
				T thing = array[index];
				array[index] = array[FindRight(index)];
				array[FindRight(index)] = thing;
				index = FindRight(index);
			}
		}
		else
		{
			if ()
			{
				T thing = array[index];
				array[index] = array[FindLeft(index)];
				array[FindLeft(index)] = thing;
				index = FindLeft(index);
			}
			if ()
			{
				T thing = array[index];
				array[index] = array[FindRight(index)];
				array[FindRight(index)] = thing;
				index = FindRight(index);
			}
		}
	}
}

template<typename T>
int TreeHeap<T>::FindParent(int index)
{

}

template<typename T>
int TreeHeap<T>::FindLeft(int index)
{

}

template<typename T>
int TreeHeap<T>::FindRight(int index)
{

}

template<typename T>
void TreeHeap<T>::Insert(T value)
{

}

template<typename T>
T TreeHeap<T>::Pop()
{

}