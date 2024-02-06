#include "Queue.h"
#include <stdlib.h>
#include "Node.h"
//#include "List.h"

#include <stdexcept>


//�����������
Queue::Queue(){
	//List* list = new List();
	Node* head = new Node();//list->head;
}

//���������� ��������
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

//��������� ��������(�������� �� �������)
int Queue::pop(){
	if (head == NULL)
	{
		throw std::invalid_argument::invalid_argument("������� �����!");
	}
	Node* newHead = head->next;
	int desiredValue = head->value;
	free(head);
	head = newHead;
	return desiredValue;
}


//����������
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
