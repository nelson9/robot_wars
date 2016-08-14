using Test.Commands;

namespace Test
{
    public class TurnRight : ICommand
    {
        private IRobot _robot;

        public TurnRight(IRobot robot)
        {
            _robot = robot;
        }

        public void Execute()
        {
            _robot.TurnRight();
        }
    }
}
