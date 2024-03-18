using System;

namespace Math_Game
{
    class Program
    {
        enum Enum_Operator
        {
            ADDITION = 1,
            SUBTRACTION = 2,
            MULTIPLICATION = 3
        }
        static bool Ask_Question(int min, int max)
        {
            Random rand_Number = new Random(); // Random number generator
            int answer = 0; // User answer
            while (true) // Loop until the user enters a valid number
            {
                int num1 = rand_Number.Next(min, max + 1); // Generate a random number between min and max
                int num2 = rand_Number.Next(min, max + 1); // Generate a random number between min and max

                Enum_Operator operator_ = (Enum_Operator)rand_Number.Next(1, 3 + 1); // Generate a random operator
                int operator_answer; // The answer to the question
                switch (operator_) // Switch statement to determine the operator
                {
                    case Enum_Operator.ADDITION:
                        Console.Write($"What is {num1} + {num2} ? ");
                        operator_answer = num1 + num2;
                        break;
                    case Enum_Operator.SUBTRACTION:
                        Console.Write($"What is {num1} - {num2} ? ");
                        operator_answer = num1 - num2;
                        break;
                    case Enum_Operator.MULTIPLICATION:
                        Console.Write($"What is {num1} * {num2} ? ");
                        operator_answer = num1 * num2;
                        break;
                    default:
                        Console.WriteLine("Invalid operator");
                        return false;
                }
                
                /*if (operator_ == Enum_Operator.ADDITION)
                {
                    Console.Write($"What is {num1} + {num2} ? ");
                    operator_answer = num1 + num2;
                }
                else if (operator_ == Enum_Operator.SUBTRACTION)
                {
                    Console.Write($"What is {num1} - {num2} ? ");
                    operator_answer = num1 - num2;
                }
                else if (operator_ == Enum_Operator.MULTIPLICATION)
                {
                    Console.Write($"What is {num1} * {num2} ? ");
                    operator_answer = num1 * num2;
                }
                else
                {
                    Console.WriteLine("Invalid operator");
                    return false;
                }*/

                string user_input = Console.ReadLine(); // Get the user input

                try // Try to parse the user input
                {
                    answer = int.Parse(user_input); // Parse the user input
                    if (answer == operator_answer) // If the user input is equal to the answer
                    {
                        return true;
                    }
                    return false;
                }
                catch 
                {
                    Console.WriteLine("Please enter a number."); // If the user input is not a number
                }
            }
        }
        static void Main(string[] args)
        {
            const int NUMBER_OF_QUESTIONS = 5;
            int score = 0;
            int life = 4;
            const int NUMBER_MIN = 1;
            const int NUMBER_MAX = 10;

            for (int questions = 0; questions < NUMBER_OF_QUESTIONS; questions++)
            {
                Console.WriteLine();
                Console.WriteLine($"Number of life {life}");
                Console.WriteLine();
                Console.WriteLine($"Number of question : {questions + 1} / {NUMBER_OF_QUESTIONS}");
                bool user_answer = Ask_Question(NUMBER_MIN, NUMBER_MAX);

                if (user_answer)
                {
                    Console.WriteLine("Good guess !");
                    score++;
                }
                else
                {
                    Console.WriteLine("Wrong answer !");
                    life--;

                }
            }
            Console.WriteLine($"Number of score {score} / {NUMBER_OF_QUESTIONS}");
            Console.WriteLine();

            int moy = NUMBER_OF_QUESTIONS / 2;
            if (score == NUMBER_OF_QUESTIONS)
            {
                Console.WriteLine("Great jobs !");
            }
            else if (score == 0)
            {
                Console.WriteLine("Work your math level !");
            }
            else if (score >= moy)
            {
                Console.WriteLine("Not bad !");
            }
            else
            {
                Console.WriteLine("You can do better !");
            }
        }
    }
}