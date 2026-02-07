using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;

namespace matrix_simulatenous_equations
{
    internal class Program
    {
        static void inputEquations(ref Matrix varMatrix, ref Matrix resultMatrix)
        {
            char[] varNames = { 'x', 'y', 'z' };
            Console.CursorVisible = false;

            // print table
            Console.WriteLine("Enter the values for the following equations:\n");
            for (int row = 0; row < varMatrix.dim(0); row++)
            {
                for (int col = 0; col < varMatrix.dim(1); col++)
                {
                    char opChar;
                    if (col == varMatrix.dim(1) - 1) opChar = '=';
                    else opChar = '+';
                    string printValue = varMatrix[row, col].ToString().PadLeft(8);
                    Console.Write($"{printValue}{varNames[col]} {opChar}");
                }
                Console.Write($"{resultMatrix[row, 0].ToString().PadLeft(8)}");
                Console.WriteLine();
            }

            // move on table
            bool inputting = true;
            int xpos = 0;
            int ypos = 0;
            while (inputting)
            {
                ConsoleKey keyPressed = Console.ReadKey(true).Key;
                if (keyPressed == ConsoleKey.LeftArrow)
                {
                    if (xpos > 0)
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.CursorLeft = xpos * 11;
                        Console.CursorTop = 2 + ypos;
                        if (xpos == varMatrix.dim(1)) Console.Write($"{resultMatrix[ypos, 0].ToString().PadLeft(8)}");
                        else Console.Write($"{varMatrix[ypos, xpos].ToString().PadLeft(8)}");
                        xpos--;
                        Console.BackgroundColor = ConsoleColor.Gray;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.CursorLeft = xpos * 11;
                        Console.CursorTop = 2 + ypos;
                        if (xpos == varMatrix.dim(1)) Console.Write($"{resultMatrix[ypos, 0].ToString().PadLeft(8)}");
                        else Console.Write($"{varMatrix[ypos, xpos].ToString().PadLeft(8)}");
                    }
                }
                else if (keyPressed == ConsoleKey.RightArrow)
                {
                    if (xpos < varMatrix.dim(1))
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.CursorLeft = xpos * 11;
                        Console.CursorTop = 2 + ypos;
                        if (xpos == varMatrix.dim(1)) Console.Write($"{resultMatrix[ypos, 0].ToString().PadLeft(8)}");
                        else Console.Write($"{varMatrix[ypos, xpos].ToString().PadLeft(8)}");
                        xpos++;
                        Console.BackgroundColor = ConsoleColor.Gray;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.CursorLeft = xpos * 11;
                        Console.CursorTop = 2 + ypos;
                        if (xpos == varMatrix.dim(1)) Console.Write($"{resultMatrix[ypos, 0].ToString().PadLeft(8)}");
                        else Console.Write($"{varMatrix[ypos, xpos].ToString().PadLeft(8)}");
                    }
                }
                else if (keyPressed == ConsoleKey.UpArrow)
                {
                    if (ypos > 0)
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.CursorLeft = xpos * 11;
                        Console.CursorTop = 2 + ypos;
                        if (xpos == varMatrix.dim(1)) Console.Write($"{resultMatrix[ypos, 0].ToString().PadLeft(8)}");
                        else Console.Write($"{varMatrix[ypos, xpos].ToString().PadLeft(8)}");
                        ypos--; ;
                        Console.BackgroundColor = ConsoleColor.Gray;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.CursorLeft = xpos * 11;
                        Console.CursorTop = 2 + ypos;
                        if (xpos == varMatrix.dim(1)) Console.Write($"{resultMatrix[ypos, 0].ToString().PadLeft(8)}");
                        else Console.Write($"{varMatrix[ypos, xpos].ToString().PadLeft(8)}");
                    }
                }
                else if (keyPressed == ConsoleKey.DownArrow)
                {
                    if (ypos < varMatrix.dim(0) - 1)
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.CursorLeft = xpos * 11;
                        Console.CursorTop = 2 + ypos;
                        if (xpos == varMatrix.dim(1)) Console.Write($"{resultMatrix[ypos, 0].ToString().PadLeft(8)}");
                        else Console.Write($"{varMatrix[ypos, xpos].ToString().PadLeft(8)}");
                        ypos++;
                        Console.BackgroundColor = ConsoleColor.Gray;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.CursorLeft = xpos * 11;
                        Console.CursorTop = 2 + ypos;
                        if (xpos == varMatrix.dim(1)) Console.Write($"{resultMatrix[ypos, 0].ToString().PadLeft(8)}");
                        else Console.Write($"{varMatrix[ypos, xpos].ToString().PadLeft(8)}");
                    }

                }
                else if (keyPressed == ConsoleKey.Enter)
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.CursorLeft = xpos * 11;
                    Console.CursorTop = 2 + ypos;
                    Console.Write("        ");
                    Console.CursorLeft = xpos * 11;
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Black;
                    double newVal = double.Parse(Console.ReadLine());
                    if (xpos == varMatrix.dim(1)) resultMatrix[ypos, 0] = newVal; 
                    else varMatrix[ypos, xpos] = newVal;
                    Console.CursorLeft = xpos * 11;
                    Console.CursorTop = 2 + ypos;
                    if (xpos == varMatrix.dim(1)) Console.Write($"{resultMatrix[ypos, 0].ToString().PadLeft(8)}");
                    else Console.Write($"{varMatrix[ypos, xpos].ToString().PadLeft(8)}");
                }
                else if (keyPressed == ConsoleKey.Escape)
                {
                    inputting = false;
                }
            }
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
        }
        static void Main(string[] args)
        {
            char[] varNames = { 'x', 'y', 'z' };
            Matrix varMatrix = new Matrix(2, 2);
            Matrix resultMatrix = new Matrix(2, 1);

            inputEquations(ref varMatrix, ref resultMatrix);

            Matrix results = varMatrix.inverse() * resultMatrix;

            for (int row = 0; row < results.dim(0); row++)
            {
                Console.WriteLine($"{varNames[row]} = {results[row, 0]}");
            }
            
        }
    }
}

