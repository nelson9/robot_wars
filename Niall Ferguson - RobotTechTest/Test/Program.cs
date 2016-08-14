using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Commands;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var arena = new Arena(4, 4);
            var signalReciever = new PositionSignalReciever();
            IRobot robot = new Robot(1, 3, Direction.N, arena, signalReciever);

            
            var move = new RobotCommand(new Move(robot));
            var turnLeft = new RobotCommand(new TurnLeft(robot));
            var turnRight = new RobotCommand(new TurnRight(robot));

            ConsoleKeyInfo command;
            do
            {
                command = Console.ReadKey();
                switch (command.Key)
                {
                    case ConsoleKey.M:
                        move.Send();                                       
                        break;

                    case ConsoleKey.L:
                        turnLeft.Send();                  
                        break;

                    case ConsoleKey.R:
                        turnRight.Send();               
                        break;
                }

            } while (command.Key != ConsoleKey.Escape);       
          
        }      

    }
}
