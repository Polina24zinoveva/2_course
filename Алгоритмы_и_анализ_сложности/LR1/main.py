import random
import time

def bubbleSort(mas):
    for j in range(1, len(mas) - 1):
        for i in range(0, len(mas) - 1):
            if mas[i] > mas[i+1]:
                v = mas[i]
                mas[i] = mas[i+1]
                mas[i+1] = v
    return mas

def quickSort(mas):
    if len(mas) <= 1:
        return mas
    else:
        index_of_support_element = random.randint(0, len(mas) - 1)
        min_mas = []
        equal_mas = []
        max_mas = []
        for i in range(0, len(mas)):
            if (mas[i] < mas[index_of_support_element]):
                min_mas.append(mas[i])
            elif (mas[i] == mas[index_of_support_element]):
                equal_mas.append(mas[i])
            elif (mas[i] > mas[index_of_support_element]):
                max_mas.append((mas[i]))
        return quickSort(min_mas) + equal_mas + quickSort(max_mas)


def function(count):
    # count = random.randint(1000, 10000)
    # print("Количество элементов в массиве")
    print(count)
    mas1 = []
    for i in range(0, count):
        mas1.append(random.randint(-1000, 1000))

    mas2 = mas1.copy()

    start_time = time.time()
    bubbleSort(mas1)
    print("Время выполнения сортировки пузырьком: ")
    print(time.time() - start_time)


    start_2_time = time.time()
    mas2 = quickSort(mas2)
    print("Время выполнения быстрой сортировки: ")
    print(time.time() - start_2_time)


def quickSort2(mas, l, h):
        if (mas.length == 0 or l >= h):
            return

        rand = random.randint(0, len(mas) - 1)
        pivot = mas[(l) + (int) (rand * (h - l + 1))]

        i = l
        j = h
        while (i <= j):
            while (mas[i] < pivot):
                i += 1
            while (mas[j] > pivot):
                j -= 1
            if (i <= j):
                swap = mas[i];
                mas[i] = mas[j];
                mas[j] = swap;
                i += 1
                j -=1



        if (l < j):
            quickSort(mas, l, j);
        if (h > i):
            quickSort(mas, i, h);



def functionProverka():
    count = random.randint(10, 20)
    print(count)
    mas1 = []
    for i in range(0, count):
        mas1.append(random.randint(-1000, 1000))

    mas2 = mas1.copy()

    print("Массив до сортировки пузырьком: ")
    print(mas1)
    start_time = time.time()
    bubbleSort(mas1)
    print("Время выполнения сортировки пузырьком: ")
    print(time.time() - start_time)
    print("Массив после сортировки пузырьком: ")
    print(mas1)

    print("\n")

    print("Массив до быстрой сортировки: ")
    print(mas2)
    start_2_time = time.time()
    #mas2 = quickSort(mas2)
    mas2 = quickSort2(mas2, 0, len(mas2))
    print(mas2)
    print("Время выполнения быстрой сортировки: ")
    print(time.time() - start_2_time)
    print("Массив после быстрой сортировки: ")
    print(mas2)

print("Лабораторная работа № 1, вариант 5. Выполнила: Зиновьева Полина, 6203-020302D")
#function(1000)
#print("\n")
function(5000)
print("\n")
# function(8000)
# print("\n")
# function(9000)
# print("\n")
# function(10000)

