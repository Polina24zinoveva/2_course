#include <iostream>
#include <string>

using namespace std;

//В написанном выражении ((((1?2)?3)?4)?5)?6 вместо
//каждого знака « ? » вставить знак одной из четырех арифметических
//операций + , –, *, / так, чтобы результат вычислений равнялся 35. При
//делении дробная часть в частном отбрасывается.Достаточно найти
//одно решение.


int main()
{
    setlocale(LC_ALL, "Russian");
    cout << "Лабораторная работа №1. Зиновьева Полина, 5 вариант \n";
    cout << "Задание: В написанном выражении ((((1?2)?3)?4)?5)?6 вместо каждого знака « ? » вставить знак одной из четырех \nарифметических операций + , –, *, / так, чтобы результат вычислений равнялся 35. При делении дробная часть в частном \nотбрасывается.Достаточно найти одно решение. \n";

    int resultStringArray[] = {0 , 0 , 0 , 0 , 0};
    
    while (resultStringArray[0] <= 4)
    {
        int result = 1;
        for (int i = 0; i < 5; i++)
        {
            switch (resultStringArray[i])
            {
            case 0: result += i + 2; break;
            case 1: result -= i + 2; break;
            case 2: result *= i + 2; break;
            case 3: result /= i + 2; break;

            default:
                break;
            }
        }

        if (result == 35)
        {
            string resultString = "((((1";
            for (int j = 0; j < 5; j++)
            {
                switch (resultStringArray[j])
                {
                case 0: resultString += "+"; break;
                case 1: resultString += "-"; break;
                case 2: resultString += "*"; break;
                case 3: resultString += "/"; break;

                default:
                    break;
                }

                resultString += to_string(j + 2);
                resultString += ")";

            }
            resultString.erase(resultString.length() - 1, 1);
            resultString += "=35 \n";
            cout << resultString;

        }

        resultStringArray[4]++;

        for (int i = 4; i > 0 && resultStringArray[i] == 4; i--) {
            resultStringArray[i] = 0;
            resultStringArray[i - 1]++;
        }
    }
}

