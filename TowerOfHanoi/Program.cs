using System;

namespace TorreDeHanoi // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var Game = new TowerOfHanoi();
            Game.StartGame();
        }
    }
}