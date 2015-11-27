/**
 * Word Play is basic two player game that removes the letters from a word
 * where the other play is the guess the original word.
 * Copyright (C) 2014  Philip
 * 
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 * 
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */

using System;

namespace Word_Play
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Word Play";
            game();
            Console.WriteLine("Press enter to quit");
            Console.ReadLine();
        }
        static void game()
        {
            string Player1 = "Player 1";
            string Player2 = "Player 2";
            int p1s = 0, p2s = 0;
            Console.WriteLine("Insert Player 1 name");
            string input = Console.ReadLine();
            if (input != "")
                Player1 = input;
            input = null;
            Console.WriteLine("Insert Player 2 name");
            input = Console.ReadLine();
            if (input != "")
                Player2 = input;
            input = null;
            int turn = 1;
            while (true)
            {
                if (turn == 1)
                {
                    Console.Title = string.Format("Word Play - {0}", Player1);
                    Console.WriteLine(string.Format("Enter a word for {0} to guess", Player1));
                }
                if (turn == 2)
                {
                    Console.Title = string.Format("Word Play - {0}", Player2);
                    Console.WriteLine(string.Format("Enter a word for {0} to guess", Player2));
                }
                string word = Console.ReadLine();
                Console.Clear();
                string gameWord = word.Replace("a", "_").Replace("e", "_").Replace("i", "_").Replace("o", "_").Replace("u", "_");
                Console.WriteLine(string.Format("Finish the word: \n{0}", gameWord.Trim().ToLower()));
                int score = 10;
                while (true)
                {
                    if (Console.ReadLine().ToLower() == word.ToLower())
                    {
                        Console.WriteLine("Welldone you scored {0}", score);
                        if (turn == 1)
                            p1s += score;
                        if (turn == 2)
                            p2s += score;
                        break;
                    }
                    Console.WriteLine("Wrong Please Try Again");
                    score--;
                    if (score == 0)
                    {
                        Console.WriteLine(string.Format("Sorry you loss the word was {0}", word));
                        break;
                    }
                }
                bool c = false;
                if (turn == 2 && c == false)
                {
                    while (true)
                    {
                        Console.WriteLine("Do you want to continue? Y/N");
                        string temp = Console.ReadLine();
                        if (temp.ToUpper() == "Y")
                        {
                            turn = 1;
                            c = true;
                            break;
                        }
                        if (temp.ToUpper() == "N")
                        {
                            Console.WriteLine(string.Format("{0} final score: {1} \n{2} final score: {3}", Player1, p1s, Player2, p2s));
                            break;
                        }
                    }
                    if (turn == 2)
                        break;
                }
                if (turn == 1 && c == false)
                {
                    turn = 2;
                    c = true;
                }
            }
        }
    }
}
