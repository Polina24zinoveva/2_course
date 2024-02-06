#pragma once

class Node
{
public:
    int value;
    Node *next;

    Node();
    Node(int value);
    ~Node();
};

