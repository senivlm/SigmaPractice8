using System;
using System.Collections.Generic;
using System.IO;
namespace HW8_3
{
    class Sent
    {
        private const string path = @"C:\Users\admin\source\repos\Practice8_1\Sentences.txt";
        private string[] sentence;
        private List<string> sent;
        private int[] Br;

        public Sent()
        {
            string[] readText = File.ReadAllLines(path);
            sentence = (readText[0].Split('.'));
            sent = new List<string>(sentence.Length - 1);
            for (int i = 0; i < sentence.Length - 1; i++)
            {
                sent.Add(sentence[i]);
            }
            Br = new int[sentence.Length];
        }

        public int Num(string Str)
        {
            int current_max = 0;
            int max = 0;
            int n = Str.Length;

            for (int i = 0; i < n; i++)
            {
                if (Str[i] == '(')
                {

                    current_max++;
                    if (current_max > max)
                        max = current_max;

                }

                else if (Str[i] == ')')
                {
                    if (current_max > 0)
                        current_max--;
                    else
                        return -1;

                }
            }
            if (current_max != 0)
                return -1;

            return max;
        }


        public string Max()
        {
            int i = 0;
            foreach (var t in sent)
            {
                Br[i] = Num(t);
                i++;
            }
            int position = Deepest();
            return sent[position];

        }

        public int Deepest()
        {
            int max = Br[0];
            int position = 0;
            for (int i = 1; i < Br.Length; i++)
            {
                if (max < Br[i])
                {
                    position = i;
                    max = Br[i];
                }
            }
            return position;
        }

        public void Sort(Program.MoreOrLess del)
        {
            int size = sent.Capacity;
            for (int i = 1; i < size; i++)
            {
                for (int j = 0; j < (size - i); j++)
                {
                    if (del(sent[j].Length, sent[j + 1].Length))
                    {
                        Swap(j);
                    }
                }
            }

        }

        public void Swap(int j)
        {
            string temp = sent[j];
            sent[j] = sent[j + 1];
            sent[j + 1] = temp;
        }



        public string Write()
        {
            string result = null;
            int i = 0;
            foreach (var item in sent)
            {
                result += sent[i] + "\n";
                i++;
            }

            return result;
        }

    }


    class Program
    {
        public delegate bool MoreOrLess(int x, int y);
        static void Main(string[] args)
        {
            Sent sent = new Sent();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("The deepest one is");
            Console.ResetColor();
            Console.WriteLine(sent.Max());
            sent.Sort((x, y) => x > y == true);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Sorted list with lambda");
            Console.ResetColor();
            Console.WriteLine(sent.Write());

        }
    }
}
