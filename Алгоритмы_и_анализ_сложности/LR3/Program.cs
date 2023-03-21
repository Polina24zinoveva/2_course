using System;
using System.Text;

namespace OP_Ladoratornaya2
{
    public class LinkedListVectorWithLoop
    {
        public class Node
        {
            public int value = 0;
            public Node next = null;

            public Node(int value)
            {
                this.value = value;
            }
        }

        private Node head = null;
        public Node Loop()
        {
            Node last = GoToNthElement(Length - 1);
            Random random = new Random();
            int random_ = random.Next(0, Length - 1);
            last.next = GoToNthElement(random_);
            return last;
        }

        public int Length
        {
            get
            {
                Node iterator = head;
                int count = 0;
                while (iterator != null)
                {
                    iterator = iterator.next;
                    count++;
                }
                return count;
            }
        }

        private Node GoToNthElement(int index)
        {
            if (index < 0)
            {
                throw new IndexOutOfRangeException("Error while executing program:\n" + "Индекс не может быть меньше 0. Запрошенный индекс: " + index);
            }

            else if (head == null)
            {
                throw new IndexOutOfRangeException("Error while executing program:\n" + "Неверный индекс: " + index);
            }

            Node iterator = head;
            int count = 0;
            while (iterator != null && count != index)
            {
                iterator = iterator.next;
                count++;
            }

            if (iterator == null || count != index)
            {
                throw new IndexOutOfRangeException("Error while executing program:\n" + "Неверный индекс: " + index + ". Размер вектора: " + count);
            }
            return iterator;
        }



        public void AddToTail(int value)
        {
            if (head == null)
            {
                head = new Node(value);
                return;
            }

            Node iterator = head;
            while (iterator.next != null)
            {
                iterator = iterator.next;
            }
            Node tail = new Node(value);
            iterator.next = tail;
        }

    }




    public class LinkedListVector
    {
        public class Node
        {
            public int value = 0;
            public Node next = null;

            public Node(int value)
            {
                this.value = value;
            }
        }


        private Node head = null;


        public int Length
        {
            get
            {
                Node iterator = head;
                int count = 0;
                while (iterator != null)
                {
                    iterator = iterator.next;
                    count++;
                }
                return count;
            }
        }

        private Node GoToNthElement(int index)
        {
            if (index < 0)
            {
                throw new IndexOutOfRangeException("Error while executing program:\n" + "Индекс не может быть меньше 0. Запрошенный индекс: " + index);
            }

            else if (head == null)
            {
                throw new IndexOutOfRangeException("Error while executing program:\n" + "Неверный индекс: " + index);
            }

            Node iterator = head;
            int count = 0;
            while (iterator != null && count != index)
            {
                iterator = iterator.next;
                count++;
            }

            if (iterator == null || count != index)
            {
                throw new IndexOutOfRangeException("Error while executing program:\n" + "Неверный индекс: " + index + ". Размер вектора: " + count);
            }
            return iterator;
        }

        public Node GoToNthElementFromTheEnd(int index)
        {
            return GoToNthElement(Length - index);
        }

        public void RemoveAtPosition(int index)
        {
            if (index == 0)
            {
                if (head == null)
                {
                    return;
                }
                head = head.next;
            }

            else
            {
                Node previous = GoToNthElement(index - 1);
                if (previous.next == null)
                {
                    try
                    {
                        throw new IndexOutOfRangeException("Error while executing program:\n" + "Неверный индекс: " + index);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                else
                {
                    previous.next = previous.next.next;

                }
            }
        }


        public LinkedListVector SortVector()
        {
            int v = 0;
            for (int i = 0; i < Length - 1; i ++)
            {
                Node currenti = GoToNthElement(i);
                for (int  j = i + 1; j < Length; j ++)
                {
                    Node currentj = GoToNthElement(j);
                    if (currenti != null && currenti != null && currenti.value > currentj.value)
                    {
                        v = currenti.value;
                        currenti.value = currentj.value;
                        currentj.value = v;

                    }
                }
            }
            return this;
        }

        public void DeleteCopies()
        {
            head = МergeSort(head);
            Node iterator = head;
            Node next_next;
            if (head == null)
            {
                return;
            }
            while(iterator.next != null)
            {
                if (iterator.value == iterator.next.value)
                {
                    next_next = iterator.next.next;
                    iterator.next = null;
                    iterator.next = next_next;
                }
                else
                {
                    iterator = iterator.next;
                }
            }
        }






        // Сортировка слиянием
        static Node МergeSort(Node head)
        {
            if (head.next == null)
                return head;

            Node mid = FindMid(head);
            Node head2 = mid.next;
            mid.next = null;
            Node newHead1 = МergeSort(head);        
            Node newHead2 = МergeSort(head2);
            Node finalHead = Merge(newHead1, newHead2);

            return finalHead;
        }

        static Node Merge(Node head1, Node head2)
        {
            Node merged = new Node(0);
            Node temp = merged;

            while (head1 != null && head2 != null)
            {
                if (head1.value < head2.value)
                {
                    temp.next = head1;
                    head1 = head1.next;
                }
                else
                {
                    temp.next = head2;
                    head2 = head2.next;
                }
                temp = temp.next;
            }

            while (head1 != null)
            {
                temp.next = head1;
                head1 = head1.next;
                temp = temp.next;
            }

            while (head2 != null)
            {
                temp.next = head2;
                head2 = head2.next;
                temp = temp.next;
            }
            return merged.next;
        }

        static Node FindMid(Node head)
        {
            Node slow = head, fast = head.next;
            while (fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
            }
            return slow;
        }






        public void AddToTail(int value)
        {
            if (head == null)
            {
                head = new Node(value);
                return;
            }

            Node iterator = head;
            while (iterator.next != null)
            {
                iterator = iterator.next;
            }
            Node tail = new Node(value);
            iterator.next = tail;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder("[");
            Node iterator = head;
            while (iterator.next != null)
            {
                sb.Append(iterator.value).Append(", ");
                iterator = iterator.next;
            }
            sb.Append(iterator.value);
            sb.Append("]");
            return sb.ToString();
        }

    }

    
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("LinkedListVector:");
                LinkedListVectorWithLoop vector1 = new LinkedListVectorWithLoop();
                LinkedListVector vector2 = new LinkedListVector();
                LinkedListVector vector3 = new LinkedListVector();
                for (int i = 0; i < 10; i++)
                {
                    Console.Write("Введите " + i + " элемент: ");
                    int chislo = Convert.ToInt32(Console.ReadLine());
                    vector1.AddToTail(chislo);
                    vector2.AddToTail(chislo);
                    vector3.AddToTail(chislo);
                }
                int l = vector1.Loop().next.value;
                Console.WriteLine("\n" + "Задание 1");
                Console.WriteLine("Начальный узел после петли: " + l + "\n");

                Console.WriteLine("Задание 3");
                Console.WriteLine("Массив до удаления дубликатов: " + vector2);
                vector2.DeleteCopies();
                Console.WriteLine("Массив после удаления дубликатов: " + vector2 + "\n");



                Console.WriteLine("Задание 5");
                Console.WriteLine(vector3);
                Console.WriteLine("Введите номер элемента с конца:");
                int k = Convert.ToInt32(Console.ReadLine());
                if (k > vector2.Length)
                {
                    throw new IndexOutOfRangeException("Error while executing program:\n" + "Неверный индекс: " + k);
                }
                Console.Write(k + " элемент с конца: ");
                Console.WriteLine(vector3.GoToNthElementFromTheEnd(k).value);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error while executing program:\n" + e.Message);
            }
        }


    }
}
