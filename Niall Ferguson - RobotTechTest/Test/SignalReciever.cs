using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public interface ISignalReciever
    {
        string Update(IRobot robot);
    }
    public class PositionSignalReciever : ISignalReciever
    {     
        public string Update(IRobot robot)
        {                    
            return robot.CoordX + " " + robot.CoordY + " " + robot.Direction.ToString() + " " + robot.Penalties;
        }
     
    }
}
