using Graph7;
using System;
using System.ComponentModel;
using System.Diagnostics;

namespace Graph7
{
    public class Program
    {
        static void Main(string[] args)
        {
            int flag = 0;
            IGraph? graph = null;
            StreamWriter? sw = null;
            int? startVertex = null;
            
            for (int i = 0; i < args.Length; i++)
            {
                for (int j = 0; j < args.Length; j++)
                    if (args[j] == "-h")
                    {
                        ShowHelp();
                        flag = 1;
                        break;
                    }
                if (flag == 1)
                {
                    break;
                }
            }
            for (int i = 0; i < args.Length; i++)
            {
                if (args[i] == "-m" || args[i] == "-e" || args[i] == "-l")
                {
                    graph = new GraphMatrix(args[i + 1], args[i]);
                }
                else if (args[i] == "-o")
                {
                    sw = new StreamWriter(args[i + 1]);
                    sw.AutoFlush = true;
                }
                else if (args[i] == "-n")
                {
                    startVertex = int.Parse(args[i + 1]);
                }


            }
            if (graph == null)
            {
                return;
            }
            if (sw == null)
            {
                sw = new StreamWriter(Console.OpenStandardOutput());
                sw.AutoFlush = true;
                Console.SetOut(sw);
            }
            flag = 0;
            foreach (var item in graph.AdjacencyMatrix())
            {
                if (item < 0)
                {
                    flag = 1;
                    sw.WriteLine("В графе есть ребра с отрицательным весом.");
                    break;
                }
            }
            if (flag == 0)
            {
                sw.WriteLine("В графе нет ребер с отрицательным весом.");
            }
            try
            {
                var dist = graph.Johnson();
                for (int i = 0; i < dist.Count; i++)
                {
                    for (int j = 0; j < dist[i].Count; j++)
                    {
                        if (dist[i][j] < 9000)
                        {
                            if (i != j)
                                Console.WriteLine(i + " - " + j + " : " + dist[i][j] + " ");
                        }
                    }
                    Console.WriteLine();
                }
            }
            catch(Exception e) 
            {
                sw.WriteLine(e.Message);
            }
            

        }

        static void ShowHelp()
        {
            Console.WriteLine("Выполнено студентом Малафеевым Андреем\n Группа М3О-225Бк-21\n Ключи:\n -m - Граф считывается из Матрицы смежности\n -e - Граф считывается из Списка ребер\n -l - Граф считывается из Списка смежности\n -o - Вывести результат в файл");
        }




    }

}