#pragma once
#include <memory>

template <typename T>
class Node
{
	private:

	public:
	T value;
	std::unique_ptr<Node> next;
	std::unique_ptr<Node> prev;

	Node() : value(value), next(next), prev(prev)
	{
	
	}

	Node() : value(value)
	{

	}
};