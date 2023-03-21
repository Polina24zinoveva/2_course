def WithRepetitions(price, volumes, capacity):
    a = [0] * (capacity + 1)
    for i in range(1, capacity + 1):
        for j in range(0, len(volumes)):
            if (volumes[j] <= i):
                a[i] = max(a[i], price[j] + a[i - volumes[j]])
    return a[capacity]


def WithoutRepetitions(price, volumes, capacity):
    a = [[0 for x in range(capacity + 1)] for x in range(len(price) + 1)]
    for i in range(1, len(price) + 1):
        for w in range(1, capacity + 1):
            if volumes[i - 1] <= w:
                a[i][w] = max(price[i - 1] + a[i - 1][w - volumes[i - 1]], a[i - 1][w])
            else:
                a[i][w] = a[i - 1][w]
    print(a)
    return a[len(price)][capacity]




price = [2, 2, 4, 7, 5, 10, 10]
volumes = [2, 3, 1, 9, 4, 1, 6]
print("Доступные предметы")
print("Стоимость" + "\t" + "Объем")
for i in range(0, len(price)):
    print("\t", price[i], "\t", "\t", volumes[i])
print("Вместимость рюкзака равна:", end = ' ')
print("")
print("Стоимость вещей при заполнении с повторениями: ")
print(WithRepetitions(price, volumes, 14))
print("Стоимость вещей при заполнении без повторений: ")
print(WithoutRepetitions(price, volumes, 14))