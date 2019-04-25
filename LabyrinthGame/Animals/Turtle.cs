namespace WalkingTurtle.Animals
{
    public class Turtle : Species
    {
        public Turtle(int x = 20, int y = 20)
        {
            MaxVerticalVector = x;
            MaxHorizontalVector = y;
            Matrix = new string[x, y];
            Steps = 1;
            InitializeMatrix();
        }

    }
}