﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HBMarsRover
{
    public class Rover
    {
        public char Direction;

        public int X;
        public int Y;

        private int _width;
        private int _height;

        public Rover(string size)
        {
            string[] sizeArray = size.Split(' ');
            if (sizeArray.Length != 2)
                throw new Exception("Invalid size input.");
            bool isWidthInt = int.TryParse(sizeArray[0], out _width);
            bool isHeightInt = int.TryParse(sizeArray[1], out _height);
            if (isHeightInt == false | isWidthInt == false)
                throw new Exception("Invalid Size.");
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
            bool isYInt = int.TryParse(positions[1], out Y);
            bool isDirectionChar = char.TryParse(positions[2], out Direction);

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
                if (command == 'M')
                    this.Move();
                else
                    this.Turn(command);
            }
        }

        public string GetPosition()
        {
            return string.Format("{0} {1} {2}", X, Y, Direction);
        }

        private bool ValidatePosition()
        {
            bool validX = X < _width;
            bool validY = Y < _height;
            return validX && validY;
        }

        private void Move()
        {

            switch (this.Direction)
            {
                case 'N':
                    this.Y += 1;
                    break;

                case 'E':
                    this.X += 1;
                    break;

                case 'S':
                    this.Y -= 1;
                    break;

                case 'W':
                    this.X -= 1;
                    break;
            }
        }

        private void Turn(char way)
        {
            switch (way)
            {
                case 'L':
                    this.TurnLeft();
                    break;
                case 'R':
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
                case 'W':
                    this.Direction = 'S';
                    break;
                case 'S':
                    this.Direction = 'E';
                    break;
                case 'E':
                    this.Direction = 'N';
                    break;
                case 'N':
                    this.Direction = 'W';
                    break;
            }
        }
        private void TurnRight()
        {
            switch (Direction)
            {
                case 'W':
                    this.Direction = 'N';
                    break;
                case 'N':
                    this.Direction = 'E';
                    break;
                case 'E':
                    this.Direction = 'S';
                    break;
                case 'S':
                    this.Direction = 'W';
                    break;
            }
        }
    }
}