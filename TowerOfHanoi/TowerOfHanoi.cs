using System.Net.NetworkInformation;

namespace TorreDeHanoi
{
    public class TowerOfHanoi
    {
        public Stack PinOne { get; set; } = new Stack(3);
        public Stack PinTwo { get; set; } = new Stack(3);
        public Stack PinThree { get; set; } = new Stack(3);
        public int NumberOfMoves { get; set; } = 0;

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
                PinOne.Print("Pino 1", true);
                PinTwo.Print("\nPino 2", true);
                PinThree.Print("\nPino 3", true);
                return;
            }
            else
            {
                PinOne.Push(value);
                InitializePinValues(value - 1);
            }
        }

        public void InitializeRound()
        {
            if (CheckGameEnd())
            {
                Console.WriteLine($@"Parabéns você finalizou a torre com {NumberOfMoves} movimentos!");
                return;
            }
            else
            {
                Console.Write("Digite o pino de origem: (1-3)");
                var origin = GetInputs();

                Console.Write("Digite o pino de destino (1-3): ");
                var destination = GetInputs();

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
                        Console.Write("O valor deve ser maior ou igual a 1 e menor ou igual a 2!");
                    }
                    else
                    {
                        result = value;
                        break;
                    }
                }

            }
           
            return result;
        }

        public void MoveDiscs(Stack pinOrigin, Stack pinDestination)
        {

        }

        public bool CheckGameEnd()
        {
            return PinThree.StackArray[0] == 1 && PinThree.StackArray[1] == 2 && PinThree.StackArray[2] == 3;
        }
    }
}
