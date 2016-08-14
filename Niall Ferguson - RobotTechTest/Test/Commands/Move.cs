using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Commands
{
    public class Move : ICommand
    {
        private IRobot _robot;

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
