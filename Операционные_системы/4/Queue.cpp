#include "Queue.h"
#include <stdlib.h>
#include "Node.h"
//#include "List.h"

#include <stdexcept>


//конструктор
Queue::Queue(){
	//List* list = new List();
	Node* head = new Node();//list->head;
}

//добавление элемента
void Queue::push(int value) {
	if (head == NULL)
	{
		head = new Node(value);
		return;
	}
	Node *iterator = head;
	while (iterator->next != NULL)
	{
		iterator = iterator->next;
	}
	Node *tail = new Node(value);
	iterator->next = tail;
}

//получение элемента(удаление из очереди)
int Queue::pop(){
	if (head == NULL)
	{
		throw std::invalid_argument::invalid_argument("Очередь пуста!");
	}
	Node* newHead = head->next;
	int desiredValue = head->value;
	free(head);
	head = newHead;
	return desiredValue;
}


//деструктор
Queue::~Queue() {
	Node* first = head;
	Node* second = head;
	while (first != NULL)
	{
		second = first->next;
		delete first;
		first = second;
	}
}
