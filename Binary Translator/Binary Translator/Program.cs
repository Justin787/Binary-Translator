using System;
using System.Collections.Generic;
using System.Text;

namespace Binary_Translator
{
    class Program
    {
        //Global variables
        static int userMenuInput;

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("~Binary Translator by Justin Decru~");                                                      
   

                Console.WriteLine("\n Enter a number to select a function: \n" +
                    " 1 - Decimal to Binary\n" +
                    " 2 - Binary to Decimal\n" +
                    " 3 - String to Binary\n" +
                    " 4 - Binary to String\n" +
                    " 5 - Exit Program\n");
                userMenuInput = Convert.ToInt32(Console.ReadLine());

                Console.Clear();

                if (userMenuInput == 1)//Decimal to binary
                {
                    DecimalToBinary();
                }
                else if (userMenuInput == 2)//Binary to decimal
                {
                    BinaryToDecimal();
                }
                else if (userMenuInput == 3)//String to binary
                {
                    StringToBinary();
                }
                else if (userMenuInput == 4)//Binary to string
                {
                    BinaryToString();
                }
                else if (userMenuInput == 5)//Break loop
                {
                    break;
                }

                //Reset loop
                Console.WriteLine("\n\nPress [ENTER] to continue...");
                Console.ReadLine();
                Console.Clear();
            }
        }

        //Convert decimal to binary
        static void DecimalToBinary()
        {
            //Get user input
            Console.Write(" Decimal: ");
            int input = int.Parse(Console.ReadLine());

            //Translate to binary
            Console.Write(" Binary: ");
            Console.WriteLine("{0}", Convert.ToString(input, 2));
        }

        //Convert binary to decimal
        static void BinaryToDecimal()
        {
            //Get user input
            Console.Write(" Binary: ");
            string input = Console.ReadLine();

            //Translate to decimal
            Console.Write(" Decimal: ");
            Console.WriteLine("{0}", Convert.ToInt32(input, 2));
        }

        //Convert string to binary
        static void StringToBinary()
        {
            //Create stringbuilder 
            StringBuilder sb = new StringBuilder();

            //Get user input
            Console.Write(" String: ");
            string input = Console.ReadLine();

            //Translate to binary
            foreach(char letter in input.ToCharArray())
            {
                sb.Append(Convert.ToString(letter, 2).PadLeft(8, '0'));
            }
            //Output data
            Console.Write(" Binary: " + sb.ToString());
        }

        //Convert binary to string
        static void BinaryToString()//I can't find a built in function for this so I have to do it manually
        {
            //Variables
            string alphabetL = "\'abcdefghijklmnopqrstuvwxyz{|}~";
            string alphabetU = "@ABCDEFGHIJKLMNOPQRSTUVWXYZ[\\]^_";
            string specialChars = " !\"#$%&\'()*+,-./0123456789:;<=>?";
            string output = "";

            //Get user input
            Console.Write(" Binary: ");
            string input = Console.ReadLine();

            //Divide into characters
            int letters = input.Length / 8;

            //Set up list of characters in binary
            List<string> lettersBi = new List<string>();
            for (int i = 0; i < input.Length; i = i + 8)
            {
                lettersBi.Add(input.Substring(i, 8));
            }

            //Decode binary letters
            foreach(string letter in lettersBi)
            {
                //Set up variables
                string charID5 = letter.Substring(3);//Gets last 5 numbers
                string charID3 = letter.Substring(0, 3);//Gets first 3 numbers
                int curID = 0;

                //Find value of last 5 numbers
                if (charID5.Substring(4, 1) == "1")//1
                {
                    curID += 1;
                }
                if (charID5.Substring(3, 1) == "1")//2
                {
                    curID += 2;
                }
                if (charID5.Substring(2, 1) == "1")//4
                {
                    curID += 4;
                }
                if (charID5.Substring(1, 1) == "1")//8
                {
                    curID += 8;
                }
                if (charID5.Substring(0, 1) == "1")//16
                {
                    curID += 16;
                }

                //Find value of first 3 numbers
                if (charID3.Substring(1, 1) == "1" && charID3.Substring(2, 1) == "1")//Letter is lowercase
                {
                    output += alphabetL.Substring(curID, 1);
                }
                else if (charID3.Substring(1, 1) == "1" && charID3.Substring(2, 1) == "0")//Letter is uppercase
                {
                    output += alphabetU.Substring(curID, 1);
                }
                else if(charID3.Substring(1, 1) == "0" && charID3.Substring(2, 1) == "1")//Special character
                {
                    output += specialChars.Substring(curID, 1);
                }
            }

            //Output
            Console.WriteLine(" String: " + output);
        }
    }
}
