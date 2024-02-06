#pragma once

#include "Node.h"
#include <iterator>



class __declspec(dllimport) Queue
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
