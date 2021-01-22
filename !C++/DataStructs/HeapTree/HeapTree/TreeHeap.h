#pragma once
#include <vector>

template<typename T>
class TreeHeap
{
private:

	std::vector<T> array{};

	void HeapifyUp(int index);
	void HeapifyDown(int index);
	int FindParent(int index);
	int FindLeft(int index);
	int FindRight(int index);

public:

	bool min;

	TreeHeap(bool min) : min(min) {}

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
	if (min)
	{
		if (FindLeft(index) >= array.size())
		{
			return;
		}

		int swap = 0;

		if (FindRight(index) >= array.size())
		{
			swap = FindLeft(index);
		}
		else
		{
			if (array[FindLeft(index)] < array[FindRight(index)])
			{
				swap = FindLeft(index);
			}
			else
			{
				swap = FindRight(index);
			}
		}

		if (array[swap] < array[index])
		{
			T temp = array[index];
			array[index] = array[swap];
			array[swap];
			array[swap] = temp;
		}

		HeapifyDown(swap);
	}




	/*for (size_t i = 0; i < array.size(); i++)
	{
		if (min)
		{
			if ((FindLeft(index) < array.size() && FindRight(index) < array.size() && array[FindLeft(index)] < array[FindRight(index)]) || FindLeft(index) < array.size() && FindRight(index) >= array.size() || (FindLeft(index) < array.size() && FindRight(index) >= array.size() && array[index] > array[FindLeft(index)]) || (FindLeft(index) >= array.size() && FindRight(index) < array.size() && array[index] > array[FindRight(index)]))
			{
				T thing = array[index];
				array[index] = array[FindLeft(index)];
				array[FindLeft(index)] = thing;
				index = FindLeft(index);
			}
			if ((FindLeft(index) < array.size() && FindRight(index) < array.size() && array[FindLeft(index)] > array[FindRight(index)]) || FindLeft(index) >= array.size() && FindRight(index) < array.size() || (FindLeft(index) < array.size() && FindRight(index) >= array.size() && array[index] > array[FindLeft(index)]) || (FindLeft(index) >= array.size() && FindRight(index) < array.size() && array[index] > array[FindRight(index)]))
			{
				T thing = array[index];
				array[index] = array[FindRight(index)];
				array[FindRight(index)] = thing;
				index = FindRight(index);
			}
		}
		else
		{
			if ((FindLeft(index) < array.size() && FindRight(index) < array.size() && array[FindLeft(index)] > array[FindRight(index)]) || FindLeft(index) < array.size() && FindRight(index) >= array.size())
			{
				T thing = array[index];
				array[index] = array[FindLeft(index)];
				array[FindLeft(index)] = thing;
				index = FindLeft(index);
			}
			if ((FindLeft(index) < array.size() && FindRight(index) < array.size() && array[FindLeft(index)] < array[FindRight(index)]) || FindLeft(index) >= array.size() && FindRight(index) < array.size())
			{
				T thing = array[index];
				array[index] = array[FindRight(index)];
				array[FindRight(index)] = thing;
				index = FindRight(index);
			}
		}
	}*/
}

template<typename T>
int TreeHeap<T>::FindParent(int index)
{
	return (index - 1) / 2;
}

template<typename T>
int TreeHeap<T>::FindLeft(int index)
{
	return index + (index + 1);
}

template<typename T>
int TreeHeap<T>::FindRight(int index)
{
	return index + (index + 2);
}

template<typename T>
void TreeHeap<T>::Insert(T value)
{
	array.push_back(value);
	if (array.size() > 1)
	{
		HeapifyUp(array.size() - 1);
	}
}

template<typename T>
T TreeHeap<T>::Pop()
{
	T thing = array[0];
	array[0] = array[array.size() - 1];
	array.erase(array.begin() + (array.size() - 1));
	HeapifyDown(0);
	return thing;
}