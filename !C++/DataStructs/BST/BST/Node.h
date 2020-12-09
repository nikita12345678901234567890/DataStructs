#pragma once
#include <iostream>
#include <memory>

template <typename T>
class Node
{
public:
	T value;
	std::weak_ptr<Node<T>> parent;
	std::shared_ptr<Node<T>> Rchild;
	std::shared_ptr<Node<T>> Lchild;

	Node(T value) : value(value)
	{

	}

	Node(T value, std::shared_ptr<Node<T>> parent) : value(value), parent(parent)
	{

	}

	Node(T value, std::shared_ptr<Node<T>> parent, std::shared_ptr<Node<T>> Rchild) : value(value), parent(parent), Rchild(Rchild)
	{

	}

	Node(T value, std::shared_ptr<Node<T>> parent, std::shared_ptr<Node<T>> Rchild, std::shared_ptr<Node<T>> Lchild) : value(value), parent(parent), Rchild(Rchild), Lchild(Lchild)
	{

	}

    int ChildCount()
    {
        int count = 0;

        if (Lchild != nullptr)
            {
                count++;
            }

        if (Rchild != nullptr)
            {
                count++;
            }

        return count;
    }

    bool IsLeftChild()
    {
        if (parent.lock() != nullptr && parent.lock()->Lchild != nullptr && parent.lock()->Lchild.get() == this)
        {
            return true;
        }

        return false;
    }
};