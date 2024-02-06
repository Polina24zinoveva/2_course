
#include <iostream>
#include <conio.h>
#include <Windows.h>

using namespace std;

//Динамический массив размерности MxN необходимо
//дополнить(M + 1) - й строкой и(N + 1) - м столбцом, в которых записать
//суммы элементов соответствующих строк и столбцов.В элементе
//M + 1, N + 1 должна храниться сумма всех элементов массива.


int main()
{
	setlocale(LC_ALL, "Russian");

	cout << "Лабораторная работа №3, Зиновьева Полина, 5 вариант";
	cout << "Динамический массив размерности MxN необходимо дополнить \n(N + 1) - й строкой и(M + 1) - м столбцом, в которых записать суммы элементов соответствующих строк и столбцов.\nВ элементе M + 1, N + 1 должна храниться сумма всех элементов массива.\n\n";
	cout << "Введите число N - количество строк матрицы: ";
	int n;
	cin >> n;
	cout << "Введите число M - количество столбцов  матрицы: ";
	int m;
	cin >> m;
	
	HANDLE heap = GetProcessHeap();
	if (heap != NULL)
	{
		float** massiv = (float**)HeapAlloc(heap, NULL, sizeof(float*) * (n + 1));
		cout << "Введите элементы массива: " << "\n";
		for (int i = 0; i < (n + 1); i++)
		{
			massiv[i] = (float*)HeapAlloc(heap, NULL, sizeof(float) * (m + 1));
			for (int j = 0; j < m + 1; j++)
			{
				if ((j == m) || (i == n))
				{
					massiv[i][j] = 0;
				}
				else
				{
					cin >> massiv[i][j];
				}
			}
		}
		cout << "Введенный массив: " << "\n";
		for (int i = 0; i < n; i++)
		{
			for (int j = 0; j < m; j++)
				cout << massiv[i][j] << " ";
			cout << "\n";
		}
		cout << "\n";

		for (int i = 0; i < n + 1; i++)
		{
			float sumThisStroka = 0;
			for (int j = 0; j < m + 1; j++)
			{
				sumThisStroka += massiv[i][j];
				if (j == m)
				{
					massiv[i][j] = sumThisStroka;
				}
			}
		}

		cout << "Полученный массив: " << "\n";

		for (int j = 0; j < m + 1; j++)
		{
			float sumThisStolbec = 0;
			for (int i = 0; i < n + 1; i++)
			{
				sumThisStolbec += massiv[i][j];
				if (i == n)
				{
					massiv[i][j] = sumThisStolbec;
				}
			}
		}

		float sum = 0;
		for (int i = 0; i < n; i++)
		{
			for (int j = 0; j < m; j++)
			{
				sum += massiv[i][j];
			}
		}
		massiv[n][m] = sum;

		for (int i = 0; i < n + 1; i++)
		{
			for (int j = 0; j < m + 1; j++)
				cout << massiv[i][j] << " ";
			cout << "\n";
		}

		for (int i = 0; i < n+1; i++)
		{
			HeapFree(heap, NULL, massiv[i]);
		}
		HeapFree(heap, NULL, massiv);
	}

	return 0;
}
