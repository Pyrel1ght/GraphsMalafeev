using System;
using System.ComponentModel;
using System.Diagnostics;

namespace Graphs4
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
            flag = 0;
            foreach (var arg in args)
            {
                if (arg == "-p")
                {
                    var mst = graph.PrimMST();
                    int mincost = 0;
                    sw.WriteLine("Минимальное остовное дерево:");
                    sw.Write("[");
                    foreach (var i in mst)
                    {
                        sw.Write($"({i.Item1} {i.Item2} {i.Item3}) ");
                        mincost += i.Item3;
                    }
                    sw.WriteLine("]");
                    sw.WriteLine("Вес остовного дерева: " + mincost);
                    flag = 1;
                    break;
                }
                else if (arg == "-k")
                {
                    var mst = graph.KruskalMst();
                    int mincost = 0;
                    sw.WriteLine("Минимальное остовное дерево:");
                    sw.Write("[");
                    foreach (var i in mst)
                    {
                        sw.Write($"({i.Item1} {i.Item2} {i.Item3}) ");
                        mincost += i.Item3;
                    }
                    sw.WriteLine("]");
                    sw.WriteLine("Вес остовного дерева: " + mincost);
                    flag = 1;
                    break;
                }
                else if (arg == "-b")
                {
                    var mst = graph.BoruvkaMST();
                    int mincost = 0;
                    sw.WriteLine("Минимальное остовное дерево:");
                    sw.Write("[");
                    foreach (var i in mst)
                    {
                        sw.Write($"({i.Item1} {i.Item2} {i.Item3}) ");
                        mincost += i.Item3;
                    }
                    sw.WriteLine("]");
                    sw.WriteLine("Вес остовного дерева: " + mincost);
                    flag = 1;
                    break;

                }
                else if (arg == "-s")
                {
                    sw.WriteLine("Алгоритм Прима");
                    Stopwatch stopwatch = new Stopwatch();
                    stopwatch.Start();
                    var mstPrim = graph.PrimMST();
                    stopwatch.Stop();
                    int mincostPrim = 0;
              
                   
                    sw.WriteLine("Минимальное остовное дерево:");
                    sw.Write("[");
                    foreach (var i in mstPrim)
                    {
                        sw.Write($"({i.Item1} {i.Item2} {i.Item3}) ");
                        mincostPrim += i.Item3;
                    }
                    sw.WriteLine("]");
                    sw.WriteLine("Вес остовного дерева: " + mincostPrim);
                    sw.WriteLine("Алгоритм проработал " + stopwatch.ElapsedMilliseconds + " Миллисекунд");
                    sw.WriteLine("Алгоритм Краскала");
                    stopwatch.Restart();
                    var mstKrusk = graph.KruskalMst();
                    stopwatch.Stop();
                    int mincostKrusk = 0;
                    sw.WriteLine("Минимальное остовное дерево:");
                    sw.Write("[");
                    foreach (var i in mstKrusk)
                    {
                        sw.Write($"({i.Item1} {i.Item2} {i.Item3}) ");
                        mincostKrusk += i.Item3;
                    }
                    sw.WriteLine("]");
                    sw.WriteLine("Вес остовного дерева: " + mincostKrusk);
                    
                    sw.WriteLine("Алгоритм проработал " + stopwatch.ElapsedMilliseconds + " Миллисекунд" );
                    sw.WriteLine("Алгоритм Борувки");
                    stopwatch.Restart();
                    var mstBoruvka = graph.BoruvkaMST();
                    stopwatch.Stop();
                    int mincostBoruvka = 0;
                    sw.WriteLine("Минимальное остовное дерево:");
                    sw.Write("[");
                    foreach (var i in mstBoruvka)
                    {
                        sw.Write($"({i.Item1} {i.Item2} {i.Item3}) ");
                        mincostBoruvka += i.Item3;
                    }
                    sw.WriteLine("]");
                    sw.WriteLine("Вес остовного дерева: " + mincostBoruvka);
                    
                    sw.WriteLine("Алгоритм проработал " + stopwatch.ElapsedMilliseconds + " Миллисекунд");
                    flag = 1;
                    break;
                }
                
            }
            if (flag==0)
            {
                throw new Exception("Введите правильный ключ");
            }

            void ShowHelp()
            {
                Console.WriteLine("Выполнено студентом Малафеевым Андреем\n Группа М3О-225Бк-21\n Ключи:\n -m - Граф считывается из Матрицы смежности\n -e - Граф считывается из Списка ребер\n -l - Граф считывается из Списка смежности\n -o - Вывести результат в файл");
            }
        
    }






    }

}