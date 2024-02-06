//изучение функций ввода/вывода
//в программном интерфейсе Win32.Интерфейс модуля для работы с
//заданной структурой данных из задания №4 расширяется функциями
//для сохранения структуры данных на диске целиком и восстановления
//структуры данных из сохраненного файла.


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

int main()
{
	setlocale(LC_ALL, "Russian");

	cout << "Лабораторная работа №5. Зиновьева Полина, 5 вариант\n";

	Queue* firstQueue = new Queue();

	cout << "Добавление элементов в очередь:" << endl;

	firstQueue->push(1);
	cout << "Добавленный элемент: ";
	cout << 1 << "\t";
	cout << "Очередь:";
	cout << print(firstQueue->head) << endl;

	firstQueue->push(2);
	cout << "Добавленный элемент: ";
	cout << 2 << "\t";
	cout << "Очередь:";
	cout << print(firstQueue->head) << endl;

	firstQueue->push(3);
	cout << "Добавленный элемент: ";
	cout << 3 << "\t";
	cout << "Очередь:";
	cout << print(firstQueue->head) << endl;

	firstQueue->push(4);
	cout << "Добавленный элемент: ";
	cout << 4 << "\t";
	cout << "Очередь:";
	cout << print(firstQueue->head) << endl;

	firstQueue->push(5);
	cout << "Добавленный элемент: ";
	cout << 5 << "\t";
	cout << "Очередь:";
	cout << print(firstQueue->head) << endl << endl;

	


	cout << "Очередь, полученная чтением из файла: ";
	firstQueue->writeinfile();
	Queue* secondQueue = new Queue();
	secondQueue->readfromfile();
	cout << print(secondQueue->head) << endl << endl;


	cout << "Получение элементов из очереди:" << endl;
	popToString(firstQueue);
	popToString(firstQueue);

	cout << endl << "Очередь, полученная чтением из файла: ";
	firstQueue->writeinfile();
	secondQueue->readfromfile();
	cout << print(secondQueue->head);
	
	delete firstQueue;
	delete secondQueue; 

	_getch();
	return 0;
}