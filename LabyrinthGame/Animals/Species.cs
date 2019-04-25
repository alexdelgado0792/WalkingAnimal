using System;

namespace LabyrinthGame.Animals
{
    public abstract class Species
    {
        #region Properties

        //Walking Space
        protected string[,] Matrix { get; set; }

        //Current location in Vertical vector
        private int VerticalVector { get; set; }

        //Current location in Horizontal vector
        private int HorizontalVector { get; set; }

        //Maximun location in Vertical vector
        protected int MaxVerticalVector { get; set; }

        //Maximun location in Horizontal vector
        protected int MaxHorizontalVector { get; set; }

        public bool Winner;

        private readonly string Mark = "*";
        private readonly string ExitMark = "#";

        private readonly int Steps = 1;

        #endregion Properties

        private void Right()
        {
            HorizontalVector += Steps;
            LabyrinthExit();
            Matrix[VerticalVector, HorizontalVector] = Mark;
        }

        private void Left()
        {
            HorizontalVector -= Steps;
            LabyrinthExit();
            Matrix[VerticalVector, HorizontalVector] = Mark;
        }

        private void Up()
        {
            VerticalVector -= Steps;
            LabyrinthExit();
            Matrix[VerticalVector, HorizontalVector] = Mark;
        }

        private void Down()
        {
            VerticalVector += Steps;
            LabyrinthExit();
            Matrix[VerticalVector, HorizontalVector] = Mark;
        }

        public bool Move(Movement movement)
        {
            if (!ValidateMove(movement))
            {
                Console.WriteLine("GAME OVER !!!");
                return false;
            }

            return true;
        }

        public virtual void PrintSpace_2D()
        {
            PrintMargin(Matrix.GetLength(1));

            for (int x = 0; x < Matrix.GetLength(0); x++)
            {
                for (int y = 0; y < Matrix.GetLength(1); y++)
                {
                    Console.Write(Matrix[x, y]);
                }
                Console.WriteLine();
            }

            PrintMargin(Matrix.GetLength(1));

            Console.WriteLine();
        }

        private void PrintMargin(int length)
        {
            for (int i = 0; i < length; i++)
            {
                Console.Write("=");
            }
            Console.WriteLine();
        }

        private bool ValidateMove(Movement movement)
        {
            switch (movement)
            {
                case Movement.Up:
                    if (VerticalVector - Steps < 0 || Matrix[VerticalVector - Steps, HorizontalVector] == Mark)
                    {
                        return false;
                    }
                    Up();
                    break;

                case Movement.Down:
                    if (VerticalVector + Steps >= MaxVerticalVector || Matrix[VerticalVector + Steps, HorizontalVector] == Mark)
                    {
                        return false;
                    }
                    Down();
                    break;

                case Movement.Rigth:
                    if (HorizontalVector + Steps >= MaxHorizontalVector || Matrix[VerticalVector, HorizontalVector + Steps] == Mark)
                    {
                        return false;
                    }
                    Right();
                    break;
                case Movement.Left:
                    if (HorizontalVector - Steps < 0 || Matrix[VerticalVector, HorizontalVector - Steps] == Mark)
                    {
                        return false;
                    }
                    Left();
                    break;
            }

            return true;
        }

        public void LabyrinthExit()
        {
            Winner =  Matrix[VerticalVector, HorizontalVector] == ExitMark;
        }

        protected void InitializeMatrix()
        {
            Matrix = new string[MaxVerticalVector, MaxHorizontalVector];

            for (int i = 0; i < Matrix.GetLength(0); i++)
            {
                for (int j = 0; j < Matrix.GetLength(1); j++)
                {
                    Matrix[i, j] = "-";
                }
            }

            //Initial point always first coordinates
            Matrix[0, 0] = Mark;

            //Exit of the labyrinth
            Matrix[MaxVerticalVector - 1, MaxHorizontalVector - 1] = ExitMark;
        }
    }
}