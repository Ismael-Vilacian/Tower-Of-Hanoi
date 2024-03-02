using System.Net.NetworkInformation;

namespace TorreDeHanoi
{
    public class TowerOfHanoi
    {
        public Stack PinOne { get; set; } = new Stack(3);
        public Stack PinTwo { get; set; } = new Stack(3);
        public Stack PinThree { get; set; } = new Stack(3);
        public int NumberOfMoves { get; set; } = 0;
        public Dictionary<int, Stack> Pins { get; set; } = new Dictionary<int, Stack>();

        public void StartGame()
        {
            Console.WriteLine("Game start!\n\n");

            InitializePinValues(3);
            InitializeRound();
        }

        public void InitializePinValues(int value)
        {
            if (PinOne.IsFull())
            {
                PrintValues();
                Pins = new Dictionary<int, Stack> { { 1, PinOne }, { 2, PinTwo }, { 3, PinThree } };
                return;
            }
            else
            {
                PinOne.Push(value);
                InitializePinValues(value - 1);
            }
        }

        public void PrintValues()
        {
            PinOne.Print("Pino 1", true);
            PinTwo.Print("\nPino 2", true);
            PinThree.Print("\nPino 3", true);
        }

        public void InitializeRound()
        {
            if (CheckGameEnd())
            {
                Console.WriteLine("\n\nParabéns você finalizou a torre com "+NumberOfMoves+" movimentos!\n\n");
                return;
            }
            else
            {
                Console.WriteLine("\nDigite o pino de origem (1-3): ");
                var origin = GetInputs();

                Console.WriteLine("\nDigite o pino de destino (1-3): ");
                var destination = GetInputs();

                MoveDiscs(origin, destination);

                InitializeRound();
            }
        }

        public int GetInputs()
        {
            int result;
            while (true)
            {
                var input = Console.ReadLine();
                if (int.TryParse(input, out int value))
                {
                    if (value < 1 || value > 3)
                    {
                        Console.WriteLine("O valor deve ser maior ou igual a 1 e menor ou igual a 2!\n");
                    }
                    else
                    {
                        result = value;
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Valor inválido, insira um valor numerico maior ou igual a 1 e menor ou igual a 2!\n");
                }

            }

            return result;
        }

        public void MoveDiscs(int origin, int destination)
        {
            var pinOrigin = Pins[origin];
            var pinDestination = Pins[destination];

            if (pinOrigin.IsEmpty())
            {
                Console.WriteLine("O pino de origem está vazio!\n\n");
                return;
            }

            if (pinDestination.IsFull())
            {
                Console.WriteLine("O pino de destino está cheio!\n\n");
                return;
            }

            var lastValuleOrigin = pinOrigin.StackArray.Count(valor => valor.HasValue);
            var lastValuleDestination = pinDestination.StackArray.Count(valor => valor.HasValue);

            if (lastValuleDestination != 0 && lastValuleOrigin > lastValuleDestination)
            {
                Console.WriteLine("Não é possível colocar um valor maior sobre um valor menor!\n");
                return;
            }


            pinDestination.Push((int)pinOrigin.StackArray[lastValuleOrigin - 1]);
            pinOrigin.Pop();
            NumberOfMoves++;

            PrintValues();
        }

        public bool CheckGameEnd()
        {
            return PinThree.StackArray[0] == 3 && PinThree.StackArray[1] == 2 && PinThree.StackArray[2] == 1;
        }
    }
}
