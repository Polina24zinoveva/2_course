#include "Queue.h"
#include <stdlib.h>
#include "Node.h"
#include <stdexcept>
#include <Windows.h>
#include <iostream>

using namespace std;



//конструктор
Queue::Queue() {
	head = new Node();
	head = NULL;
}



//добавление элемента
void Queue::add(int value)//добавление элемента
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

//получение элемента(удаление из очереди)
int Queue::pop() {
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


void Queue::writeinfile()
{
	HANDLE fileforwrite = CreateFile(
		L"Queue.txt",                 // имя файла
		GENERIC_WRITE,                // режим доступа(	Разрешает последующие операции открытия объекта, которые требуют доступа для  записи.)
		0,                            // совместный доступ
		NULL,                         // SD (дескр. защиты)
		CREATE_ALWAYS,                // как действовать(Создает новый файл. Если файл существует, функция переписывает файл, сбрасывает существующие атрибуты и объединяет, заданные параметром dwFlagsAndAttributes атрибуты файла и флажки, с FILE_ATTRIBUTE_ARCHIVE, но не устанавливает дескриптор безопасности заданный структурой SECURITY_ATTRIBUTES.)
		FILE_ATTRIBUTE_NORMAL,        // атрибуты файла(У файла нет других установленных атрибутов. Этот атрибут допустим только в том случае, если он используется один.)
		NULL                          // дескр.шаблона файла
	);
	if (fileforwrite == INVALID_HANDLE_VALUE) //Если функция завершается с ошибкой, возвращаемое значение - INVALID_HANDLE_VALUE.
	{
		cout << "Ошибка!";
	}
	Node* iterator = head;
	DWORD numofbites;
	while (iterator != NULL)
	{
		int value = iterator->value;

		WriteFile(
			fileforwrite,             // дескриптор файла
			&value,                   // буфер данных(Указатель на буфер, содержащий данные, которые будут записаны в файл.)
			sizeof(value),            // число байтов для записи(Число байтов, которые будут записаны в файл.)
			&numofbites,              // число записанных байтов(Указатель на переменную, которая получает число записанных байтов)
			NULL                      // асинхронный буфер
		);

		iterator = iterator->next;
	}
	CloseHandle(fileforwrite);
}
void Queue::readfromfile()
{
	HANDLE fileforread = CreateFile(
		L"Queue.txt",                 // имя файла
		GENERIC_READ,                 // режим доступа(	Разрешает последующие операции открытия объекта, которые требуют доступа для  записи.)
		0,                            // совместный доступ
		NULL,                         // SD (дескр. защиты)
		OPEN_EXISTING,                // как действовать(Открывает файл. Функция завершается ошибкой, если файл не существует.)
		FILE_ATTRIBUTE_NORMAL,        // атрибуты файла(У файла нет других установленных атрибутов. Этот атрибут допустим только в том случае, если он используется один.)
		NULL                          // дескр.шаблона файла
	);

	if (INVALID_HANDLE_VALUE == fileforread) //Если функция завершается с ошибкой, возвращаемое значение - INVALID_HANDLE_VALUE.
	{
		cout << "mistake!";
	}
	DWORD numofbites;
	head = NULL;

	while (true)
	{
		int value;

		ReadFile(
			fileforread,              // дескриптор файла
			&value,                   // буфер данных
			sizeof(value),            // число байтов для чтения
			&numofbites,              // число прочитанных байтов
			NULL                      // асинхронный буфер
		);

		if (numofbites == 0)
			break;
		push(value);
	}
	CloseHandle(fileforread);
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
