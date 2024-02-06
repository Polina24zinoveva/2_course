#include "Queue.h"
#include <stdlib.h>
#include "Node.h"
#include <stdexcept>
#include <Windows.h>
#include <iostream>

using namespace std;



//�����������
Queue::Queue() {
	head = new Node();
	head = NULL;
}



//���������� ��������
void Queue::add(int value)//���������� ��������
{
	if (head == NULL)
	{
		head = new Node(value);
		return;
	}
	Node* iterator = head;
	while (iterator->next != NULL)
	{
		iterator = iterator->next;
	}
	Node* tail = new Node(value);
	iterator->next = tail;
}

void Queue::push(int value)
{
	if (head == NULL)
	{
		head = new Node(value);
		return;
	}
	Node* iterator = head;
	while (iterator->next != NULL)
	{
		iterator = iterator->next;
	}
	Node* tail = new Node(value);
	iterator->next = tail;
}

//��������� ��������(�������� �� �������)
int Queue::pop() {
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


void Queue::writeinfile()
{
	HANDLE fileforwrite = CreateFile(
		L"Queue.txt",                 // ��� �����
		GENERIC_WRITE,                // ����� �������(	��������� ����������� �������� �������� �������, ������� ������� ������� ���  ������.)
		0,                            // ���������� ������
		NULL,                         // SD (�����. ������)
		CREATE_ALWAYS,                // ��� �����������(������� ����� ����. ���� ���� ����������, ������� ������������ ����, ���������� ������������ �������� � ����������, �������� ���������� dwFlagsAndAttributes �������� ����� � ������, � FILE_ATTRIBUTE_ARCHIVE, �� �� ������������� ���������� ������������ �������� ���������� SECURITY_ATTRIBUTES.)
		FILE_ATTRIBUTE_NORMAL,        // �������� �����(� ����� ��� ������ ������������� ���������. ���� ������� �������� ������ � ��� ������, ���� �� ������������ ����.)
		NULL                          // �����.������� �����
	);
	if (fileforwrite == INVALID_HANDLE_VALUE) //���� ������� ����������� � �������, ������������ �������� - INVALID_HANDLE_VALUE.
	{
		cout << "������!";
	}
	Node* iterator = head;
	DWORD numofbites;
	while (iterator != NULL)
	{
		int value = iterator->value;

		WriteFile(
			fileforwrite,             // ���������� �����
			&value,                   // ����� ������(��������� �� �����, ���������� ������, ������� ����� �������� � ����.)
			sizeof(value),            // ����� ������ ��� ������(����� ������, ������� ����� �������� � ����.)
			&numofbites,              // ����� ���������� ������(��������� �� ����������, ������� �������� ����� ���������� ������)
			NULL                      // ����������� �����
		);

		iterator = iterator->next;
	}
	CloseHandle(fileforwrite);
}
void Queue::readfromfile()
{
	HANDLE fileforread = CreateFile(
		L"Queue.txt",                 // ��� �����
		GENERIC_READ,                 // ����� �������(	��������� ����������� �������� �������� �������, ������� ������� ������� ���  ������.)
		0,                            // ���������� ������
		NULL,                         // SD (�����. ������)
		OPEN_EXISTING,                // ��� �����������(��������� ����. ������� ����������� �������, ���� ���� �� ����������.)
		FILE_ATTRIBUTE_NORMAL,        // �������� �����(� ����� ��� ������ ������������� ���������. ���� ������� �������� ������ � ��� ������, ���� �� ������������ ����.)
		NULL                          // �����.������� �����
	);

	if (INVALID_HANDLE_VALUE == fileforread) //���� ������� ����������� � �������, ������������ �������� - INVALID_HANDLE_VALUE.
	{
		cout << "mistake!";
	}
	DWORD numofbites;
	head = NULL;

	while (true)
	{
		int value;

		ReadFile(
			fileforread,              // ���������� �����
			&value,                   // ����� ������
			sizeof(value),            // ����� ������ ��� ������
			&numofbites,              // ����� ����������� ������
			NULL                      // ����������� �����
		);

		if (numofbites == 0)
			break;
		push(value);
	}
	CloseHandle(fileforread);
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
