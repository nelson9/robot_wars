
namespace Test.Commands
{
    public class Move : ICommand
    {
        private readonly IRobot _robot;

        public Move(IRobot robot)
        {
            _robot = robot;
        }

        public void Execute()
        {
            _robot.Move();
        }
    }
}
