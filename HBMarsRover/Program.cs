using System;

namespace HBMarsRover
{
    class Program
    {
        static void Main(string[] args)
        {
            Rover rover = new Rover("5 5");
            rover.SetPosition("1 2 N");
            rover.CommandExecute("LMLMLMLMM");
            Console.WriteLine(rover.GetPosition());

            rover = new Rover("5 5");
            rover.SetPosition("3 3 E");
            rover.CommandExecute("MMRMMRMRRM");
            Console.WriteLine(rover.GetPosition());

            Console.ReadKey();
        }
    }
}
