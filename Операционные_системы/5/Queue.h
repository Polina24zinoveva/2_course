#pragma once
#include "Node.h"

class Queue
{
public:
    Node* head;
    Queue();
    void push(int value);
    int pop();
    void writeinfile();
    void readfromfile();
    ~Queue();
};
