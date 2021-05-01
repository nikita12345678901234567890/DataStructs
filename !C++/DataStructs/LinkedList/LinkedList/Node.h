#pragma once

template <typename T>
class Node
{
	public:
	T value;
	Node<T>* next = nullptr;

	Node() = default;
	Node(T value) : value(value) {};
	Node(T value, Node<T>* next) : value(value), next(next) {};

};