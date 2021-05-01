#pragma once
#include <memory>

template <typename T>
class Node
{
	private:

	public:
	T value;
	std::shared_ptr<Node<T>> next;
	std::weak_ptr<Node<T>> prev;

	Node(T value, std::shared_ptr<Node<T>> next, std::shared_ptr<Node<T>> prev) : value(value), next(next), prev(prev)
	{

	}

	Node(T value) : value(value)
	{

	}
};