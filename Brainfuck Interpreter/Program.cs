using System;

namespace Brainfuck_Interpreter
{
    class Program
    {
        static byte[] tape = new byte[65536];
        static int pointer = 0;
        static int loopDepth = 0;

        static void Main(string[] args)
        {
            Console.Write("Input program: ");
            string program = Console.ReadLine();

            if (program.Split('[').Length != program.Split(']').Length)
            {
                Console.WriteLine("Incorrect number of '[' or ']'\nPress enter to exit");
                Console.Read();
                Environment.Exit(0);
            }
            
            for (int i = 0; i < program.Length; i++)
            {
                switch (program[i])
                {
                    case '>':
                        pointer++;
                        break;

                    case '<':
                        pointer--;
                        break;

                    case '+':
                        tape[pointer]++;
                        break;

                    case '-':
                        tape[pointer]--;
                        break;

                    case '.':
                        Console.Write(Convert.ToChar(tape[pointer]));
                        break;

                    case ',':
                        Console.Write("> ");
                        tape[pointer] = (byte)Console.ReadLine()[0];
                        break;

                    case '[':
                        if (tape[pointer] == 0)
                        {
                            loopDepth++;
                            while (program[i] != ']' || loopDepth != 0)
                            {
                                i++;

                                if (program[i] == '[')
                                {
                                    loopDepth++;
                                }
                                else if (program[i] == ']')
                                {
                                    loopDepth--;
                                }
                            }
                        }
                        break;

                    case ']':
                        if (tape[pointer] != 0)
                        {
                            loopDepth++;
                            while (program[i] != '[' || loopDepth != 0)
                            {
                                i--;

                                if (program[i] == ']')
                                {
                                    loopDepth++;
                                }
                                else if (program[i] == '[')
                                {
                                    loopDepth--;
                                }
                            }
                        }
                        break;
                }
            }

            Console.WriteLine("\n\nPress enter to exit");
            Console.Read();
        }
    }
}
