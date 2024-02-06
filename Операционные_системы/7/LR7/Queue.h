#pragma once
#include "Node.h"
#include <Windows.h>

class Queue
{
public:
    Node* head;
    Queue();
    void push(int value);
    void add(int value);
    int pop();
    void writeinfile();
    void readfromfile();
    ~Queue();
};
