#pragma once
#include <iostream>
#include <memory>
#include <stack>
#include <vector>
#define null nullptr

template <typename T>
class SortQuick
{
private:


public:

	SortQuick()
	{

	}

    void Sort(std::vector<T>& array, int start, int end);
    std::vector<T> Sort2(std::vector<T>& array, int start, int end);

    int Partition(std::vector<T>& array, int start, int end);
    int Partition2(std::vector<T>& array, int start, int end);
};


template<typename T>
void SortQuick<T>::Sort(std::vector<T>& array, int start, int end)
{
    if (start < end)
    {
        int pivot = Partition(array, start, end);
        Sort(array, start, pivot - 1);
        Sort(array, pivot + 1, end);
    }

    //return array;
}

template<typename T>
int SortQuick<T>::Partition(std::vector<T>& array, int start, int end)
{
    int pivot = end;
    int wall = start - 1;

    for (size_t i = start; i < end; i++)
    {
        if (array[i] < array[pivot])
        {
            wall++;
            std::swap(array[i], array[wall]);
            /*auto thingy = array[i];
            array[i] = array[wall];
            array[wall] = thingy;*/
        }
    }

   /* auto thingy = array[pivot];
    array[pivot] = array[wall + 1];
    array[wall + 1] = thingy;*/
    wall++;
    std::swap(array[pivot], array[wall]);
    return wall;
}

template<typename T>
std::vector<T> SortQuick<T>::Sort2(std::vector<T>& array, int start, int end)
{
    if (start < end)
    {
        int pivot = Partition2(array, start, end);
        Sort2(array, start, pivot + 1);
        Sort2(array, pivot - 1, end);
    }

    return array;
}

template<typename T>
int SortQuick<T>::Partition2(std::vector<T>& array, int start, int end)
{
    int pivot = start;
    while (start <= end)
    {
        while (array[start] >= array[pivot])
        {
            start++;
        }
        while (array[end] < array[pivot])
        {
            end--;
        }
        auto thingy = array[start];
        array[start] = array[end];
        array[end] = thingy;
    }

    return pivot;
}