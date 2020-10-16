#pragma once
class Node
{
	public:
	int value;
	Node* next = nullptr;

	Node(int value) : value(value) {};
	Node(int value, Node* next) : value(value), next(next) {};

};