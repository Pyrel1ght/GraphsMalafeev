using System;
using System.ComponentModel;


namespace Graphs2 // Note: actual namespace depends on the project name.
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            int flag = 0;
            IGraph? graph = null;
            StreamWriter? sw = null;

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
                if (args[i] == "-m")
                {
                    graph = new GraphMatrix(args[i + 1]);


                }
                else if (args[i] == "-e")
                {
                    graph = new EdgeList(args[i + 1]);

                }
                else if (args[i] == "-l")
                {
                    graph = new AdjacencyGraph(args[i + 1]);
                }
                else if (args[i] == "-o")
                {
                    sw = new StreamWriter(args[i + 1]);
                    sw.AutoFlush = true;
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
            var connectComponent = graph.IsConnectNotOriented();
            if (connectComponent.Count == 1)
                sw.WriteLine("Граф свзяный");
            else sw.WriteLine($"Граф не связный и содержит {connectComponent.Count()} компонент связности.");
            sw.WriteLine("Компоненты связности:");
            for (int i = 0; i < connectComponent.Count(); i++)
            {
                foreach (var next in connectComponent[i])
                {
                    sw.Write(next + " ");
                }
                sw.WriteLine();
            }
            if (graph.IsDirected()==true)
            {
                
                var strongly = graph.Kosaraju();
                if (strongly.Count() == 1)
                    sw.WriteLine("Орграф сильносвязный");
                else sw.WriteLine($"Орграф слабосвязный и содержит {strongly.Count()} сильный компонент связности");


                sw.WriteLine("Сильных компонент связности");
                for (int i = 0; i < strongly.Count(); i++)
                {
                    foreach (var next in strongly[i])
                    {
                        sw.Write(next + " ");
                    }
                    sw.WriteLine();
                }
            }
            
            void ShowHelp()
            {
                Console.WriteLine("Выполнено студентом Малафеевым Андреем\n Группа М3О-225Бк-21\n Ключи:\n -m - Граф считывается из Матрицы смежности\n -e - Граф считывается из Списка ребер\n -l - Граф считывается из Списка смежности\n -o - Вывести результат в файл");
            }
        }
    }

}