using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Enums;

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
        private readonly ISignalReciever _signalReceiver;
        private readonly Arena _arena;

        public int CoordX { get; private set; }
        public int CoordY { get; private set; }
        public int Penalties { get; private set; }
        public Direction Direction { get; private set; }       

        public Robot(int coordX, int coordY, Direction direction, Arena arena, ISignalReciever signalreceiver)
        {
            CoordX = coordX;
            CoordY = coordY;
            Direction = direction;
            Penalties = 0;
            _arena = arena;
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
            if (IsOutOfBounds(x, y))
            {
                Penalties++;
            }
            else
            {
                CoordX = x;
                CoordY = y;
            }
        }

        private bool IsOutOfBounds(int x, int y)
        {
            return x < 0 || x > _arena.X || y < 0 || y > _arena.Y;
        }
    }
}
