namespace LabyrinthGame.Animals
{
    public class Turtle : Species
    {
        public Turtle(int x = 10, int y = 5)
        {
            MaxVerticalVector = y;
            MaxHorizontalVector = x;
            
            InitializeMatrix();
        }

    }
}