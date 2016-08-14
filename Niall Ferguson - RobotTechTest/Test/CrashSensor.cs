using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public interface ISensor
    {
        bool Update(IRobot robot);
    }
    public class CrashSensor : ISensor
    {
        private readonly Arena _arena;

        public CrashSensor(Arena arena)
        {
            _arena = arena;
        }

        public bool Update(IRobot robot) {

            if (robot.CoordX < 0 || robot.CoordX > _arena.X || robot.CoordY < 0 || robot.CoordY > _arena.Y)
            {
                return true;
            }
            else
            {
                return false;
            }
        }           

    }
}
