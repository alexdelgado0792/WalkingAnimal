namespace LabyrinthGame.Animals
{
    public class Turtle : Species
    {
        public Turtle(int x = 20, int y = 15)
        {
            MaxVerticalVector = y;
            MaxHorizontalVector = x;
            Steps = 1;
            InitializeMatrix();
        }

    }
}