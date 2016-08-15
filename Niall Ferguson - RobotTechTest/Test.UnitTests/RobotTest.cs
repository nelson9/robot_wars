using NUnit.Framework;
using System;
using Test.Commands;
using Test.Enums;

namespace Test.UnitTests
{
    [TestFixture]
    public class RobotTest
    {
        private Arena _arena;
        private ISignalReciever _signalReciever;

        [SetUp]
        public void Setup()
        {
            _arena = new Arena(4, 4);
            _signalReciever = new PositionSignalReciever();
        }

        [Test]
        public void RobotCommands_Scenario1()
        {
            //arrange

            IRobot robot = new Robot(0, 2, Direction.E, _arena, _signalReciever);
            var move = new RobotCommand(new Move(robot));
            var turnLeft = new RobotCommand(new TurnLeft(robot));
            var turnRight = new RobotCommand(new TurnRight(robot));


            //act

            move.Send();
            turnLeft.Send();
            move.Send();
            turnRight.Send();
            move.Send();
            move.Send();
            move.Send();
            turnRight.Send();
            move.Send();
            move.Send();
            turnRight.Send();
            turnRight.Send();

            var actual = _signalReciever.Update(robot);

            //assert
            Assert.AreEqual("4 1 N 0", actual);
        }
        [Test]
        public void RobotCommands_Scenario2()
        {
            //arrange

            IRobot robot = new Robot(4, 4, Direction.S, _arena, _signalReciever);
            var move = new RobotCommand(new Move(robot));
            var turnLeft = new RobotCommand(new TurnLeft(robot));
            var turnRight = new RobotCommand(new TurnRight(robot));
       
            //act
            turnLeft.Send();
            move.Send();
            turnLeft.Send();
            turnLeft.Send();
            move.Send();
            move.Send();
            turnLeft.Send();
            move.Send();
            move.Send(); 
            move.Send();
            turnRight.Send();
            move.Send();
            move.Send();
            

            var actual = _signalReciever.Update(robot);

            //assert
            Assert.AreEqual("0 1 W 1", actual);
        }
        [Test]
        public void RobotCommands_Scenario3()
        {
            //arrange

            IRobot robot = new Robot(2, 2, Direction.W, _arena, _signalReciever);
            var move = new RobotCommand(new Move(robot));
            var turnLeft = new RobotCommand(new TurnLeft(robot));
            var turnRight = new RobotCommand(new TurnRight(robot));


            //act

            move.Send();
            turnLeft.Send();
            move.Send();
            turnLeft.Send();
            move.Send();
            turnLeft.Send();
            move.Send();
            turnRight.Send();
            move.Send();
            turnRight.Send();
            move.Send();
            turnRight.Send();
            move.Send();
            turnRight.Send();
            move.Send();


            var actual = _signalReciever.Update(robot);
    

            //assert
            Assert.AreEqual("2 2 N 0", actual);
        }
        [Test]
        public void RobotCommands_Scenario4()
        {
            //arrange

            IRobot robot = new Robot(1, 3, Direction.N, _arena, _signalReciever);
            var move = new RobotCommand(new Move(robot));
            var turnLeft = new RobotCommand(new TurnLeft(robot));
            var turnRight = new RobotCommand(new TurnRight(robot));


            //act
            move.Send();
            move.Send();
            turnLeft.Send();
            move.Send();
            move.Send();
            turnLeft.Send();
            move.Send();
            move.Send();
            move.Send();
            move.Send();
            move.Send();

            var actual = _signalReciever.Update(robot);


            //assert
            Assert.AreEqual("0 0 S 3", actual);
        }
    }
}
