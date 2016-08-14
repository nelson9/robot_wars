using Test.Commands;

namespace Test
{ 

    public class RobotCommand
    {  
        ICommand _iCommand;

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
