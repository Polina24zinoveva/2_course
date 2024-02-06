//Реализовать очередь на основе связного списка.

//Очередь - структура данных с дисциплиной доступа к элементам
//«первый пришёл - первый вышел».Добавление элемента возможно
//лишь в конец очереди, выборка - только из начала очереди, при этом
//выбранный элемент из очереди удаляется.

//Связный список - структура данных, состоящая из узлов, каждый из
//которых содержит как собственные данные, так и одну или две ссылки
//на следующий и / или предыдущий узел списка.


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
		str += to_string(iterator->value)  + ", ";
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

    cout << "Лабораторная работа №4. Зиновьева Полина, 5 вариант\n";
    cout << "Задание: Реализовать очередь на основе связного списка.\n\n";

	Queue* queue = new Queue();

	cout << "Добавление элементов в очередь:" << endl;

	queue->push(1);
	cout << "Добавленный элемент: ";
	cout << 1 << "\t";
	cout << "Очередь:";
	cout << print(queue->head) << endl;

	queue->push(2);
	cout << "Добавленный элемент: ";
	cout << 2 << "\t";
	cout << "Очередь:";
	cout << print(queue->head) << endl;

	queue->push(3);
	cout << "Добавленный элемент: ";
	cout << 3 << "\t";
	cout << "Очередь:";
	cout << print(queue->head) << endl;

	queue->push(4);
	cout << "Добавленный элемент: ";
	cout << 4 << "\t";
	cout << "Очередь:";
	cout << print(queue->head) << endl;

	queue->push(5);
	cout << "Добавленный элемент: ";
	cout << 5 << "\t";
	cout << "Очередь:";
	cout << print(queue->head) << endl << endl;

	cout << "Получение элементов из очереди:" << endl;
	popToString(queue);
	popToString(queue);
	popToString(queue);
	popToString(queue);
	popToString(queue);
	popToString(queue);
	
	delete queue;

	_getch();
	return 0;
}



