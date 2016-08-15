using Test.Commands;

namespace Test
{ 

    public class RobotCommand
    {
        readonly ICommand _iCommand;

        public RobotCommand(ICommand command)
        {
            _iCommand = command;
        }

        public void Send()
        {
            _iCommand.Execute();
        }
    }
}
