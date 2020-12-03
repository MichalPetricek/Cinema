using System;
using System.Collections.Generic;

namespace Cinema
{
    class Program
    {
        static void Main(string[] args)
        {
            
        int[,] a = {
           {1,2,3,4,5,6,7,8,9,10},
           {11,12,13,14,15,16,17,18,19,20},  
           {21,22,23,24,25,26,27,28,29,30},
           {31,32,33,34,35,36,37,38,39,40},
           {41,42,43,44,45,46,47,48,49,50}, //vytvoří 2d pole
        };

            void WriteTable() //vypisuje tabulku do console
            {
                for (int x = 0; x < 5; x++)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        Console.Write(a[x, i]);
                        if (a[x, i] < 10)
                        {
                            Console.Write(" ");
                        }
                        Console.Write("|");
                    }
                    Console.WriteLine();
                }
            Console.WriteLine("NOTE: 0 = occupied");
            }
            int[] GetIntArray(int num) //rozdělí zadané sedadlo na jednotlivé čísla pro získání x,y polohy v 2d poli 
            {
                List<int> listOfInts = new List<int>();
                while (num > 0)
                {
                    listOfInts.Add(num % 10);
                    num = num / 10;
                }
                listOfInts.Reverse();
                return listOfInts.ToArray();
            }
            void Occupied()// změní hodnotu obsazeného místa v poli na 1
            {
                List<int> seats = new List<int>();
                for (int i = 0; i < 100; i++)
                {
                    Console.WriteLine("Choose seat:");
                    string snumber;
                    snumber = Console.ReadLine();
                    int number = int.Parse(snumber);
                    if (number <= 50 && number > 0)
                    {
                        seats.Add(number);
                        if (number > 9)
                        {
                            int[] arr = GetIntArray(number);
                            if (arr[1] == 0)
                            {
                                arr[1] = 9;
                                a.SetValue(0, arr[0] - 1, arr[1]);
                            }
                            else
                            {
                                a.SetValue(0, arr[0], arr[1] - 1);
                            }
                        }
                        else
                        {
                            a.SetValue(0, 0, number - 1);
                        }
                        WriteTable();
                        Console.Write("Occupied seats:");
                        foreach (var item in seats)
                        {
                            Console.Write(item);
                            Console.Write(",");
                        }
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine("Choose another seat");
                    }
                }
                    
            }
            WriteTable();
            Occupied();

            Console.ReadKey();
        }
    }
}
 