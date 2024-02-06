#include <iostream>
#include "Queue.h"
#include <string>
#include <conio.h>
using namespace std;

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

DWORD id;
HANDLE anotherThread;
HANDLE bufferWithValue;
HANDLE emptyBuffer;
int buffer;
bool b = false;

DWORD WINAPI pushThread(PVOID a) //PVOID Это указатель void - указатель на адрес памяти без информации о типе значения, на которое он указывает. По этой причине перед использованием указателя вы должны указать указатель на тип, например (char *)pMemPhy или (int *)pMemPhy, чтобы компилятор знал, сколько памяти он работает (1 байт для char, 4 байта для int, и т.д.)
{
	Queue* queue = (Queue*)a;
	while (true)
	{
		WaitForSingleObject(        //Ожидание занятого состояния буфера
			bufferWithValue, // идентификатор объекта
			INFINITE);       // время ожидания в милисекундах(INFINITE - функция будет ждать изменения состояния объекта неограниченно долго.)
		queue->push(buffer);        //добавление значения из буфера
		SetEvent(emptyBuffer);      //переход в состояние пустого буффера
	}
	return 0;
}



int main()
{
	setlocale(LC_ALL, "Russian");

	cout << "Лабораторная работа №7. Зиновьева Полина, 5 вариант\n";

	Queue* firstQueue = new Queue();
	
	emptyBuffer = CreateEvent(
		NULL,         // атрибут защиты			
		FALSE,        // тип сброса TRUE - ручной
		TRUE,         // начальное состояние TRUE - сигнальное
		NULL);        // имя обьекта
	bufferWithValue = CreateEvent(NULL, FALSE, FALSE, NULL);
	anotherThread = CreateThread(
		NULL,         // дескриптор защиты
		0,            // начальный размер стека
		&pushThread,  // функция потока
		firstQueue,      // параметр потока
		0,            // опции создания
		&id);         // идентификатор потока


	cout << "Добавление элементов в очередь:" << endl;

	buffer = 1;//помещение в буфер значения
	SetEvent(bufferWithValue);//переход в состояние заполненности	
	cout << "Добавленный элемент: ";
	cout << 1 << "\t";
	cout << "Очередь:";
	cout << print(firstQueue->head) << endl;

	WaitForSingleObject(emptyBuffer, INFINITE);

	buffer = 2;//помещение в буфер значения
	SetEvent(bufferWithValue);//переход в состояние заполненности	
	cout << "Добавленный элемент: ";
	cout << 2 << "\t";
	cout << "Очередь:";
	cout << print(firstQueue->head) << endl;

	WaitForSingleObject(emptyBuffer, INFINITE);

	buffer = 3;//помещение в буфер значения
	SetEvent(bufferWithValue);//переход в состояние заполненности	
	cout << "Добавленный элемент: ";
	cout << 3 << "\t";
	cout << "Очередь:";
	cout << print(firstQueue->head) << endl;



	cout << "Очередь, полученная чтением из файла: ";
	firstQueue->writeinfile();
	Queue* secondQueue = new Queue();
	secondQueue->readfromfile();
	cout << print(secondQueue->head) << endl << endl;


	cout << "Добавление элементов в очередь:" << endl;

	WaitForSingleObject(emptyBuffer, INFINITE);

	buffer = 4;//помещение в буфер значения
	SetEvent(bufferWithValue);//переход в состояние заполненности
	cout << "Добавленный элемент: ";
	cout << 4 << "\t";
	cout << "Очередь:";
	cout << print(firstQueue->head) << endl;

	WaitForSingleObject(emptyBuffer, INFINITE);

	buffer = 5;//помещение в буфер значения
	SetEvent(bufferWithValue);//переход в состояние заполненности
	cout << "Добавленный элемент: ";
	cout << 5 << "\t";
	cout << "Очередь:";
	cout << print(firstQueue->head) << endl;

	WaitForSingleObject(emptyBuffer, INFINITE);

	buffer = 6;//помещение в буфер значения
	SetEvent(bufferWithValue);//переход в состояние заполненности
	cout << "Добавленный элемент: ";
	cout << 6 << "\t";
	cout << "Очередь:";
	cout << print(firstQueue->head) << endl;

	cout << "Очередь, полученная чтением из файла: ";
	firstQueue->writeinfile();
	secondQueue = new Queue();
	secondQueue->readfromfile();
	cout << print(secondQueue->head) << endl << endl;


	cout << "Получение элементов из очереди:" << endl;
	popToString(firstQueue);
	popToString(firstQueue);
	popToString(firstQueue);


	cout  << "Очередь, полученная чтением из файла: ";
	firstQueue->writeinfile();
	secondQueue->readfromfile();
	cout << print(secondQueue->head);

	delete firstQueue;
	delete secondQueue;


	_getch();
	return 0;
}



