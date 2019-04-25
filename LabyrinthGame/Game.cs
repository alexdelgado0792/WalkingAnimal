using LabyrinthGame.Animals;
using System;
using System.Linq;

namespace LabyrinthGame
{
    public class Game
    {
        public static Species Start()
        {
            if (!DefineGameSpace())
            {
                return new Turtle();
            }

            Console.WriteLine("Define X coordinates length");
            var x = Console.ReadLine();

            if (!x.All(char.IsDigit))
            {
                Console.WriteLine("Not Valid option. Try Again.");
                Start();
            }

            Console.WriteLine("Define Y coordinates lenght");
            var y = Console.ReadLine();

            if (!y.All(char.IsDigit))
            {
                Console.WriteLine("Not Valid option. Try Again.");
                Start();
            }

            Console.WriteLine($"Matrix Size is {x},{y}");
            Console.Clear();

            return new Turtle(Convert.ToInt32(x), Convert.ToInt32(y));
        }

        public static void Play(Species animal)
        {
            Console.Clear();
            animal.PrintSpace_2D();
            string option = Menu();

            if (!option.All(char.IsDigit))
            {
                Console.WriteLine("Not Valid option. Try Again.");
                Play(animal);
            }

            var move = (Movement)Convert.ToInt32(option);
            if (!Enum.IsDefined(typeof(Movement), move))
            {
                Console.WriteLine("Not Valid option. Try Again.");
                Play(animal);
            }

            if (animal.Move(move))
            {
                Play(animal);

            }
            else
            {
                if (ContinuePlaying())
                {
                    Console.Clear();
                    Play(Start());
                }
            }
        }

        private static string Menu()
        {
            Console.WriteLine("Type the number of your movement:");
            Console.WriteLine("1) Up.");
            Console.WriteLine("2) Down.");
            Console.WriteLine("3) Left.");
            Console.WriteLine("4) Right.");
            var option = Console.ReadLine();

            return option;
        }

        private static bool ContinuePlaying()
        {
            Console.WriteLine("Continue Playing ?");
            Console.WriteLine("0.- No.     1.- Yes.");
            var option = Console.ReadLine();

            if (!option.All(char.IsDigit))
            {
                Console.WriteLine("Not Valid option. Try Again.");
                ContinuePlaying();
            }

            var value = Convert.ToInt32(option);
            if (value < 0 || value > 1)
            {
                Console.WriteLine("Not Valid option. Try Again.");
                ContinuePlaying();
            }

            return Convert.ToBoolean(value);
        }

        private static bool DefineGameSpace()
        {
            Console.WriteLine("Do you want to specify the game space?");
            Console.WriteLine("0.- No.     1.- Yes.");
            var option = Console.ReadLine();

            if (!option.All(char.IsDigit))
            {
                Console.WriteLine("Not Valid option. Try Again.");
                ContinuePlaying();
            }

            var value = Convert.ToInt32(option);
            if (value < 0 || value > 1)
            {
                Console.WriteLine("Not Valid option. Try Again.");
                ContinuePlaying();
            }

            return Convert.ToBoolean(value);
        }
    }
}