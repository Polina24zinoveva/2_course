#include <iostream>
#include <string>
#include <conio.h>
using namespace std;

#include "../../LR8/LR8/Queue.h"
#define PROC_NAME L"..\\..\\LR8\\x64\\Debug\\LR8.exe"

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

int* put_buf = (int*)MapViewOfFile(h_map_file, FILE_MAP_ALL_ACCESS, 0, 0, buf_size);

int buffer;


void add(int value)
{
	buffer = value; 
	CopyMemory((PVOID*)(put_buf), &buffer, sizeof(int));

	cout << endl << "Добавленный элемент: " ;
	cout << buffer << "\t";

}


int main()
{
	setlocale(LC_ALL, "Russian");

	cout << "Лабораторная работа №8. Зиновьева Полина, 5 вариант\n";


	STARTUPINFO start_inform;      //Структура STARTUPINFO используется, чтобы определить оконный терминал, рабочий стол, стандартный дескриптор и внешний вид основного окна для нового процесса.
	PROCESS_INFORMATION proc_inf;  //Структура PROCESS_INFORMATION заполняется функцией CreateProcess с информацией о недавно созданном процессе и его первичном потоке.
	ZeroMemory(                    //Функция ZeroMemory заполняет блок памяти нулями.
		&start_inform,                // указатель на блок памяти
		sizeof(STARTUPINFO));         // размер блока памяти
	start_inform.cb = sizeof(STARTUPINFO);
	Queue* queue = new Queue();
	
	
	queue->writeinfile();
	add(24);
	if (!CreateProcess(PROC_NAME, NULL, NULL, NULL, FALSE, CREATE_NEW_CONSOLE, NULL, NULL,&start_inform, &proc_inf))
	{
		cout << "Cannot create the process" << GetLastError();
		return 1;
	}
	else
	{
		Sleep(1000);

		queue->readfromfile();
		add(0);
		Sleep(1000);
		CreateProcess(PROC_NAME, NULL, NULL, NULL, FALSE, CREATE_NEW_CONSOLE, NULL, NULL,
			&start_inform, &proc_inf);

		Sleep(1000);

		queue->readfromfile();
		add(5);
		Sleep(1000);
		CreateProcess(PROC_NAME, NULL, NULL, NULL, FALSE, CREATE_NEW_CONSOLE, NULL, NULL,
			&start_inform, &proc_inf);

		Sleep(1000);

		cout << endl << "Please wait" << endl;
		CloseHandle(proc_inf.hThread);
		CloseHandle(proc_inf.hProcess);

		queue->readfromfile();


		cout << print(queue->head) << endl;
		delete queue;
	}
	_getch();
	return 0;

	

}


