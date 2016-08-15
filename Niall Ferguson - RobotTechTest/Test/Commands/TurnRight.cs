namespace Test.Commands
{
    public class TurnRight : ICommand
    {
        private readonly IRobot _robot;

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
