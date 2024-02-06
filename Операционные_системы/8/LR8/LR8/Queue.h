#pragma once
#include "Node.h"
#include <Windows.h>
#include <wincrypt.h>


class Queue
{
public:
    Node* head;
    Queue();
    void push(int value);
    int len();
    void add(int value);
    int pop();
    void writeinfile();
    void readfromfile();
    ~Queue();
};


