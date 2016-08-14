using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public interface IRobot
    {
        void Move();
        void TurnLeft();
        void TurnRight();
        int CoordX { get; }
        int CoordY { get; }
        int Penalties { get; }
        Direction Direction { get; }
    }

    public class Robot : IRobot
    {
        private ISignalReciever _signalReceiver;
        private CrashSensor _crashSensor;

        public int CoordX { get; private set; }
        public int CoordY { get; private set; }
        public int Penalties { get; private set; }
        public Direction Direction { get; private set; }       

        public Robot(int coordX, int coordY, Direction direction, CrashSensor crashSensor, ISignalReciever signalreceiver)
        {
            CoordX = coordX;
            CoordY = coordY;
            Direction = direction;
            Penalties = 0;
            _crashSensor = crashSensor;
            _signalReceiver = signalreceiver;
        }

        public void TurnLeft()
        {
            switch (Direction)
            {
                case Direction.N:
                    Direction = Direction.W;
                    break;
                case Direction.E:
                    Direction = Direction.N;
                    break;
                case Direction.S:
                    Direction = Direction.E;
                    break;
                case Direction.W:
                    Direction = Direction.S;
                    break;
            }
            SendSignal();
        }

        public void TurnRight()
        {
            switch (Direction)
            {
                case Direction.N:
                    Direction = Direction.E;
                    break;
                case Direction.E:
                    Direction = Direction.S;
                    break;
                case Direction.S:
                    Direction = Direction.W;
                    break;
                case Direction.W:
                    Direction = Direction.N;
                    break;
            };
            SendSignal();
        }

        public void Move()
        {
            int move;
            switch (Direction)
            {
                case Direction.N:
                    move = (CoordY + 1);
                    TryMove(CoordX, move);
                    break;
                case Direction.E:
                    move = CoordX + 1;
                    TryMove(move, CoordY);
                    break;
                case Direction.S:
                    move = CoordY - 1;
                    TryMove(CoordX, move);
                    break;
                case Direction.W:
                    move = CoordX - 1;
                    TryMove(move, CoordY);
                    break;
            }
            SendSignal();
        }

        private void SendSignal()
        {
            _signalReceiver.Update(this);
        }

        private void TryMove(int x, int y)
        {
            if (_crashSensor.Update())
            {
                Penalties++;
            }
            else
            {
                CoordX = x;
                CoordY = y;
            }
        }       
    }
}
