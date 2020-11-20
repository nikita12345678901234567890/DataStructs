#pragma once
#include <iostream>
#include <memory>

template <typename T>
class BST
{
private:
	std::shared_ptr<Node<T>> Head;

public:

	BST()
	{
	
	}
	void Insert();
};