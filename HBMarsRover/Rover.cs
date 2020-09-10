using System;
using System.Collections.Generic;
using System.Text;

namespace HBMarsRover
{
    public class Rover
    {
        public Direction Direction;

        public int X;
        public int Y;

        public Plateau _plateau;
                
        public Rover(string size)
        {
            _plateau = new Plateau();
            string[] sizeArray = size.Split(' ');
            if (sizeArray.Length != 2)
                throw new Exception("Invalid size input.");
            bool isWidthInt = int.TryParse(sizeArray[0], out _plateau._width);
            bool isHeightInt = int.TryParse(sizeArray[1], out _plateau._height);
            if (isHeightInt == false | isWidthInt == false | _plateau._width < 1 | _plateau._height < 1)
                throw new Exception("Invalid size.");
        }

        public void SetPosition(string position)
        {
            string[] positionArray = position.ToUpper().Split(' ');
            if (positionArray.Length != 3)
                throw new Exception("Invalid position input.");
            if (this.ValidateAndAssign(positionArray))
                throw new Exception("Invalid position.");

        }

        private bool ValidateAndAssign(string[] positions)
        {

            bool isCorrectLenght = positions.Length > 2;
            bool isXInt = int.TryParse(positions[0], out X);
            if (!isXInt || Convert.ToInt32(positions[0]) < 0)
            {
                throw new Exception("Invalid X position.");
            }
            bool isYInt = int.TryParse(positions[1], out Y);
            if (!isYInt || Convert.ToInt32(positions[1]) < 0)
            {
                throw new Exception("Invalid Y position.");
            }
            bool isDirectionChar = Enum.TryParse(positions[2], out Direction);
            if (!isDirectionChar)
            {
                throw new Exception("Invalid Direction.");
            }
            return isCorrectLenght == false
                    | isXInt == false
                    | isYInt == false
                    | isDirectionChar == false;
        }

        public void CommandExecute(string commands)
        {
            if (ValidatePosition() == false)
                return;

            char[] commandArray = commands.ToUpper().ToCharArray();
            foreach (var command in commandArray)
            {
                if (command.ToString() == Movement.M.ToString())
                    this.Move();
                else if (command.ToString() == Movement.L.ToString())
                    this.Turn(Movement.L);
                else if (command.ToString() == Movement.R.ToString())
                    this.Turn(Movement.R);
                else
                    throw new Exception("Invalid command.");
            }
        }

        public string GetPosition()
        {
            return string.Format("{0} {1} {2}", X, Y, Direction);
        }

        private bool ValidatePosition()
        {
            bool validX = X < _plateau._width;
            bool validY = Y < _plateau._height;
            return validX && validY;
        }

        private void Move()
        {

            switch (this.Direction)
            {
                case Direction.N:
                    this.Y += 1;
                    break;

                case Direction.E:
                    this.X += 1;
                    break;

                case Direction.S:
                    this.Y -= 1;
                    break;

                case Direction.W:
                    this.X -= 1;
                    break;
            }
        }

        private void Turn(Movement way)
        {
            switch (way)
            {
                case Movement.L:
                    this.TurnLeft();
                    break;
                case Movement.R:
                    this.TurnRight();
                    break;
                default:
                    throw new Exception("Invalid Way!");
            }
        }
        private void TurnLeft()
        {
            switch (Direction)
            {
                case Direction.W:
                    this.Direction = Direction.S;
                    break;
                case Direction.S:
                    this.Direction = Direction.E;
                    break;
                case Direction.E:
                    this.Direction = Direction.N;
                    break;
                case Direction.N:
                    this.Direction = Direction.W;
                    break;
            }
        }
        private void TurnRight()
        {
            switch (Direction)
            {
                case Direction.W:
                    this.Direction = Direction.N;
                    break;
                case Direction.N:
                    this.Direction = Direction.E;
                    break;
                case Direction.E:
                    this.Direction = Direction.S;
                    break;
                case Direction.S:
                    this.Direction = Direction.W;
                    break;
            }
        }
    }
}
