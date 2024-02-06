#include "Node.h"
#include <cstddef>


Node::Node()
{
	int value = 0;
	Node* next = NULL;
}

Node::Node(int valuee)
{
	value = valuee;
	next = NULL;
}



Node::~Node()
{
}


