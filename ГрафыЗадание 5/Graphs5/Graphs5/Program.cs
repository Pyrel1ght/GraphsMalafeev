using Graphs5;
using System;
using System.ComponentModel;
using System.Diagnostics;

namespace Graphs5
{
    public class Program
    {
        static void Main(string[] args)
        {
            int flag = 0;
            IGraph? graph = null;
            StreamWriter? sw = null;
            int? startVertex = null;
            int? endVertex = null;
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
                if (args[i] == "-m"|| args[i] == "-e"|| args[i] == "-l")
                {
                    graph = new GraphMatrix(args[i + 1], args[i]);
                }
                else if (args[i] == "-o")
                {
                    sw = new StreamWriter(args[i + 1]);
                    sw.AutoFlush = true;
                }
                else if (args[i]=="-n")
                {
                    startVertex = int.Parse(args[i + 1]);
                }
                else if (args[i] == "-d")
                {
                    endVertex = int.Parse(args[i + 1]);
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
            
            if (startVertex != null && endVertex != null) graph.Dijkstra((int)startVertex,(int)endVertex, sw);
            

            void ShowHelp()
            {
                Console.WriteLine("Выполнено студентом Малафеевым Андреем\n Группа М3О-225Бк-21\n Ключи:\n -m - Граф считывается из Матрицы смежности\n -e - Граф считывается из Списка ребер\n -l - Граф считывается из Списка смежности\n -o - Вывести результат в файл -n - Начальная вершина Дейкстры  \n -d - Конечная вершина Дейкстры");
            }
            
        }






    }

}