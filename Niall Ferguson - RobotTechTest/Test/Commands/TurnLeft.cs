using Test.Commands;

namespace Test
{
    public class TurnLeft : ICommand
    {
        private IRobot _robot;

        public TurnLeft(IRobot robot)
        {
            _robot = robot;
        }

        public void Execute()
        {
            _robot.TurnLeft();
        }
    }
}
