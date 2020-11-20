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

	Node(T value, std::shared_ptr<Node<T>> parent, std::shared_ptr<Node<T>> Lchild) : value(value), parent(parent), Lchild(Lchild)
	{

	}

	Node(T value, std::shared_ptr<Node<T>> parent, std::shared_ptr<Node<T>> Rchild, std::shared_ptr<Node<T>> Lchild) : value(value), parent(parent), Rchild(Rchild), Lchild(Lchild)
	{

	}
};
