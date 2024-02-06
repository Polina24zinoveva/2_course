#include <iostream>
#include "Queue.h"
#include <string>
#include <conio.h>
#include "LR8.h"
using namespace std;

#define buf_size 256
#define name_of_file_in_memory L"file"

string print(Node* head)
{
	string str = "(";
	Node* iterator = head;
	while (iterator != NULL)
	{
		str += to_string(iterator->value) + ", ";
		iterator = iterator->next;
	}
	str = str.substr(0, str.length() - 2);
	str += ")";
	return str;
}

void popToString(Queue* queue)
{
	try
	{
		string str = "Полученный элемент: ";
		str += to_string(queue->pop()) + "\t";
		str += "Оставшаяся очередь:";
		str += print(queue->head) + "\n";
		cout << str;
	}
	catch (invalid_argument& e)
	{

		cout << e.what() << std::endl;
	}
}

HANDLE h_map_file = CreateFileMapping(INVALID_HANDLE_VALUE, NULL, PAGE_READWRITE,
	0, buf_size, name_of_file_in_memory);



int buffer;


void add(Queue* queue, int value)
{
	buffer = value; 
	queue->push(buffer);        //добавление значения из буфера

	cout << "Добавленный элемент: ";
	cout << buffer << "\t";
	cout << "Очередь:";
	cout << print(queue->head) << endl;
	//WaitForSingleObject(emptyBuffer, INFINITE);
}



int main()
{
	setlocale(LC_ALL, "Russian");

	cout << "Лабораторная работа №8. Зиновьева Полина, 5 вариант\n";


	Queue* queue = new Queue();
	queue->readfromfile();


	int* pBuf = (int*)MapViewOfFile(h_map_file, // handle to map object
		FILE_MAP_ALL_ACCESS,  // read/write permission
		0,
		0,
		buf_size);
	if (pBuf == NULL)
	{
		cout << "Could not map view of file (%d).\n";
		CloseHandle(h_map_file);
		return 1;
	}

	cout << "Добавление элементов в очередь:" << endl;

	add(queue, *pBuf);

	queue->writeinfile();
	CloseHandle(h_map_file);
	delete queue;


	_getch();
	return 0;
}



