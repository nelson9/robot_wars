using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Test.Commands;

namespace Test.UnitTests
{
    [TestClass]
    public class RobotTest
    {
        [Setup]
        public void Seup()
        {

        }
        [TestMethod]
        public void TestMethod1()
        {
            //arrange
            var arena = new Arena(5, 5);
            var signalReciever = new SignalReciever();
            IRobot robot = new Robot(0, 0, Direction.N, arena, signalReciever);


            var move = new RobotCommand(new Move(robot));
            var turnLeft = new RobotCommand(new TurnLeft(robot));
            var turnRight = new RobotCommand(new TurnRight(robot));




            //assert





            //act
        }
    }
}
