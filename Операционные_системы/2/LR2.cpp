#include <iostream>
#include <string>

using namespace std;

//В написанном выражении ((((1?2)?3)?4)?5)?6 вместо
//каждого знака « ? » вставить знак одной из четырех арифметических
//операций + , –, *, / так, чтобы результат вычислений равнялся 35. При
//делении дробная часть в частном отбрасывается.Достаточно найти
//одно решение.;;



void f(int number, int result, string resultString) {
    if (number > 6)
    {
        if (result == 35) 
            cout << resultString << "=35\n";
        return;
    }
    f(number + 1, result + number, "(" + resultString + "+" + to_string(number) + ")");
    f(number + 1, result - number, "(" + resultString + "-" + to_string(number) + ")");
    f(number + 1, result * number, "(" + resultString + "*" + to_string(number) + ")");
    f(number + 1, result / number, "(" + resultString + "/" + to_string(number) + ")");
}


int main()
{
    setlocale(LC_ALL, "Russian");
    cout << "Лабораторная работа №2. Зиновьева Полина, 5 вариант \n";
    cout << "Задание: В написанном выражении ((((1?2)?3)?4)?5)?6 вместо каждого знака « ? » вставить знак одной из четырех \nарифметических операций + , –, *, / так, чтобы результат вычислений равнялся 35. При делении дробная часть в частном \nотбрасывается.Достаточно найти одно решение. \n";
    f(2, 1, "1");
}




