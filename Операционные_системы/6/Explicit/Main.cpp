#include <iostream>
#include <Windows.h>
#include "..\..\Dll2\Dll2\Queue.h"
#include <string>
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

int ExplicitLinkTest()
{
	HINSTANCE dll = LoadLibrary(L"Dll2.dll");
	if (dll == NULL)
	{
		cout << "Error";
		return 1;
	}

	cout << "DLL подключена!" << endl;

	void(Queue:: * qConstructor)();
	(FARPROC&)qConstructor = GetProcAddress(dll, "??0Queue@@QEAA@XZ");

	void(Queue:: * qPush)(int);
	(FARPROC&)qPush = GetProcAddress(dll, "?push@Queue@@QEAAXH@Z");

	int(Queue:: * qPop)();
	(FARPROC&)qPop = GetProcAddress(dll, "?pop@Queue@@QEAAHXZ");

	int(Queue:: * qWriteInFile)();
	(FARPROC&)qWriteInFile = GetProcAddress(dll, "?writeinfile@Queue@@QEAAXXZ");

	int(Queue:: * qReadFromFile)();
	(FARPROC&)qReadFromFile = GetProcAddress(dll, "?readfromfile@Queue@@QEAAXXZ");

	void(Queue:: * qDestructor)();
	(FARPROC&)qDestructor = GetProcAddress(dll, "??1Queue@@QEAA@XZ");


	Queue* firstQueue = (Queue*)HeapAlloc(GetProcessHeap(), NULL, sizeof(Queue));
	(firstQueue->*qConstructor)();
	cout << "Добавление элементов в очередь:" << endl;


	(firstQueue->*qPush)(1);
	cout << "Добавленный элемент: " << 1 << "\t" << "Очередь:" << print(firstQueue->head) << endl;

	(firstQueue->*qPush)(2);
	cout << "Добавленный элемент: " << 2 << "\t" << "Очередь:" << print(firstQueue->head) << endl;

	(firstQueue->*qPush)(3);
	cout << "Добавленный элемент: " << 3 << "\t" << "Очередь:" << print(firstQueue->head) << endl;

	(firstQueue->*qPush)(4);
	cout << "Добавленный элемент: " << 4 << "\t" << "Очередь:" << print(firstQueue->head) << endl;

	(firstQueue->*qPush)(5);
	cout << "Добавленный элемент: " << 5 << "\t" << "Очередь:" << print(firstQueue->head) << endl;

	(firstQueue->*qWriteInFile)();



	cout << "Очередь, полученная чтением из файла: ";

	Queue* secondQueue = (Queue*)HeapAlloc(GetProcessHeap(), NULL, sizeof(Queue));
	(secondQueue->*qConstructor)();
	(secondQueue->*qReadFromFile)();
	cout << print(secondQueue->head) << endl << endl;


	cout << "Получение элементов из очереди:" << endl;

	cout << "Полученный элемент: " << to_string((firstQueue->*qPop)()) + "\t";
	cout << "Оставшаяся очередь:" << print(firstQueue->head) + "\n";

	cout << "Полученный элемент: " << to_string((firstQueue->*qPop)()) + "\t";
	cout << "Оставшаяся очередь:" << print(firstQueue->head);

	cout << endl << "Очередь, полученная чтением из файла: ";
	(firstQueue->*qWriteInFile)();
	(secondQueue->*qReadFromFile)();
	cout << print(secondQueue->head);


	(firstQueue->*qDestructor)();
	(secondQueue->*qDestructor)();

	/*HeapFree(firstQueue);
	HeapFree(secondQueue);*/


	FreeLibrary(dll);
}

int ImplicitLinkTest()
{
	Queue* firstQueue = new Queue();

	cout << "Добавление элементов в очередь:" << endl;

	firstQueue->push(1);
	cout << "Добавленный элемент: " << 1 << "\t" << "Очередь:" << print(firstQueue->head) << endl;

	firstQueue->push(2);
	cout << "Добавленный элемент: " << 2 << "\t" << "Очередь:" << print(firstQueue->head) << endl;

	firstQueue->push(3);
	cout << "Добавленный элемент: " << 3 << "\t" << "Очередь:" << print(firstQueue->head) << endl;

	firstQueue->push(4);
	cout << "Добавленный элемент: " << 4 << "\t" << "Очередь:" << print(firstQueue->head) << endl;

	firstQueue->push(5);
	cout << "Добавленный элемент: " << 5 << "\t" << "Очередь:" << print(firstQueue->head) << endl;


	cout << "Очередь, полученная чтением из файла: ";
	firstQueue->writeinfile();
	Queue* secondQueue = new Queue();
	secondQueue->readfromfile();
	cout << print(secondQueue->head) << endl << endl;


	cout << "Получение элементов из очереди:" << endl;
	cout << "Полученный элемент: " << to_string(firstQueue->pop()) + "\t";
	cout << "Оставшаяся очередь:" << print(firstQueue->head) + "\n";
	cout << "Полученный элемент: " << to_string(firstQueue->pop()) + "\t";
	cout << "Оставшаяся очередь:" << print(firstQueue->head) + "\n";

	cout << endl << "Очередь, полученная чтением из файла: ";
	firstQueue->writeinfile();
	secondQueue->readfromfile();
	cout << print(secondQueue->head) << endl;

	delete firstQueue;
	delete secondQueue;

	return 0;
}



int main()
{
	setlocale(LC_ALL, "Russian");

	cout << "Лабораторная работа №6. Зиновьева Полина, 5 вариант\n" << endl;

	cout << "Тестирующий код выполняет подключение библиотеки с использованием явного связывания:\n";
	ExplicitLinkTest();
	cout << endl << endl << endl << "Тестирующий код выполняет подключение библиотеки с использованием неявного связывания:\n" << endl;
	ImplicitLinkTest();

	system("PAUSE");
	return 0;
}