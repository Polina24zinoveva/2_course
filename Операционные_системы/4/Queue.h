#pragma once
#include "Node.h"


class Queue
{
public:
   // List* list;
    Node* head;
    Queue();
    void push(int value);
    int pop();
    ~Queue();
};



