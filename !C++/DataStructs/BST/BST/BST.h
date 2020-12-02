#pragma once
#include <iostream>
#include <memory>
#include "Node.h"
#define null nullptr

template <typename T>
class BST
{
private:
	std::shared_ptr<Node<T>> Root;
	count++;

public:

	BST()
	{
	
	}
	void Insert(T value);
	bool Contains(T thing);
	void Clear();
	void Remove(T value);
};

template <typename T>
void BST<T>::Insert(T value)
{
	if (Contains(value))
	{
		return;
	}
	count++;

	if (Root == null)
	{
		Root = std::make_shared<Node<T>>(value);
		return;
	}

	auto apple = Root;
	while (apple)
	{
		//If the value is less than apple
		//We go to the left or if the left is null we insert the value at the left
		//Same thing goes for the right side
		if (value < apple.value)
		{
			if (apple.Lchild == null)
			{
				apple.Lchild = std::make_shared(value);
				apple.Lchild.parent = apple;
				break;
			}
			apple = apple.Lchild;
		}
		else
		{
			if (apple.Rchild == null)
			{
				apple.Rchild = std::make_shared(value);
				apple.Rchild.parent = apple;
				break;
			}
			apple = apple.Rchild;
		}
	}
}

template <typename T>
bool BST<T>::Contains(T thing)
{
	auto apple = Root;
	while (apple.value != value && (apple.Rchild != null || apple.Lchild != null))
	{
		if (apple.value > value)
		{
			apple = apple.Lchild;
		}
		if (apple.value < value)
		{
			apple = apple.Rchild;
		}
	}

	if (apple.value = value)
	{
		return true;
	}
	else
	{
		return false;
	}
}

template <typename T>
void BST<T>::Clear()
{

}

template <typename T>
void BST<T>::Remove(T value)
{
    if (Root == null)
    {
        return;
    }

    auto apple = Root;
    for (int i = 0; i < count; i++)
    {
        if (apple.value.Equals(value))
        {
            if (apple.ChildCount == 0)
            {
                if (apple.value < apple.parent.value)
                {
                    apple.parent.Lchild = null;
                }

                if (apple.value > apple.parent.value)
                {
                    apple.parent.Rchild = null;
                }
                count--;
                return;
            }

            if (apple.Lchild != null && apple.Rchild == null)
            {
                if (apple.value < apple.parent.value)
                {
                    apple.parent.Lchild = apple.Lchild;
                    apple.Lchild.parent = apple.parent;
                }

                if (apple.value > apple.parent.value)
                {
                    apple.parent.Rchild = apple.Lchild;
                    apple.Rchild.parent = apple.parent;
                }
                count--;
                return;
            }

            if (apple.Lchild == null && apple.Rchild != null)
            {
                if (apple.value < apple.parent.value)
                {
                    apple.parent.Lchild = apple.Rchild;
                    apple.Rchild.parent = apple.parent;
                }

                if (apple.value > apple.parent.value)
                {
                    apple.parent.Rchild = apple.Rchild;
                    apple.Rchild.parent = apple.parent;
                }
                count--;
                return;
            }

            if (apple.ChildCount == 2)
            {
                auto apple2 = apple.Lchild;

                while (apple2.Rchild != null)
                {
                    apple2 = apple2.Rchild;
                }

                apple.value = apple2.value;
                if (apple2.IsLeftChild)
                {
                    apple2.parent.Lchild = null;
                }
                else
                {
                    apple2.parent.Rchild = null;
                }
                apple2 = null;
            }
            count--;
            return;
        }

        if (apple.value > value)
        {
            apple = apple.Lchild;
        }

        if (apple.value < value)
        {
            apple = apple.Rchild;
        }
        count--;
    }
}