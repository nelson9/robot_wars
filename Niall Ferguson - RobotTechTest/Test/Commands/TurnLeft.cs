namespace Test.Commands
{
    public class TurnLeft : ICommand
    {
        private readonly IRobot _robot;

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
