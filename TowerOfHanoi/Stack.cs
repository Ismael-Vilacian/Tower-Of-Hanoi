namespace TorreDeHanoi
{
    public class Stack
    {
        public int Top { get; set; }
        public int Size { get; set; }
        public int?[] StackArray { get; set; }

        public Stack(int size)
        {
            Top = -1;
            Size = size;
            StackArray = new int?[size];
        }

        public bool IsFull()
        {
            return Top == Size - 1;
        }

        public bool IsEmpty()
        {
            return Top == -1;
        }

        public void Push(int value)
        {
            if (IsFull())
            {
                Console.WriteLine("A pilha está cheia!");
                return;
            }
            else
            {
                Top++;
                StackArray[Top] = value;
            }
        }

        public void Pop()
        {
            if (IsEmpty())
            {
                Console.WriteLine("A pilha está vazia!");
                return;
            }
            else
            {
                StackArray[Top] = null;
                Top--;
            }
        }

        public void Print(string? topDescription = null, bool printZerosWhenEmpty = false)
        {
            if (IsEmpty() && !printZerosWhenEmpty)
            {
                Console.WriteLine("A pilha está vazia");
                return;
            }

            if (!string.IsNullOrEmpty(topDescription)) Console.WriteLine(topDescription);
            if (!printZerosWhenEmpty)
            {
                for (int top = Top; top >= 0; top--)
                {
                    Console.WriteLine(StackArray[top]);
                }
            }
            else
            {
                for (int top = Size - 1; top >= 0; top--)
                {
                    if (top <= Top)
                    {
                        Console.WriteLine(StackArray[top]);
                    }
                    else
                    {
                        Console.WriteLine(0);
                    }
                }
            }
        }
    }
}
