#pragma once
#include <iostream>
#include <memory>
#include <stack>
#include <vector>
#include "Node.h"
#define null nullptr

template <typename T>
class BST
{
private:
	std::shared_ptr<Node<T>> Root;
	int count;
    bool Contains(std::vector<std::shared_ptr<Node<T>>> thingy, std::shared_ptr<Node<T>> thing);

public:

	BST()
	{
	
	}
    ~BST();
	void Insert(T value);
	bool Contains(T thing);
	void Clear();
	void Remove(T value);
    std::vector<std::shared_ptr<Node<T>>> PreOrder();
    std::vector<std::shared_ptr<Node<T>>> InOrder();
    std::vector<std::shared_ptr<Node<T>>> PostOrder();
};


template <typename T>
BST<T>::~BST()
{
    Clear();
}

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
		if (value < apple->value)
		{
			if (apple->Lchild == null)
			{
				apple->Lchild = std::make_shared<Node<T>>(value);
				apple->Lchild->parent = apple;
				return;
			}
			apple = apple->Lchild;
		}
		else
		{
			if (apple->Rchild == null)
			{
				apple->Rchild = std::make_shared<Node<T>>(value);
				apple->Rchild->parent = apple;
				return;
			}
			apple = apple->Rchild;
		}
	}
}

template <typename T>
bool BST<T>::Contains(T thing)
{
    if (count == 0)
    {
        return false;
    }
	auto apple = Root;
    while (apple != null && apple->value != thing && (apple->Rchild != null || apple->Lchild != null))
	{
		if (apple->value > thing)
		{
			apple = apple->Lchild;
		}
		else if (apple->value < thing)
		{
			apple = apple->Rchild;
		}
	}

	if (apple != null && apple->value == thing)
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
    if (Root == null)
    {
        return;
    }

    auto node = Root;

    std::stack <std::shared_ptr<Node<T>>> stack{};
   
    std::shared_ptr<Node<T>> lastNodeVisited{};
    std::shared_ptr<Node<T>> peekNode{};

    while (stack.size() > 0 || node)
    {
        if (node)
        {
            stack.push(node);
            node = node->Lchild;
        }
        else
        {
            peekNode = stack.top();

            if (peekNode->Rchild && lastNodeVisited != peekNode->Rchild)
            {
                node = peekNode->Rchild;
            }
            else
            {
                peekNode.reset();
                lastNodeVisited = stack.top();
                stack.pop();
            }
        }
    }

    Root = null;
    count = 0;
}
// fix remove!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
template <typename T>
void BST<T>::Remove(T value)
{
    if (Root == null || Contains(value))
    {
        return;
    }

    auto apple = Root;
    for (int i = 0; i < count; i++)
    {
        if (apple->value == value)
        {
            if (apple->ChildCount() == 0)
            {
                if (apple->value < apple->parent.lock()->value)
                {
                    apple->parent.lock()->Lchild = null;
                }

                if (apple->value > apple->parent.lock()->value)
                {
                    apple->parent.lock()->Rchild = null;
                }
                count--;
                return;
            }

            if (apple->Lchild != null && apple->Rchild == null)
            {
                if (apple->value < apple->parent.lock()->value)
                {
                    apple->parent.lock()->Lchild = apple->Lchild;
                    apple->Lchild->parent.lock() = apple->parent.lock();
                }

                if (apple->value > apple->parent.lock()->value)
                {
                    apple->parent.lock()->Rchild = apple->Lchild;
                    apple->Rchild->parent.lock() = apple->parent.lock();
                }
                count--;
                return;
            }

            if (apple->Lchild == null && apple->Rchild != null)
            {
                if (apple->value < apple->parent.lock()->value)
                {
                    apple->parent.lock()->Lchild = apple->Rchild;
                    apple->Rchild->parent.lock() = apple->parent.lock();
                }

                if (apple->value > apple->parent.lock()->value)
                {
                    apple->parent.lock()->Rchild = apple->Rchild;
                    apple->Rchild->parent.lock() = apple->parent.lock();
                }
                count--;
                return;
            }

            if (apple->ChildCount() == 2)
            {
                auto apple2 = apple->Lchild;

                while (apple2->Rchild != null)
                {
                    apple2 = apple2->Rchild;
                }

                apple->value = apple2->value;
                if (apple2->IsLeftChild())
                {
                    apple2->parent.lock()->Lchild = null;
                }
                else
                {
                    apple2->parent.lock()->Rchild = null;
                }
                apple2 = null;
            }
            count--;
            return;
        }
        
        if (apple->value > value)
        {
            apple = apple->Lchild;
        }

        if (apple->value < value)
        {
            apple = apple->Rchild;
        }
    }
    count--;
}

template<typename T>
bool BST<T>::Contains(std::vector<std::shared_ptr<Node<T>>> thingy, std::shared_ptr<Node<T>> thing)
{
    for (size_t i = 0; i < thingy.size(); i++)
    {
        if (thingy[i] == thing)
        {
            return true;
        }
    }
    return false;
}

template <typename T>
std::vector<std::shared_ptr<Node<T>>> BST<T>::PreOrder()
{
    if (Root == null)
    {
        std::vector<std::shared_ptr<Node<T>>> empty{};
        return empty;
    }

    std::vector<std::shared_ptr<Node<T>>> values;
    if (count > 0)
    {
        std::stack<std::shared_ptr<Node<T>>> stack;
        stack.push(Root);

        std::shared_ptr<Node<T>> current;

        while (stack.size() > 0)
        {
            current = stack.top();
            stack.pop();
            values.push_back(current);
            if (current->Rchild)
            {
                stack.push(current->Rchild);
            }
            if (current->Lchild)
            {
                stack.push(current->Lchild);
            }
        }
    }

    return values;
}

template <typename T>
std::vector<std::shared_ptr<Node<T>>> BST<T>::InOrder()
{
    if (Root == null)
    {
        std::vector<std::shared_ptr<Node<T>>> empty{};
        return empty;
    }

    std::vector<std::shared_ptr<Node<T>>> values;
    auto Counter = Root;

    while (values.size() < count)
    {
        if (Counter != null && Counter->Lchild != null && !Contains(values, Counter->Lchild))
        {
            Counter = Counter->Lchild;
        }
        else if (!Contains(values, Counter))
        {
            values.push_back(Counter);
        }
        else if (Counter != null && Counter->Rchild != null && !Contains(values, Counter->Rchild))
        {
            Counter = Counter->Rchild;
        }
        else if(Counter != null)
        {
            Counter = Counter->parent.lock();
        }
    }

    return values;
}

template <typename T>
std::vector<std::shared_ptr<Node<T>>> BST<T>::PostOrder()
{
    if (Root == null)
    {
        std::vector<std::shared_ptr<Node<T>>> empty{};
        return empty;
    }

    std::vector<std::shared_ptr<Node<T>>> values;
    auto Counter = Root;

    while (values.size() < count)
    {
        if (Counter != null && Counter->Lchild != null && !Contains(values, Counter->Lchild))
        {
            Counter = Counter->Lchild;
        }
        else if (Counter != null && Counter->Rchild != null && !Contains(values, Counter->Rchild))
        {
            Counter = Counter->Rchild;
        }
        else if (Counter != null && !Contains(values, Counter))
        {
            values.push_back(Counter);
        }
        else
        {
            Counter = Counter->parent.lock();
        }
    }

    return values;
}